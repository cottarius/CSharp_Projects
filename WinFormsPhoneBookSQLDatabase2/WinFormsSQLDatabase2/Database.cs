using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WinFormsSQLDatabase2
{
    class Database
    {
        static string connectionString = @"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=birthdays;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }            
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
