using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        public bool IsCheck = true;
        public UserInfo LoginUserInfo { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            IApplicationContext ctx = ContextRegistry.GetContext();
            if(IsCheck)
            {
                //从Redis缓存中读取数据
                if (Request.Cookies["loginuserId"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/adminlogin/Login.html");
                    return;
                }
                string userGuid = Request.Cookies["loginuserId"].Value.ToString();

                object id = CacheHelper.CacheHelper.GetString(userGuid);
                //用户长时间不进行操作，超时了
                if (id==null)
                {
                    filterContext.HttpContext.Response.Redirect("/adminlogin/Login.html");
                }
                int userid = int.Parse(id.ToString());
                IUserInfoService userInfoService = ctx.GetObject("UserInfoService") as IUserInfoService;

                UserInfo userInfo = userInfoService.GetEntities(u => u.Id == userid).FirstOrDefault();
                //将查出的用户赋值给当前登录用户
                LoginUserInfo =userInfo;
                //设置滑动窗口机制,一旦登陆了，就给当前用户+20min
                CacheHelper.CacheHelper.SetCache(userGuid, userid, DateTime.Now.AddMinutes(20));
                //给admin留后门
                if (LoginUserInfo.UserName == "admin") return;
                else
                {
                    string url = Request.Url.AbsolutePath.ToLower();
                    string httpmethod = Request.HttpMethod.ToLower();
                    IActionInfoService actionInfoService = ctx.GetObject("ActionInfoService") as IActionInfoService;
                    IR_UserInfo_ActionInfoService r_UserInfo_ActionInfoService = ctx.GetObject("R_UserInfo_ActionInfoService") as IR_UserInfo_ActionInfoService;
                    var actioninfo=actionInfoService.GetEntities(a=>a.HttpMethod.ToLower()==httpmethod&&a.Url.ToLower()==url).FirstOrDefault();
                    if(actioninfo==null)
                    {
                        ContentResult content = new ContentResult();
                        content.ContentType = "text/javascript";
                        content.Content= "{data:500}";
                        filterContext.Result = content;
                    }
                    else
                    {
                        //第一条线，直接去判断这个权限是否属于登录用户
                        //1、首先拿到用户所拥有的权限
                        var actionlist = r_UserInfo_ActionInfoService.GetEntities(u => u.UserInfoId == LoginUserInfo.Id);
                        //拿到要访问的那一条权限
                        var visitAction = (from r in actionlist
                                           where r.ActionInfoId == actioninfo.Id
                                           select r).FirstOrDefault();
                        if (visitAction != null)
                        {
                            //3、判断该条权限是否被允许
                            if (visitAction.HasPermission == true)
                            {
                                return;
                            }
                            else
                            {
                                ContentResult content = new ContentResult();
                                content.ContentType = "text/javascript";
                                content.Content = "{data:500}";
                                filterContext.Result = content;
                            }

                        }
                        //第二条线
                        //1、先拿到该用户所有的角色
                        var userinfo = userInfoService.GetEntities(u => u.Id == LoginUserInfo.Id).FirstOrDefault();

                        var allroles = from r in userinfo.RoleInfo select r;
                        //拿到这些角色所拥有的权限
                        var actions = from r in allroles
                                      from a in r.ActionInfo
                                      select a;
                        //当前权限是否在角色对应的权限集合中
                        var count = (from a in actions
                                     where a.Id == actioninfo.Id
                                     select a).Count();
                        if(count<=0)
                        {
                            ContentResult content = new ContentResult();
                            content.ContentType = "text/javascript";
                            content.Content = "{data:500}";
                            filterContext.Result = content;
                        }
                    }
                }
            }
        }
    }
}