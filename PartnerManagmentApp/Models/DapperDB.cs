using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace PartnerManagmentApp.Models
{
    public static class DapperDB
    {
        private static string connectionString = @"Data Source=STJEPAN\SQLEXPRESS;Initial Catalog=Partner_Managment;Integrated Security=True;";


        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }

        }

        //DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }

        //DapperORM.ReturnList<EmployeeModel> <=  IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }

        }
        public static IEnumerable<PartnerTypeModel> GetPartnerList()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "SELECT [Sifra],[Naziv]FROM [Partner_Type]";
                var result = sqlCon.Query<PartnerTypeModel>(query);
                return result;
            }
        }

    }
    
}