using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TrainingDBase5ticg3.Infraestructura;
using TrainingDBase5ticg3.ViewModels;


namespace TrainingDBase5ticg3.Security
{
	public class ClaimManager: IClaimManager
    {
		public ClaimsIdentity CreateIdentity(AuthVM authVM, bool rememberMe)
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

		public ActionResult SignIn(AuthVM authVM, bool rememberMe , Controller ctx, string _returnurl)
		{
			ActionResult Result;
			string returnUrl = _returnurl;

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

		public void SignOut() 
		{
			var authenticacionManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
			authenticacionManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
	    }

        public bool SignIn(AuthVM authVM, bool rememberMe, string _returnurl)
        {
            
            string returnUrl = _returnurl;
			var identity = CreateIdentity(authVM, rememberMe);
            var authenticacionManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticacionManager.SignIn(new AuthenticationProperties()
            {
                IsPersistent = rememberMe
            }, identity);
    
			return true;
        }

    }
}