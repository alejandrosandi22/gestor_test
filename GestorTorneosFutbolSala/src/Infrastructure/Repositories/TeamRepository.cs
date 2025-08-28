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
    /// Responsible for data access operations related to the Team entity.
    /// Provides methods to query, insert, update, and delete teams
    /// </summary>
    /// 
    public class TeamRepository
    {
        public TeamRepository() { }

        public List<Team> GetAll()
        {
            List<Team> teams = new List<Team>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Team";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

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
                        GoalsAgainst = Convert.ToInt32(dr["Goals_Against"])
                    };

                    teams.Add(team);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return teams;
        }

        public List<Team> GetTeamsByTournament(int tournamentId)
        {
            List<Team> teams = new List<Team>();


            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id, Name, Origin_Location, Manager, Contact_Phone, Tournament_Id, Created_Date," +
                       " Points, Goals_For, Goals_Against" +
                       " FROM Team" +
                       " WHERE Tournament_Id = " + tournamentId;

                SqlCommand command = new SqlCommand(sql, connection.Connect());

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
                        GoalsAgainst = Convert.ToInt32(dr["Goals_Against"])
                    };

                    teams.Add(team);
                }

                connection.Disconnect();

                if (teams.Count == 0)
                    throw new KeyNotFoundException($"No se encontraron equipos para el torneo con ID {tournamentId}.");

                return teams;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener equipos del torneo {tournamentId}: {ex.Message}", ex);
            }
        }


        public Team GetTeamById(int id)
        {
            DBConnection connection = new DBConnection();
            try
            {
                string sql = @"
            SELECT Id, Name, Origin_Location, Manager, Contact_Phone, 
                   Tournament_Id, Created_Date, Points, Goals_For, Goals_Against
            FROM Team
            WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
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
                        GoalsAgainst = Convert.ToInt32(dr["Goals_Against"])
                    };

                    dr.Close();
                    connection.Disconnect();
                    return team;
                }
                else
                {
                    dr.Close();
                    connection.Disconnect();
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Disconnect();
                    }
                    catch {  }
                }
                throw new Exception($"Error al obtener el equipo con ID {id}: {ex.Message}", ex);
            }
        }


        public bool Save(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

            DBConnection connection = null;
            SqlCommand command = null;

            try
            {
                bool isUpdate = GetTeamById(team.Id) != null;

                string sql = isUpdate
                    ? @"UPDATE Team SET 
                   Name = @Name, 
                   Origin_Location = @OriginLocation, 
                   Manager = @Manager, 
                   Contact_Phone = @ContactPhone, 
                   Tournament_Id = @TournamentId, 
                   Created_Date = @CreatedDate, 
                   Points = @Points, 
                   Goals_For = @GoalsFor, 
                   Goals_Against = @GoalsAgainst 
               WHERE Id = @Id"
                    : @"INSERT INTO Team (
                   Id, Name, Origin_Location, Manager, Contact_Phone, 
                   Tournament_Id, Created_Date, Points, Goals_For, Goals_Against
               ) VALUES (
                   @Id, @Name, @OriginLocation, @Manager, @ContactPhone, 
                   @TournamentId, @CreatedDate, @Points, @GoalsFor, @GoalsAgainst
               )";

                connection = new DBConnection();
                command = new SqlCommand(sql, connection.Connect());

                command.Parameters.AddWithValue("@Id", team.Id);
                command.Parameters.AddWithValue("@Name", team.Name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@OriginLocation", team.OriginLocation ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Manager", team.Manager ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@ContactPhone", team.ContactPhone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@TournamentId", team.TournamentId);
                command.Parameters.AddWithValue("@CreatedDate", team.CreatedDate);
                command.Parameters.AddWithValue("@Points", team.Points);
                command.Parameters.AddWithValue("@GoalsFor", team.GoalsFor);
                command.Parameters.AddWithValue("@GoalsAgainst", team.GoalsAgainst);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                string operation = GetTeamById(team.Id) != null ? "actualizar" : "crear";
                throw new Exception($"Error al {operation} el equipo '{team.Name}': {ex.Message}", ex);
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.Disconnect();
                    }
                    catch { }
                }
            }
        }


        public bool Delete(int ID)
        {
            Team team = GetTeamById(ID);

            string sql = "DELETE FROM Team WHERE Id = @Id";

            try
            {
                DBConnection connection = new DBConnection();
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@Id", ID);

                int affectedRows = command.ExecuteNonQuery();
                connection.Disconnect();

                return affectedRows == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el equipo con ID {ID}: {ex.Message}", ex);
            }
        }


        public bool ExistsByName(string name)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(*) FROM Team WHERE Name = '" + name + "'";
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
