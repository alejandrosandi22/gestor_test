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
    /// Responsible for data access operations related to the Fine entity.
    /// Provides methods to query, insert, update, and delete fines.
    /// </summary>
    /// 

    public class FineRepository
    {
        public FineRepository() { }

        public List<Fine> GetAll()
        {
            List<Fine> fines = new List<Fine>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Fine";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Fine fine = new Fine
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        PlayerId = Convert.ToInt32(dr["Player_Id"]),
                        PenaltyId = Convert.ToInt32(dr["Penalty_Id"]),
                        Date = Convert.ToDateTime(dr["Date"]),
                        Amount = Convert.ToDecimal(dr["Amount"]),
                        Paid = Convert.ToBoolean(dr["Paid"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"])
                    };

                    fines.Add(fine);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return fines;
        }


        public int GetById(int ID)
        {
            int foundId = 0;
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM Fine WHERE Id = " + ID;
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    foundId = Convert.ToInt32(dr["ID"].ToString());
                }
                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return foundId;
        }

        public bool Save(Fine fine)
        {
            if (fine == null)
                throw new ArgumentNullException(nameof(fine), "La multa no puede ser nula.");

            string sql;

            if (GetById(fine.Id) != 0)
            {
                
                sql = "UPDATE Fine SET " +
                      "Player_Id = " + fine.PlayerId + ", " +
                      "Penalty_Id = " + fine.PenaltyId + ", " +
                      "Date = '" + fine.Date.ToString("yyyy-MM-dd") + "', " +
                      "Amount = " + fine.Amount + ", " +
                      "Paid = " + (fine.Paid ? 1 : 0) + ", " +
                      "Created_Date = '" + fine.CreatedDate.ToString("yyyy-MM-dd") + "' " +
                      "WHERE Id = " + fine.Id;
            }
            else
            {
                
                sql = "INSERT INTO Fine VALUES(" +
                      fine.Id + ", " +
                      fine.PlayerId + ", " +
                      fine.PenaltyId + ", '" +
                      fine.Date.ToString("yyyy-MM-dd") + "', " +
                      fine.Amount + ", " +
                      (fine.Paid ? 1 : 0) + ", '" +
                      fine.CreatedDate.ToString("yyyy-MM-dd") + "')";
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
                throw new KeyNotFoundException($"No se encontró una multa con el ID {ID}.");

            string sql = "DELETE FROM Fine WHERE Id = " + ID;

            try
            {
                DBConnection connection = new DBConnection();
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                int affectedRows = command.ExecuteNonQuery();

                return affectedRows == 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    
    }
}
