using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(TrainingDBase5ticg3.App_Start.Startup))]

namespace TrainingDBase5ticg3.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() {

                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Auth/Login"),
                    ExpireTimeSpan = TimeSpan.FromMinutes(30),  // Expira en 30 minutos
                    SlidingExpiration = true,  // Renueva sesión al interactuar
                    CookieHttpOnly = true,  // Previene accesos desde JavaScript
                    CookieSecure = CookieSecureOption.SameAsRequest, // HTTPS si la petición es segura
                    CookieSameSite = Microsoft.Owin.SameSiteMode.Strict // P
                });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}
