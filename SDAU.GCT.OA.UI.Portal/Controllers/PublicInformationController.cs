
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
    public class PublicInformationController : Controller
    {
        public IPublicInformationService PublicInformationService { get; set; }
       
        [HttpGet]
        public ActionResult GetPubicInformation(int page, int limit, string keyword = "")
        {

            var dataObj = PublicInformationService.GetEntities(u => u.DelFlag == 1);
            var data = new List<PublicInformation>();
            if (keyword.Length > 0)
            {
                data = dataObj.Where(x => x.Title.Contains(keyword)|| x.Author.Contains( keyword )|| x.SubUnit .Contains( keyword)).ToList();
            }
            else
            {
                data = dataObj.ToList();
            }
            var res = data
            .OrderByDescending(x => x.SubTime)
            .Take(limit * page).Skip(limit * (page - 1)).ToList();//进行分页
            var result = new List<PublicInformationDTO>();
            
            foreach (var item in res)
            {
                var info = new PublicInformationDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = Server.HtmlDecode(item.Content),
                    SubTime = TimeFormatter.TimeFormat(item.SubTime.ToString()),
                    SubUnit = item.SubUnit,
                    Author = item.Author,
                    BrowseTime = item.BrowseTime,
                    Remark = item.Remark,
                    Type = GetInfoType(item.Type)
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
        [HttpGet]
        public ActionResult GetPubicInformationByType(int page, int limit, int type)
        {

            var dataObj = PublicInformationService.GetEntities(u => u.DelFlag == 1 && u.Type == type);
            var data = dataObj
            .OrderByDescending(x => x.SubTime)
            .Take(limit * page).Skip(limit * (page - 1)).ToList();//进行分页
            var result = new List<PublicInformationDTO>();

            foreach (var item in data)
            {
                var info = new PublicInformationDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = Server.HtmlDecode(item.Content),
                    SubTime = TimeFormatter.TimeFormat(item.SubTime.ToString()),
                    SubUnit = item.SubUnit,
                    Author = item.Author,
                    BrowseTime = item.BrowseTime,
                    Remark = item.Remark,
                    Type = GetInfoType(item.Type)
                };
                result.Add(info);
            }
            var jsondata = new
            {
                msg = string.Empty,
                code = Status.success,
                count = dataObj.Count(),
                data = result
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPubicInformationById(int Id)
        {
            var info = new PublicInformationDTO();
            var dataObjs = PublicInformationService.GetEntities(u => u.Id == Id && u.DelFlag == 1);
            if(dataObjs != null &&dataObjs.Count() > 0)
            {
                var dataObj = dataObjs.FirstOrDefault();
                info.Id = dataObj.Id;
                info.Title = dataObj.Title;
                info.Content = Server.HtmlDecode(dataObj.Content);
                info.SubTime = TimeFormatter.TimeFormat(dataObj.SubTime.ToString());
                info.SubUnit = dataObj.SubUnit;
                info.Author = dataObj.Author;
                info.BrowseTime = dataObj.BrowseTime;
                info.Remark = dataObj.Remark;
                info.Type = GetInfoType(dataObj.Type);
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
            if (ModelState.IsValid)
            {
                PublicInformationService.Add(publicInformation);
            }
            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPublicInfo(PublicInformationDTO publicInfomationdto)
        {
            var publicInformation = PublicInformationService.GetEntities(x => x.Id ==
            publicInfomationdto.Id && x.DelFlag == 1).FirstOrDefault() ;
            publicInformation.Title = publicInfomationdto.Title;
            publicInformation.Type = Int32.Parse(publicInfomationdto.Type);
            publicInformation.Content = Server.HtmlEncode(publicInfomationdto.Content);
            publicInformation.SubUnit = publicInfomationdto.SubUnit;
            publicInformation.Author = publicInfomationdto.Author;
            publicInformation.Remark = string.Empty;
            //string content = Server.HtmlEncode(form["content"]);
            if (ModelState.IsValid)
            {
                PublicInformationService.Update(publicInformation);
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

            PublicInformationService.DeleteSingle(Id);

            var jsondata = new { Status.code };
            return Json(jsondata, JsonRequestBehavior.AllowGet);

        }

       
        //[HttpPost]
        //public ActionResult DeleteMultiple(List<int> ids)
        //{
        //    UserInfoService.DeleteMultiple(ids);
        //    var jsondata = new { count = ids.Count(), Status.code };
        //    return Json(jsondata, JsonRequestBehavior.AllowGet);
        //}

    }
    class ImageModel
    {
        public string src { get; set; }
        public string title { get; set; }
    }
}