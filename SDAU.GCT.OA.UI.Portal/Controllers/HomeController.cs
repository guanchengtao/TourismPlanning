using SDAU.GCT.OA.Common;
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    public class HomeController : BaseController
    {

        public IUserInfoService UserInfoService { get; set; }
        public IActionInfoService ActionInfoService { get; set; }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        #region 测试JsonNetResult
        [HttpGet]
        public ActionResult Text()
        {
            UserInfo userInfo = new UserInfo()
            {
                UserName = "111",
                UserPwd = "123",
                SubTime = DateTime.Now
            };
            return Json(userInfo,JsonRequestBehavior.AllowGet);
           // return new JsonNetResult() { Data = userInfo };

        } 
        #endregion
        /// <summary>
        ///根据用户权限加载菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadUserMenu()
        {
            int uid = LoginUserInfo.Id;
            var user = UserInfoService.GetEntities(u => u.Id == uid).FirstOrDefault();
            string name = user.UserName;

            var allRole = user.RoleInfo;
            //用户所有的角色对应的权限
            var allRoleActionIds = (from r in allRole
                                    from a in r.ActionInfo
                                    select a.Id).ToList();
            //拿到用户本身就不具备的权限
            var alldeleteActionIds = (from r in user.R_UserInfo_ActionInfo
                                      where r.HasPermission == false && r.DelFlag == 1
                                      select r.ActionInfoId).ToList();
            //做一个差集：角色权限-特殊拒绝权限
            //var allactionIds = allRoleActionIds.Where(u=>!alldeleteActionIds.Contains(u));
            var allactionIds = (from r in allRoleActionIds
                                where !alldeleteActionIds.Contains(r)
                                select r).ToList();
            //拿到用户本身就具有的权限
            var allUserActionIds = (from r in user.R_UserInfo_ActionInfo
                                    where r.HasPermission == true && r.DelFlag == 1
                                    select r.ActionInfoId).ToList();
            //把当前用户所有权限取出
            allactionIds.AddRange(allUserActionIds.AsEnumerable());
            allactionIds = allactionIds.Distinct().ToList();//去重操作
            //拿到菜单权限
            var actionList = ActionInfoService.GetEntities(u => allactionIds.Contains(u.Id) && u.IsMenu == true && u.DelFlag ==1);

            var data = from a in actionList
                       select new {  a.ActionName, a.Url,a.Id };
            var jsondata = new { data, username = name };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }
}