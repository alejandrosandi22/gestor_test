using GestorTorneosFutbolSala.Domain;
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
    /// Responsible for data access operations related to the Tournament entity.
    /// Provides methods to query, insert, update, and delete tournaments
    /// </summary>
    /// 

    public class TournamentRepository
    {
        public TournamentRepository() { }

        public List<Tournament> GetAll()
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Tournament";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Tournament tournament = new Tournament
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        AgeCategory = Convert.ToInt32(dr["Age_Category"]),
                        Year = Convert.ToInt32(dr["Year"]),
                        Gender = (GenderCategoryEnum)Convert.ToInt32(dr["Gender"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        Stage = Convert.ToInt32(dr["Stage"])
                    };

                    tournaments.Add(tournament);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return tournaments;
        }

        public int GetById(int ID)
        {
            int foundId = 0;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM Tournament WHERE Id = " + ID;
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


        public bool Save(Tournament t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t), "El torneo no puede ser nulo.");

            string sql;

            if (GetById(t.Id) != 0)
            {
                sql = "UPDATE Tournament SET " +
                      "Name = '" + t.Name + "', " +
                      "Age_Category = " + t.AgeCategory + ", " +
                      "Year = " + t.Year + ", " +
                      "Gender = " + (int)t.Gender + ", " +
                      "Created_Date = '" + t.CreatedDate.ToString("yyyy-MM-dd") + "', " +
                      "Stage = " + t.Stage + " " +
                      "WHERE Id = " + t.Id;
            }
            else
            {
                sql = "INSERT INTO Tournament VALUES(" +
                      t.Id + ", '" +
                      t.Name + "', " +
                      t.AgeCategory + ", " +
                      t.Year + ", " +
                      (int)t.Gender + ", '" +
                      t.CreatedDate.ToString("yyyy-MM-dd") + "', " +
                      t.Stage + ")";
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

        public List<Team> GetStandingsByTournament(int tournamentId)
        {
            List<Team> standings = new List<Team>();

            try
            {
                DBConnection connection = new DBConnection();

                string sql = @"
            SELECT 
                Id,
                Name,
                Origin_Location,
                Manager,
                Contact_Phone,
                Tournament_Id,
                Created_Date,
                Points,
                Goals_For,
                Goals_Against,
                (Goals_For - Goals_Against) AS GoalDifference
            FROM Team
            WHERE Tournament_Id = @TournamentId
            ORDER BY 
                Points DESC,
                Goals_For DESC,
                (Goals_For - Goals_Against) DESC;";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@TournamentId", tournamentId);

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Team team = new Team
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        OriginLocation = dr["Origin_Location"].ToString(),
                        Manager = dr["Manager"].ToString(),
                        ContactPhone = dr["Contact_Phone"].ToString(),
                        TournamentId = Convert.ToInt32(dr["Tournament_Id"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        Points = Convert.ToInt32(dr["Points"]),
                        GoalsFor = Convert.ToInt32(dr["Goals_For"]),
                        GoalsAgainst = Convert.ToInt32(dr["Goals_Against"]),
                    };

                    standings.Add(team);
                }

                connection.Disconnect();
                return standings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la tabla de posiciones del torneo {tournamentId}: {ex.Message}", ex);
            }
        }


        public bool Delete(int ID)
        {
            if (GetById(ID) == 0)
                throw new KeyNotFoundException($"No se encontró un torneo con el ID {ID}.");

            string sql = "DELETE FROM Tournament WHERE Id = " + ID;

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

        public bool ExistsByName(string name)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(*) FROM Tournament WHERE Name = '" + name + "'";
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