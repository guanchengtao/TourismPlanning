
using SDAU.GCT.OA.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace SDAU.GCT.OA.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           // filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptiomFilterAttr());
            //重写Json()方法
            //filters.Add(new JsonNetActionFilter());
          //  filters.Add(new TimingActionFilter());
            //  filters.Add(new LoginCheckFilterAttr() { IsCheck=true});
            //异常过滤器
        }
    }
}
