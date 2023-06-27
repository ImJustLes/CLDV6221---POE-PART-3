using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLDVPOEPART3.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize (Roles = "Inspector")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This website is for storing and interacting with data from Azure in real time";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}