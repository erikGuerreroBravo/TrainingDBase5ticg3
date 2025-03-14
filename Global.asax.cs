using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TrainingDBase5ticg3.App_Start;
using TrainingDBase5ticg3.Mapping;

namespace TrainingDBase5ticg3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
       
            var owinStartup = typeof( TrainingDBase5ticg3.App_Start.Startup);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ///configuramos el automapper para que se ejecute junto con la aplicacion
            WebProfile.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier =
                System.Security.Claims.ClaimTypes.NameIdentifier;
        }
    }
}
