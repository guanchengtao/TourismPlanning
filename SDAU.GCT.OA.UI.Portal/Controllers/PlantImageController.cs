
using SDAU.GCT.OA.IBLL;
using SDAU.GCT.OA.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Controllers
{
    public class PlantImageController : Controller
    {
        public IPlantInfoService PlantInfoService { get; set; }
        public IPlantImageService PlantImageService { get; set; }
        // GET: PlantImage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddImage(int pid)
        {
            HttpPostedFileBase file = Request.Files[0];
            string imgUrl=SaveFile(file);
            PlantInfo plantInfo = PlantInfoService.GetEntities(p => p.Id == pid).FirstOrDefault();
            PlantImage plantImage = new PlantImage()
            {
                Url = imgUrl,
                DelFlag = 1,
                SubTime = DateTime.Now,
                PlantInfoId=pid
            };
            PlantImageService.Add(plantImage);
            var jsondata = new { code = 200 };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }

        private string SaveFile(HttpPostedFileBase file)
        {
            //string fileName = Path.GetFileName(file.FileName);
            //string fileext = Path.GetExtension(fileName);
            //    string dir = "/UploadImage/PlantImage/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
            //    Directory.CreateDirectory(Path.GetDirectoryName(Server.MapPath(dir)));
            //    string fulldir = dir +MD5Helper.GetStringMD5(fileName) + fileext;
            //    file.SaveAs(Server.MapPath(fulldir));
            //    return fulldir;       
            return "";
        }
    }
}