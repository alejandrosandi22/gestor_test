using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Infrastructure.Data
{
    public class DBConnection
    {
        SqlConnection _sqlConnection;
        private readonly string connectionString;

        public DBConnection()
        {
            connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            _sqlConnection = new SqlConnection(connectionString);
        }


        public SqlConnection Connect()
        {
            try
            {
                _sqlConnection.Open();
                return _sqlConnection;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al conectar a la base de datos:\n{ex.Message}", "Error de conexión");
                return null;
            }
        }

        public bool Disconnect()
        {
            try
            {
                _sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
