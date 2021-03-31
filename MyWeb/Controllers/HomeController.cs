using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MenuLeft()
        {
            List<string> lst = new List<string>();
            lst.Add("Quản lý 1");
            lst.Add("Quản lý 2");
            lst.Add("Quản lý 3");
            return PartialView(lst);
        }
    }
}