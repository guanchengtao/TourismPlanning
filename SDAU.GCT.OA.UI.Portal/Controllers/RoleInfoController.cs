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
    public class RoleInfoController : BaseController
    {
        // GET: RoleInfo
        public IRoleInfoService RoleInfoService { get; set; }

        [HttpGet]
        public ActionResult GetAllRoles()
        {
            var data = RoleInfoService.GetEntities(u => u.DelFlag == 1);
            int count = data.Count();
            var jsondata = new { Status.code, count, data };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRole(int id)
        {
            var data = RoleInfoService.GetEntities(u => u.Id == id);
            var newdata = data.Select(r => new {
                r.DelFlag,
                r.Id,
                r.Remark,
                r.RoleName,
                r.SubTime
            });
            var jsondata = new { Status.code, newdata };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRoleByPage()
        {
            int pageSize = int.Parse(Request["limit"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int count = 0;
            //条件
            Expression<Func<RoleInfo, bool>> WhereLambda = u => u.DelFlag == 1;
            //排序条件
            Expression<Func<RoleInfo, DateTime>> OrderbyLambda = u => u.SubTime;
            var data = RoleInfoService.GetEntitiesByPage(pageSize, pageIndex, out count, WhereLambda, OrderbyLambda, false);
            var newdata = data.Select(r => new {
                r.DelFlag,
                r.Id,
                r.Remark,
                r.RoleName,
                r.SubTime
                });
            var jsondata = new { Status.code, count, newdata };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(RoleInfo roleInfo)
        {
            roleInfo.SubTime = DateTime.Now;
            roleInfo.DelFlag = 1;
            if (ModelState.IsValid)
            {
                RoleInfoService.Add(roleInfo);
            }
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSingle(int id)
        {
            bool delflag = RoleInfoService.DeleteSingle(id);
            var jsondata = new { delflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMultiple(List<int> ids)
        {
            RoleInfoService.DeleteMultiple(ids);
            var jsondata = new { count = ids.Count(), Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(RoleInfo RoleInfo)
        {
            //同一个上下文不能缓存两个同一个主键的对象
            RoleInfo oldUser = RoleInfoService.GetEntities(u => u.Id == RoleInfo.Id).FirstOrDefault();
            //oldUser.UserName = RoleInfo.UserName;
            //oldUser.UserPwd = RoleInfo.UserPwd;
            oldUser.Remark = RoleInfo.Remark;
            bool updateflag = RoleInfoService.Update(oldUser);
            var jsondata = new { updateflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }
}