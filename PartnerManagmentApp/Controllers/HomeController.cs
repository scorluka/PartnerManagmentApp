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
            return View(DapperDB.ReturnList<PartnerModel>("PartnerViewAll"));
        }


        //        .. /Employee/AddOrEdit  -insert
        //        .. /Employee/AddOrEdit/id
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            var PartnerType = new SelectList(DapperDB.GetPartnerList());
            ViewData["PartnerType"] = PartnerType;
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
            param.Add("@Name", pm.FirstName);
            param.Add("@LasnName", pm.LastName);
            param.Add("@Address", pm.Address);
            param.Add("@PartnerNumber", pm.PartnerNumber);
            param.Add("@CroatianPIN", pm.CroatianPIN);
            param.Add("@PartnerTypeId", pm.PartnerTypeId);
            param.Add("@CreateAtUtc", pm.CreateAtUtc);
            param.Add("@CreateByUser", pm.CreateByUser);
            param.Add("@IsForeign", pm.IsForeign);
            param.Add("@ExtenalCode", pm.ExtenalCode);
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
    }
}