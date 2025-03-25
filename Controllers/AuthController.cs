using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TrainingDBase5ticg3.Filters;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.Security;
using TrainingDBase5ticg3.Services;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Controllers
{
    public class AuthController : Controller
    {
        private IClaimManager claimManager;
        private readonly IAuthServices authServices;
        public AuthController()
        {
            claimManager = new ClaimManager();
            authServices = new AuthServices();
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
                return Json(new { success = false,
                    message = "Datos inválidos." });
            }
            authVM.Email = authVM.NombreDeUsuario;
            if (claimManager.SignIn(authVM, true, returnUrl))
            {
                string redirectUrl = Url.Action("Index", "Home"); // Redirección por defecto
                if (!string.IsNullOrEmpty(returnUrl)
                    && Url.IsLocalUrl(returnUrl))
                {
                    redirectUrl = returnUrl;
                }
                return Json(new { success = true, redirectUrl });
            }

            return Json(new { success = false, 
      message = "Error de autenticación. Usuario o contraseña incorrectos." });
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            claimManager.SignOut();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Authorize()]
        public ActionResult ChangePassword() 
        {
            return View();
        }

        [HttpPost]
        [Authorize()]
        public ActionResult ChangePassword(string OldPassword, string NewPassword)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!OldPassword.Equals(NewPassword))
                {
                    if (authServices.UpdatePassword(User.Identity.Name,
                        OldPassword, NewPassword))
                    {
                        return RedirectToAction("Login");
                    }
                   return View();
                }
            }
            return View();
        }

        [HttpGet]
        [ExceptionFilter]
        public ActionResult Account()
        {
            ViewBag.Roles = new
               SelectList(authServices.GetAllRoles(),
               "Id", "Nombre");
            return View();
        }
        [AllowAnonymous]
        [ExceptionFilter]
        [HttpPost]
        public ActionResult Account([Bind(Include = "Email,Password,Roles")] 
        AuthVM authVM, int Roles)
        {
            
            authServices.InsertUser(authVM, Roles);
            return RedirectToAction("Login");
        }
    }
}