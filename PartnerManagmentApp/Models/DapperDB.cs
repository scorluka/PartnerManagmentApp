using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace PartnerManagmentApp.Models
{
    public class DapperDB
    {
        SqlConnection conn = new SqlConnection("Data Source=STJEPAN\\SQLEXPRESS;Initial Catalog=Partner_Managment;Integrated Security=True");

        public List<PartnerModel> GetPartners()
        {
            var Partners = conn.Query<PartnerModel>("select * from Partners");
            return Partners.ToList();
        }
    }
}