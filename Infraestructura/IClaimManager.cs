using System.Security.Claims;
using System.Web.Mvc;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Infraestructura
{
    public interface IClaimManager
    {
        ClaimsIdentity CreateIdentity(AuthVM authVM, bool rememberMe);
        ActionResult SignIn(AuthVM authVM, bool rememberMe, Controller ctx, string _returnurl);
        bool SignIn(AuthVM authVM, bool rememberMe, string _returnurl);
        void SignOut();
    }
}
