using PartnerManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartnerManagmentApp.Controllers
{
    public class HomeController : Controller
    {
        DapperDB db = new DapperDB();
        public ActionResult Index()
        {
            return View(db.GetPartners());
        }

        public ActionResult Add()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}