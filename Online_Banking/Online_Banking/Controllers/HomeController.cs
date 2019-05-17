using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Banking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["Email"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
           
        }

        public ActionResult About()
        {

            if (Session["Email"] != null)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }

        public ActionResult Contact()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Message = "Your contact page.";

            return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Registration");
            }
        }
    }
}