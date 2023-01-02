using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Database
{    
    internal class DataOperation
    {
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["carsdb"].ConnectionString);
        private void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        private void CloseConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public List<Data> GetAllCars()
        {
            OpenConnection();
            List<Data> cars = new List<Data>();

            string querySelect = "SELECT * FROM cars";
            using (SqlCommand sqlCommand = new SqlCommand(querySelect, connection))
            {
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while(reader.Read())
                {
                    cars.Add(new Data
                    {
                        carID = (int)reader["carId"],
                        carBrand = (string)reader["carBrand"],
                        carModel = (string)reader["carModel"],
                        carColor = (string)reader["carColor"],
                        release = (int)reader["release"]
                    });
                }
                reader.Close();
            }
            return cars;

        }
        public void InsertCar()
        {
            Data car = new Data();
            Console.WriteLine("*******Insert new Car*******");
            Console.Write("Enter Car brand: ");
            car.carBrand = Console.ReadLine();
            Console.Write("Enter Car Model: ");
            car.carModel = Console.ReadLine();
            Console.Write("Enter Car color: ");
            car.carColor = Console.ReadLine();
            Console.Write("Enter car release: ");
            car.release = Convert.ToInt32(Console.ReadLine());
            OpenConnection();
            string queryInsert = "INSERT INTO cars (carBrand, carModel, carColor, release) VALUES (@carBrand, @carModel, @carColor, @release)";

            using (SqlCommand sqlCommand = new SqlCommand(queryInsert, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@carBrand",
                    Value = car.carBrand,
                    SqlDbType = SqlDbType.NVarChar,                   
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@carModel",
                    Value = car.carModel,
                    SqlDbType = SqlDbType.NVarChar,                    
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@carColor",
                    Value = car.carColor,
                    SqlDbType = SqlDbType.NVarChar,                    
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@release",
                    Value = car.release,
                    SqlDbType = SqlDbType.Int,                    
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
                CloseConnection();
                Console.WriteLine("Succesfull!");
            }
        }

        public void DeleteCar()
        {            
            Console.Write("Enter car Id to delete car: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            OpenConnection();
            string queryDelete = $"DELETE FROM cars WHERE carId = {carId}";
            string queryCheck = "DBCC CHECKIDENT ('[cars]', RESEED, 0)";
            using (SqlCommand sqlCommand = new SqlCommand(queryDelete, connection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Succesfully deleted!");
                }
                catch (Exception ex)
                {
                    Exception error = new Exception("Error!", ex);
                    throw error;
                }                
            }
            using (SqlCommand sqlCommand = new SqlCommand(queryCheck, connection))
            {
                try
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Succesfully checked!");
                }
                catch (Exception ex)
                {
                    Exception error = new Exception("Error!", ex);
                    throw error;
                }
            }
            CloseConnection();
        }
        public void InsertCustomer()
        {
            Data customer = new Data();
            OpenConnection();
            string queryInsert = "INSERT INTO customers (lastName, firstName, born, phone, carId) VALUES (@lastName, @firstName, @born, @phone, @carId)";

            using(SqlCommand sqlCommand = new SqlCommand(queryInsert, connection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@lastName",
                    Value = customer.customerLastName,
                    SqlDbType = SqlDbType.NVarChar
                };
                sqlCommand.Parameters.Add(parameter);
            }
        }
    }
}
