using PartnerManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace PartnerManagmentApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var partners = DapperDB.ReturnList<PartnerViewModel>("PartnerViewAll");
            ViewBag.Partners = partners;
            return View();
        }


        //        .. /Employee/AddOrEdit  -insert
        //        .. /Employee/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            
             var PartnerList = new SelectList(DapperDB.GetPartnerList(), "Sifra", "Naziv");
            ViewData["PartnerType"] = PartnerList;
   
            List<SelectListItem> Gender = new List<SelectListItem>() {
                new SelectListItem {
                    Text="Male", Value="M"
                },
                new SelectListItem {
                    Text="Female", Value = "F"
                },
                new SelectListItem {
                    Text="Neutral", Value = "N"
                },
            };
            ViewData["Gender"] = Gender;
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PartnerId", id);
                return View(DapperDB.ReturnList<PartnerModel>("PartnerViewById", param).FirstOrDefault<PartnerModel>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(PartnerModel pm)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@FirstName", pm.FirstName);
            param.Add("@LastName", pm.LastName);
            param.Add("@Address", pm.Address);
            param.Add("@PartnerNumber", pm.PartnerNumber);
            param.Add("@CroatianPIN", pm.CroatianPIN);
            param.Add("@PartnerTypeId", pm.PartnerTypeId);
            param.Add("@CreateByUser", pm.CreateByUser);
            param.Add("@IsForeign", pm.IsForeign);
            param.Add("@ExternalCode", pm.ExternalCode);
            param.Add("@Gender", pm.Gender);
            DapperDB.ExecuteWithoutReturn("PartnerAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", id);
            DapperDB.ExecuteWithoutReturn("PartnerDeleteById", param);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", id);
            var details = DapperDB.ReturnList<PartnerModel>("PartnerViewById", param).FirstOrDefault<PartnerModel>();
            return PartialView("_Details", details);
        }
    }
}