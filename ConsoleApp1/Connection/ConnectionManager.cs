using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public static class ConnectionManager
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=Week09.2;Integrated Security=True;";

        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection
                    {
                        ConnectionString = connectionString
                    };

                    connection.Open();
                }

                return connection;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error when connecting to database: {e.Message}");
                throw;
            }
        }
    }
}

