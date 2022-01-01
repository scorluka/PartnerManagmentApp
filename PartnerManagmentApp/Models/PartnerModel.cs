using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartnerManagmentApp.Models
{
    public class PartnerModel
    {
        public int PartnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PartnerNumber { get; set; }
        public int CroatianPIN { get; set; }
        public int PartnerTypeId { get; set; }
        public DateTime CreateAtUtc { get; set; }
        public string CreateByUser { get; set; }
        public Boolean IsForeign { get; set; }
        public string ExtenalCode { get; set; }
        public string Gender { get; set; }
    }
}