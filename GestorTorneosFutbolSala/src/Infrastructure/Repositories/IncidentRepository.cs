using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
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
    /// Responsible for data access operations related to the Incident entity.
    /// Provides methods to query, insert, update, and delete incidents.
    /// </summary>
    /// 

    public class IncidentRepository
    {
        public IncidentRepository() { }


        public List<Incident> GetAll()
        {
            List<Incident> incidents = new List<Incident>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Incident";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Incident incident = new Incident
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        MatchId = Convert.ToInt32(dr["Match_Id"]),
                        PlayerId = Convert.ToInt32(dr["Player_Id"]),
                        Type = (IncidentTypeEnum)Convert.ToInt32(dr["Type"]),
                        Minute = Convert.ToInt32(dr["Minute"]),
                        Notes = dr["Notes"] == DBNull.Value ? null : dr["Notes"].ToString(),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"])
                    };

                    incidents.Add(incident);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return incidents;
        }


        public int GetById(int ID)
        {
            int foundId = 0;
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM Incident WHERE Id = " + ID;
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

        public bool Save(Incident incident)
        {
            if (incident == null)
                throw new ArgumentNullException(nameof(incident), "El incidente no puede ser nulo.");

            string sql;

            if (GetById(incident.Id) != 0)
            {
                sql = "UPDATE Incident SET " +
                      "Match_Id = " + incident.MatchId + ", " +
                      "Player_Id = " + incident.PlayerId + ", " +
                      "Type = " + (int)incident.Type + ", " +
                      "Minute = " + incident.Minute + ", " +
                      "Notes = '" + incident.Notes + "', " +
                      "Created_Date = '" + incident.CreatedDate.ToString("yyyy-MM-dd") + "' " +
                      "WHERE Id = " + incident.Id;
            }
            else
            {
                sql = "INSERT INTO Incident VALUES(" +
                      incident.Id + ", " +
                      incident.MatchId + ", " +
                      incident.PlayerId + ", " +
                      (int)incident.Type + ", " +
                      incident.Minute + ", '" +
                      incident.Notes + "', '" +
                      incident.CreatedDate.ToString("yyyy-MM-dd") + "')";
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
                throw new KeyNotFoundException($"No se encontró un incidente con el ID {ID}.");

            string sql = "DELETE FROM Incident WHERE Id = " + ID;

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
