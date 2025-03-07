using System.Web;
using System.Web.Mvc;
using TrainingDBase5ticg3.Filters;

namespace TrainingDBase5ticg3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilterAttribute());
        }
    }
}
