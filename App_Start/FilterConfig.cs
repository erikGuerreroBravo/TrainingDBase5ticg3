using System.Web;
using System.Web.Mvc;

namespace TrainingDBase5ticg3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
