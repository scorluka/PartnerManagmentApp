using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartnerManagmentApp.Models
{
    public class PartnerViewModel
    {
        public string FullName { get; set; }
        [RegularExpression(@"^([0-9]{20})$", ErrorMessage = "Mora biti točno 20 znamenki")]
        public string PartnerNumber { get; set; }
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Mora biti 11 znamenki")]
        public string CroatianPIN { get; set; }
        public int PartnerTypeId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAtUtc { get; set; }
        public Boolean IsForeign { get; set; }
        public string Gender { get; set; }
    }
}