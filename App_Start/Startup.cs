using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;

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
                    LoginPath = new PathString("/Auth/Login")
                });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            
        }
    }
}
