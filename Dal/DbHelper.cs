using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Dal
{
    public class DbHelper
    {
        static string connStr = ConfigurationManager.ConnectionStrings["A"].ConnectionString;
        public static List<T> GetList<T>(string sql)
        {
            
            try
            {
                using (SqlConnection conn=new SqlConnection(connStr))
                {
                    return conn.Query<T>(sql).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Execute(string sql)
        {
            try
            {
                using (SqlConnection conn=new SqlConnection(connStr))
                {
                    return conn.Execute(sql);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ExecuteScalar(string sql)
        {
            try
            {
                using (SqlConnection conn=new SqlConnection(connStr))
                {
                    return conn.ExecuteScalar<int>(sql);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
