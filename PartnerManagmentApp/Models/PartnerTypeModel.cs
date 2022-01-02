using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartnerManagmentApp.Models
{
    public class PartnerTypeModel
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public SelectList PartnerList { get; set; }
    }
}