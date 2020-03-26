using SDAU.GCT.OA.BLL;
using SDAU.GCT.OA.Common;
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    public class ActionInfoController : BaseController
    {
        // GET: ActionInfo
        public IActionInfoService ActionInfoService { get; set; }
        public IRoleInfoService RoleInfoService { get; set; }

        [HttpGet]
        public ActionResult GetAllActions()
        {
            var data = ActionInfoService.GetEntities(u => u.DelFlag == 1);
            int count = data.Count();
            var jsondata = new { Status.success, count, data };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAction(int id)
        {
            var data = ActionInfoService.GetEntities(u => u.Id == id);
            var jsondata = new { Status.code, data };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetActionByPage()
        {
            int pageSize = int.Parse(Request["limit"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int count = 0;
            //条件
            Expression<Func<ActionInfo, bool>> WhereLambda = u => u.DelFlag == 1;
            //排序条件
            Expression<Func<ActionInfo, DateTime>> OrderbyLambda = u => u.Subtime;
            var olddata = ActionInfoService.GetEntitiesByPage(pageSize, pageIndex, out count, WhereLambda, OrderbyLambda, false);
            var data = olddata.Select(a =>new
            {
                a.ActionName,
                a.DelFlag,
                a.HttpMethod,
                a.Id,
                a.IsMenu,
                a.MenuIcon,
                a.Remark,
                a.Sort,
                a.Subtime,
                a.Url
            });
            var jsondata = new { Status.code, count, data };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(ActionInfo actionInfo)
        {
            actionInfo.Subtime = DateTime.Now;
            actionInfo.DelFlag = 1;
            actionInfo.Sort = 1;
            if (ModelState.IsValid)
            {
                ActionInfoService.Add(actionInfo);
            }
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSingle(int id)
        {
            bool delflag = ActionInfoService.DeleteSingle(id);
            var jsondata = new { delflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMultiple(List<int> ids)
        {
            ActionInfoService.DeleteMultiple(ids);
            var jsondata = new { count = ids.Count(), Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(ActionInfo ActionInfo)
        {
            //同一个上下文不能缓存两个同一个主键的对象
            ActionInfo oldUser = ActionInfoService.GetEntities(u => u.Id == ActionInfo.Id).FirstOrDefault();
           //查出来一个旧的权限实体，直接在上面修改
            //oldUser.UserName = ActionInfo.UserName;
            //oldUser.UserPwd = ActionInfo.UserPwd;
            oldUser.Remark = ActionInfo.Remark;
            bool updateflag = ActionInfoService.Update(oldUser);
            var jsondata = new { updateflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetRoleInfoList(int id)
        {
            var action = ActionInfoService.GetEntities(u => u.Id == id).FirstOrDefault() as ActionInfo;
            var temp = RoleInfoService.GetEntities(r => r.DelFlag == 1);
            var allroles = temp.Select(r => new
            {
                r.DelFlag,
                r.Id,
                r.Remark,
                r.RoleName,
                r.SubTime
            });
            var existroles = (from r in action.RoleInfo select r.Id).ToList();
            var jsondata = new { allroles, existroles, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
       // [HttpPost]
        //public ActionResult SetRole(int id, List<int> rolesId)
        //{
        //    bool flag = ActionInfoService.SetRole(id, rolesId);
        //    var jsondata = new { id, Status.code, flag };
        //    return Json(jsondata, JsonRequestBehavior.AllowGet);
        //}

    }
}