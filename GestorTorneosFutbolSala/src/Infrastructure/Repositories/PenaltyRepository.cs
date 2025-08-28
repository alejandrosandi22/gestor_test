using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.src.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.Infrastructure.Repositories
{
    /// <summary>
    /// Responsible for data access operations related to the Penalty entity.
    /// Provides methods to query, insert, update, and delete penalties.
    /// </summary>
    /// 

    public class PenaltyRepository
    {

        public PenaltyRepository() { }


        public List<Penalty> GetAll()
        {
            List<Penalty> penalties = new List<Penalty>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Penalty";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Penalty penalty = new Penalty
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Amount = Convert.ToDecimal(dr["Amount"]),
                        Active = Convert.ToBoolean(dr["Active"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"])
                    };

                    penalties.Add(penalty);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return penalties;
        }


        public int GetById(int ID)
        {
            int foundId = 0;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM Penalty WHERE Id = " + ID;
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    foundId = Convert.ToInt32(dr["Id"].ToString());
                }
                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return foundId;
        }


        public bool Save(Penalty penalty)
        {
            if (penalty == null)
                throw new ArgumentNullException(nameof(penalty), "El penal no puede ser nulo.");

            string sql;

            if (GetById(penalty.Id) != 0)
            {
                sql = "UPDATE Penalty SET " +
                      "Name = '" + penalty.Name + "', " +
                      "Amount = " + penalty.Amount + ", " +
                      "Active = " + (penalty.Active ? 1 : 0) + ", " +
                      "Created_Date = '" + penalty.CreatedDate.ToString("yyyy-MM-dd") + "' " +
                      "WHERE Id = " + penalty.Id;
            }
            else
            {
                sql = "INSERT INTO Penalty VALUES(" +
                       penalty.Id + ", '" +
                       penalty.Name + "', " +
                       penalty.Amount + ", " +
                       (penalty.Active ? 1 : 0) + ", '" +
                       penalty.CreatedDate.ToString("yyyy-MM-dd") + "')";
            }

            try
            {
                DBConnection connection = new DBConnection();
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                int affectedRows = command.ExecuteNonQuery();
                connection.Disconnect();

                return affectedRows == 1;  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Delete(int ID)
        {
            if (GetById(ID) == 0)
                throw new KeyNotFoundException($"No se encontró un penal con el ID {ID}.");

            string sql = "DELETE FROM Penalty WHERE Id = " + ID;

            try
            {
                DBConnection connection = new DBConnection();
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                int affectedRows = command.ExecuteNonQuery();
                connection.Disconnect();

                return affectedRows == 1;  
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool ExistsByName(string name)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(1) FROM Penalty WHERE Name = '" + name + "'";
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                int count = (int)command.ExecuteScalar();
                connection.Disconnect();
                return count > 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }


    }
}
