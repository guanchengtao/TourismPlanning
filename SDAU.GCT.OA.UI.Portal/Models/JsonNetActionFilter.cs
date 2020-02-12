using SDAU.GCT.OA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Models
{
    public class JsonNetActionFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {             //把 filterContext.Result从JsonResult换成JsonNetResult     
                      //filterContext.Result值得就是Action执行返回的ActionResult对象      
            if (filterContext.Result is JsonResult && !(filterContext.Result is JsonNetResult))
            {
                JsonResult jsonResult = (JsonResult)filterContext.Result;
                JsonNetResult jsonNetResult = new JsonNetResult
                {
                    ContentEncoding = jsonResult.ContentEncoding,
                    ContentType = jsonResult.ContentType,
                    Data = jsonResult.Data,
                    JsonRequestBehavior = jsonResult.JsonRequestBehavior,
                    MaxJsonLength = jsonResult.MaxJsonLength,
                    RecursionLimit = jsonResult.RecursionLimit
                };
                filterContext.Result = jsonNetResult;
            }
        }


        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}