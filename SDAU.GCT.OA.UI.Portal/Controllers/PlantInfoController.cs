using Newtonsoft.Json;
using SDAU.GCT.OA.Common;
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using SDAU.GCT.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    [TimingActionFilter]  //记录这一个访问控制器的日志
    public class PlantInfoController : Controller
    {
        // GET: PlantInfo
        public IPlantInfoService PlantInfoService { get; set; }
        public IPlantImageService PlantImageService { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPlant(int id)
        {
          

              if(CacheHelper.CacheHelper.GetString("R_"+id)!=null)
              {
                  int newhot = GetPlantHot(id);
                  var data = CacheHelper.CacheHelper.GetString("R_" + id);
                  var imgdata = PlantImageService.GetEntities(i => i.PlantInfoId == id);
                  List<string> imglist = new List<string>();
                  foreach (PlantImage item in imgdata)
                  {
                      imglist.Add(item.Url);
                  }
                  var jsondata = new { code = 200, data, newhot, imglist };
                  return Json(jsondata, JsonRequestBehavior.AllowGet);
              }
              else
              {

                  int newhot = GetPlantHot(id);
                  var data = PlantInfoService.GetEntities(u => u.Id == id);

                var  qdata = data.Select(a => new
                {
                    a.PlantName,
                    a.DelFlag,
                    a.SubTime,
                    a.Id,
                    a.PlantDetail,
                    a.JingDu,
                    a.WeiDu,
                    a.Xiaoqu
                });
                CacheHelper.CacheHelper.SetCache("R_" + id, qdata);
                var imgdata = PlantImageService.GetEntities(i => i.PlantInfoId == id);
                  List<string> imglist = new List<string>();
                  foreach (PlantImage item in imgdata)
                  {
                      imglist.Add(item.Url);
                  }
                  var jsondata = new { code = 200, qdata, newhot, imglist };
                  return Json(jsondata, JsonRequestBehavior.AllowGet);
             } 
        }

        [HttpGet]
        public ActionResult GetPlantsHot(int id)
        {
            int hot = int.Parse(CacheHelper.CacheHelper.GetString(id.ToString()));
            var jsondata = new { Status.code, hot };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPlantByPage()
        {
            int pageSize = int.Parse(Request["limit"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            //条件
            Expression<Func<PlantInfo, bool>> WhereLambda = u => u.DelFlag == 1;
            //排序条件
            Expression<Func<PlantInfo, DateTime>> OrderbyLambda = u => u.SubTime;
            var olddata = PlantInfoService.GetEntitiesByPage(pageSize, pageIndex, out int count, WhereLambda, OrderbyLambda, false);
            var data = olddata.Select(a => new
            {
                a.PlantName,
                a.DelFlag,
                a.SubTime,
                a.Id,
                a.PlantDetail,
                a.JingDu,
                a.WeiDu,
                a.Xiaoqu
            });
            var jsondata = new { Status.code, count, data };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(PlantInfo plantInfo)
        {
            plantInfo.SubTime = DateTime.Now;
            plantInfo.DelFlag = 1;
            if (ModelState.IsValid)
            {
                PlantInfoService.Add(plantInfo);
            }
            CacheHelper.CacheHelper.SetCache("Update_Flag", 1);
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult DeleteSingle(int id)
        {
            bool delflag = PlantInfoService.DeleteSingle(id);
            var jsondata = new { delflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteMultiple(List<int> ids)
        {
            PlantInfoService.DeleteMultiple(ids);
            var jsondata = new { count = ids.Count(), Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Update(PlantInfo PlantInfo)
        {
            //同一个上下文不能缓存两个同一个主键的对象
            PlantInfo oldUser = PlantInfoService.GetEntities(u => u.Id == PlantInfo.Id).FirstOrDefault();
            //查出来一个旧的权限实体，直接在上面修改
            //oldUser.UserName = PlantInfo.UserName;
            //oldUser.UserPwd = PlantInfo.UserPwd;
            //oldUser. = PlantInfo.Remark;
            bool updateflag = PlantInfoService.Update(oldUser);
            var jsondata = new { updateflag, Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
        int GetPlantHot(int id)
        {
            if (CacheHelper.CacheHelper.GetString(id.ToString()) == null)
            {
                CacheHelper.CacheHelper.AddCache(id.ToString(), 1);
            }
            else
            {
                int oldhot = int.Parse(CacheHelper.CacheHelper.GetString(id.ToString()));
                CacheHelper.CacheHelper.SetCache(id.ToString(), oldhot + 1);
            }
            int hot= int.Parse(CacheHelper.CacheHelper.GetString(id.ToString()));
            return hot;
        }
    }
}