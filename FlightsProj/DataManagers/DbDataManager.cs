using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace FlightsProj.DataManagers
{
    public class DbDataManager : IDataManager, IDisposable
    {
        MySqlConnection _sqlConnection;

        public DbDataManager()
        {
            _sqlConnection = new MySqlConnection(ConfigurationManager.AppSettings["server"] + ConfigurationManager.AppSettings["user"] + ConfigurationManager.AppSettings["password"] + ConfigurationManager.AppSettings["database"]);
            _sqlConnection.Open();
        }

        public void Save(string departureLocation, string arrivalLocation, string departureDate, string arrivalDate, string price, string currency)
        {
            MySqlCommand sqlCommand = new MySqlCommand();
            sqlCommand.Connection = _sqlConnection;
            sqlCommand.CommandText = "INSERT INTO vs_output(location1, location2, departureDate, arrivalDate, price, currency" + " VALUES(@loc1, @loc2, @departure, @arrival, @price, @currency)";

            sqlCommand.Parameters.AddWithValue("loc1", departureLocation);
            sqlCommand.Parameters.AddWithValue("loc2", arrivalLocation);
            sqlCommand.Parameters.AddWithValue("departure", departureDate);
            sqlCommand.Parameters.AddWithValue("arrival", arrivalDate);
            sqlCommand.Parameters.AddWithValue("price", price);
            sqlCommand.Parameters.AddWithValue("currency", currency);

            sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}
