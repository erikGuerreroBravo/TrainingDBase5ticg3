using NLog;
using System;
using System.Web.Mvc;

namespace TrainingDBase5ticg3.Filters
{
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            // Captura la excepción
            Exception ex = filterContext.Exception;
            // Loguea la excepción en NLog
            Logger.Error(ex,
                "Ocurrió una excepción en el controlador: " +
                filterContext.RouteData.Values["controller"] +
                               " Acción: " + 
                               filterContext.RouteData.Values["action"]);

            // Configurar la respuesta HTTP
            filterContext.Result = new ViewResult
            {
                ViewName = "Error" // Vista personalizada de error
            };

            filterContext.ExceptionHandled = true;
        }
    }
}