using CacheHelper;
using SDAU.GCT.OA.Common;
using SDAU.GCT.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{

    public class UserLoginController : BaseController
    {
        public UserLoginController()
        {
            //登录的时候不需要参与校验
            this.IsCheck = false;
        }
        // GET: UserLogin
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowVcode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string Codestr = validateCode.CreateValidateCode(4);
            //把验证码写到Session里面
            Session["VCode"] = Codestr;
            byte[] img = validateCode.CreateValidateGraphic(Codestr);
            return File(img, @"image/jpeg");
        }
        public ActionResult LoginProcess()
        {
            #region 验证码
            string strcode = Request["usercode"];
            string sessioncode = Session["Vcode"].ToString();
            if (string.IsNullOrEmpty(sessioncode) || strcode != sessioncode)
            {
                return Content("验证码错误");
            }
            #endregion
            string name = Request["username"].ToString();
            string pwd = Request["userpwd"].ToString();
            string password = MD5Helper.GenerateMD5($"{name}{pwd}");
            var userInfo = 
                 UserInfoService.GetEntities(u => u.UserName == name && u.UserPwd == password && u.DelFlag == 1)
.FirstOrDefault();
            if (userInfo == null)
            {
                var data = new{ msg = "账号或密码错误",code=500 };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //改用Redis+cookie
                string loginuserId = Guid.NewGuid().ToString();
                ////把用户id写入Redis
                int userid = userInfo.Id;
                ////Common.Cache.CacheHelper.AddCache(loginuserId, userid, DateTime.Now.AddMinutes(20));
                CacheHelper.CacheHelper.AddCache(loginuserId, userid, DateTime.Now.AddMinutes(20));
                ////往客户端写入cookie             
                Response.Cookies["loginuserId"].Value = loginuserId;
                var data = new { code = 200 };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}