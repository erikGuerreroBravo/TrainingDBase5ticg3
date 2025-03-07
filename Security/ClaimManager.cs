using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using TrainingDBase5ticg3.ViewModels;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;


namespace TrainingDBase5ticg3.Security
{
	public class ClaimManager
	{
		public static ClaimsIdentity CreateIdentity(AuthVM authVM, bool rememberMe)
		{
			var claims = new List<Claim> {

				new Claim(ClaimTypes.NameIdentifier, authVM.Id.ToString()),
				new Claim(ClaimTypes.Email, authVM.Email),
				new Claim(ClaimTypes.Name,authVM.NombreDeUsuario),
			};
			if (authVM.UsuarioRolVMs != null && authVM.UsuarioRolVMs.Any())
			{
				claims.AddRange(authVM.UsuarioRolVMs.Select(r=> new Claim(ClaimTypes.Role, r.RolVM.Nombre)));
			}
			return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
		}

		public static ActionResult SignIn(AuthVM authVM, bool rememberMe , Controller ctx)
		{
			ActionResult Result;
			string returnUrl = "";

            var identity = CreateIdentity(authVM, rememberMe);
			var authenticacionManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
			authenticacionManager.SignIn(new AuthenticationProperties()
			{
				IsPersistent = rememberMe
			}, identity);
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = ctx.Url.Action("Create", "Personas");
            }
            return new RedirectResult(returnUrl);
        }

		public static void SignOut() 
		{
			var authenticacionManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
			authenticacionManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
	    }



	}
}