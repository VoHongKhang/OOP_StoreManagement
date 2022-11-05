using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace R2S.Training.Common
{
    internal class Common
    {
            // Connection string
            private const string CONN_STRING = "Data Source=LAPTOP-67D00UBR\\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=true;";

            public static SqlConnection GetSqlConnection()
            {
                SqlConnection conn = new SqlConnection(CONN_STRING);
                return conn;
            }

            public static SqlCommand GetSqlCommand(string query, SqlConnection conn)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                return cmd;
            }
    }
}
