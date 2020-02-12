using SDAU.GCT.OA.Common;
using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal.Models
{
    public class TimingActionFilter : ActionFilterAttribute
    {
        //拦截每个action
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetTimer(filterContext, "action").Start();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetTimer(filterContext, "action").Stop();
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            var renderTimer = GetTimer(filterContext, "render");
            renderTimer.Stop();
            var actionTimer = GetTimer(filterContext, "action");
            HttpRequest request = HttpContext.Current.Request;
            var ip = request.UserHostAddress;
            var browser = request.Browser.Type;
            LogHelper.WriteLog_Info($"[{filterContext.RouteData.Values["controller"]}]-" +
                $"[{ filterContext.RouteData.Values["action"]}]," +
                $"执行：{actionTimer.ElapsedMilliseconds}ms," +
                $"渲染：{renderTimer.ElapsedMilliseconds}ms," +
                $"[{ip}],[{browser}]");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            GetTimer(filterContext, "render").Start();
            base.OnResultExecuting(filterContext);
        }
        private Stopwatch GetTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }
            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }
    }
}