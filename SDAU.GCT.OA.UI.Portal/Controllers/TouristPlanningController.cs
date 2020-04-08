using SDAU.GCT.OA.BLL;
using SDAU.GCT.OA.Common;
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using SDAU.GCT.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    [TimingActionFilter]
    public class TouristPlanningController : Controller
    {
        public ITouristPlanningService TouristPlanningService { get; set; }
       
        [HttpGet]
        public ActionResult GetTourismPlanning(int page, int limit, string keyword = "")
        {

            var dataObj = TouristPlanningService.GetEntities(u => u.DelFlag == 1);
            var data = new List<TouristPlanning>();
            if (keyword.Length > 0)
            {
                data = dataObj.Where(x => x.Name.Contains(keyword)|| x.PlanLeader.Contains( keyword )|| x.PlanUnit .Contains( keyword)).ToList();
            }
            else
            {
                data = dataObj.ToList();
            }
            var res = data
            .OrderByDescending(x => x.SubTime)
            .Take(limit * page).Skip(limit * (page - 1)).ToList();//进行分页
            var result = new List<TouristPlanningDTO>();
            
            foreach (var item in res)
            {
                var info = new TouristPlanningDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Introduce = Server.HtmlDecode(item.Introduce),
                    SubTime = TimeFormatter.TimeFormat(item.SubTime.ToString()),
                    PlanUnit = item.PlanUnit,
                    PlanLeader = item.PlanLeader,
                    BrowseTime =item.BrowseTime ?? 0,
                    Remark = item.Remark,
                    Latitude=item.Latitude,
                    Longitude=item.Longitude,
                    Location=item.Location,
                    MessageCount=item.MessageCount ?? 0,
                    PlanArea=item.PlanArea,
                    PlanImage=item.PlanImage,
                    PlanTarget=item.PlanTarget,
                    PlanYears=item.PlanYears
                  //  Type = GetInfoType(item.Type ?? 0)
                };
                result.Add(info);
            }
            var jsondata = new
            {
                msg = string.Empty,
                code = Status.success,
                count = data.Count(),
                data = result
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetALLTourismPlanning()
        {

            var dataObj = TouristPlanningService.GetEntities(u => u.DelFlag == 1);
            var res = dataObj.OrderByDescending(x => x.SubTime).ToList();
            var result = new List<TouristPlanningDTO>();

            foreach (var item in res)
            {
                var info = new TouristPlanningDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Introduce = Server.HtmlDecode(item.Introduce),
                    SubTime = TimeFormatter.TimeFormat(item.SubTime.ToString()),
                    PlanUnit = item.PlanUnit,
                    PlanLeader = item.PlanLeader,
                    BrowseTime = item.BrowseTime ?? 0,
                    Remark = item.Remark,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Location = item.Location,
                    MessageCount = item.MessageCount ?? 0,
                    PlanArea = item.PlanArea,
                    PlanImage = item.PlanImage,
                    PlanTarget = item.PlanTarget,
                    PlanYears = item.PlanYears
                    //  Type = GetInfoType(item.Type ?? 0)
                };
                result.Add(info);
            }
            var jsondata = new
            {
                msg = string.Empty,
                code = Status.success,
                count = result.Count(),
                data = result
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetPubicInformationById(int Id)
        {
            var info = new PublicInformationDTO();
            var dataObjs = TouristPlanningService.GetEntities(u => u.Id == Id && u.DelFlag == 1);
            if(dataObjs != null &&dataObjs.Count() > 0)
            {
                var dataObj = dataObjs.FirstOrDefault();
                //info.Id = dataObj.Id;
                //info.Title = dataObj.Title;
                //info.Content = Server.HtmlDecode(dataObj.Content);
                //info.SubTime = TimeFormatter.TimeFormat(dataObj.SubTime.ToString());
                //info.SubUnit = dataObj.SubUnit;
                //info.Author = dataObj.Author;
                //info.BrowseTime = dataObj.BrowseTime ??0;
                //info.Remark = dataObj.Remark;
                //info.Type = GetInfoType(dataObj.Type ?? 0);
                var jsondata = new
                {
                    code = Status.success,
                    count = 1,
                    data = info
                };
                return Json(jsondata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    code = Status.error,
                    count = 0,
                    data = info
                }, JsonRequestBehavior.AllowGet);
            }
          
        }

        public string GetInfoType(int type)
        {
            string result = string.Empty;
            switch (type)
            {
                case 0:
                    result = "新闻";
                    break;
                case 1:
                    result = "公告";
                    break;
                case 2:
                    result = "通报";
                    break;
                default:
                    break;
            }
            return result;
        }
       
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPublicInfo(PublicInformationDTO publicInfomationdto)
        {
            var publicInformation = new PublicInformation();
            publicInformation.Title = publicInfomationdto.Title;
            publicInformation.Type = Int32.Parse(publicInfomationdto.Type);
            publicInformation.Content = Server.HtmlEncode(publicInfomationdto.Content);
            publicInformation.SubUnit = publicInfomationdto.SubUnit;
            publicInformation.Author = publicInfomationdto.Author;
            publicInformation.SubTime = DateTime.Now;
            publicInformation.Remark = string.Empty;
            //string content = Server.HtmlEncode(form["content"]);
            publicInformation.DelFlag = 1;
            //if (ModelState.IsValid)
            //{
            //    TouristPlanningService.Add(publicInformation);
            //}
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPublicInfo(PublicInformationDTO publicInfomationdto)
        {
            var publicInformation = TouristPlanningService.GetEntities(x => x.Id ==
            publicInfomationdto.Id && x.DelFlag == 1).FirstOrDefault() ;
            //publicInformation.Title = publicInfomationdto.Title;
            //publicInformation.Type = Int32.Parse(publicInfomationdto.Type);
            //publicInformation.Content = Server.HtmlEncode(publicInfomationdto.Content);
            //publicInformation.SubUnit = publicInfomationdto.SubUnit;
            //publicInformation.Author = publicInfomationdto.Author;
            //publicInformation.Remark = string.Empty;
            //string content = Server.HtmlEncode(form["content"]);
            if (ModelState.IsValid)
            {
                TouristPlanningService.Update(publicInformation);
            }
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public ActionResult UploadImage()
        {
            HttpPostedFileBase file = Request.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string fileext = Path.GetExtension(fileName);
            string dir = "/UploadImage/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
            Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(dir)));
            string fulldir = dir + MD5Helper.GenerateMD5(fileName) + fileext;
            file.SaveAs(Server.MapPath(fulldir));
            ImageModel imageModel = new ImageModel()
            {
                src = fulldir,
                title = fileName
            };
            var jsondata = new
            {
                code = 0,
                msg = string.Empty,
                data = imageModel
            };
            return Json(jsondata);
        }
        [HttpPost]
        public ActionResult DeletePublicInfo(int Id)
        {

            TouristPlanningService.DeleteSingle(Id);

            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }
    }
}