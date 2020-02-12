using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SDAU.GCT.OA.UI.Portal
{
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication 
       // System.Web.HttpApplication
       //Spring.Net对代码侵入性很大
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //注册过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
