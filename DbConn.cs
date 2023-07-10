using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSend
{
   public static class DbConn
    {
        private static string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        public static SqlConnection GetConnecton()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}