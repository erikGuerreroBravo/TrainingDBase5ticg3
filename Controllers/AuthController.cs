using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingDBase5ticg3.Filters;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Security;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Controllers
{
    public class AuthController : Controller
    {
        private IClaimManager claimManager;
        public AuthController()
        {
            claimManager = new ClaimManager();
        }

        // GET: Auth
        [HttpGet]
        [ExceptionFilterAttribute]
        [AllowAnonymous]
        public ActionResult Login(string returnurl="")
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Login(AuthVM authVM, string returnUrl)
        {
            if (authVM == null || !ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos." });
            }

            authVM.Email = authVM.NombreDeUsuario;

            if (claimManager.SignIn(authVM, true, returnUrl))
            {
                string redirectUrl = Url.Action("Index", "Home"); // Redirección por defecto
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    redirectUrl = returnUrl;
                }

                return Json(new { success = true, redirectUrl });
            }

            return Json(new { success = false, message = "Error de autenticación. Usuario o contraseña incorrectos." });
        }



    }
}