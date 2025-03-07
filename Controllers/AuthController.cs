using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(AuthVM authVM, string returnurl) {

            ActionResult result;
            if (authVM != null)
            {
                result = claimManager.SignIn(authVM, true, this, returnurl);
            }
            else 
            {
                return View();
            }
            return result;
        }


    }
}