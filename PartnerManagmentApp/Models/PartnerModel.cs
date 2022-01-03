using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartnerManagmentApp.Models
{
    public class PartnerModel
    {
        public string FullName { get; set; }
        public int PartnerId { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^([0-9]{20})$", ErrorMessage = "Mora biti točno 20 znamenki")]
        public string PartnerNumber { get; set; }
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Mora biti 11 znamenki")]
        public string CroatianPIN { get; set; }
        public int PartnerTypeId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAtUtc { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CreateByUser { get; set; }
        public Boolean IsForeign { get; set; }
        [MaxLength(20), MinLength(10)]
        public string ExternalCode { get; set; }
        public string Gender { get; set; }
    }
}