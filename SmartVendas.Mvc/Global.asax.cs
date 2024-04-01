using System.Web.Mvc;
using System.Web.Routing;
using SmartVendas.Application.AutoMapper;
using SmartVendas.Mvc.App_Start;

namespace SmartVendas.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_EndRequest()
        {
            const string contextKey = "ContextManager.Context";
        }
    }
}
