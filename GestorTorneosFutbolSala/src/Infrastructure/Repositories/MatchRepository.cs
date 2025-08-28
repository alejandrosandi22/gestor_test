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
    public class MatchRepository
    {
        public MatchRepository() { }

        public List<Match> GetAll()
        {
            List<Match> matches = new List<Match>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Match";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Match match = new Match
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        TournamentId = Convert.ToInt32(dr["Tournament_Id"]),
                        HomeTeamId = Convert.ToInt32(dr["Home_Team_Id"]),
                        AwayTeamId = Convert.ToInt32(dr["Away_Team_Id"]),
                        RoundNumber = Convert.ToInt32(dr["Round_Number"]),
                        Location = dr["Location"].ToString(),
                        DateTime = Convert.ToDateTime(dr["Date"]),
                        HomeGoals = Convert.ToInt32(dr["Home_Goals"]),
                        AwayGoals = Convert.ToInt32(dr["Away_Goals"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        IsPlayed = Convert.ToInt32(dr["IsPlayed"])
                    };

                    matches.Add(match);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return matches;
        }

        public List<Match> GetMatchesByTournament(int tournamentId)
        {
            List<Match> matches = new List<Match>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = @"SELECT * FROM Match
                       WHERE Tournament_Id = @TournamentId
                       ORDER BY Round_Number ASC, Date ASC";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@TournamentId", tournamentId);

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Match match = new Match
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        TournamentId = Convert.ToInt32(dr["Tournament_Id"]),
                        HomeTeamId = Convert.ToInt32(dr["Home_Team_Id"]),
                        AwayTeamId = Convert.ToInt32(dr["Away_Team_Id"]),
                        RoundNumber = Convert.ToInt32(dr["Round_Number"]),
                        Location = dr["Location"].ToString(),
                        DateTime = Convert.ToDateTime(dr["Date"]),
                        HomeGoals = Convert.ToInt32(dr["Home_Goals"]),
                        AwayGoals = Convert.ToInt32(dr["Away_Goals"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        IsPlayed = Convert.ToInt32(dr["IsPlayed"])
                    };

                    matches.Add(match);
                }

                connection.Disconnect();
                return matches;
            }
            catch (Exception ex)
            {
                if (matches.Count == 0)
                {
                    return new List<Match>();
                }
                throw new Exception($"Error al obtener partidos del torneo {tournamentId}: {ex.Message}", ex);
            }
        }

        public Match GetById(int ID)
        {
            Match foundMatch = null;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = @"SELECT Id, Tournament_Id, Home_Team_Id, Away_Team_Id, Round_Number, 
                      Location, Date, Home_Goals, Away_Goals, Created_Date, IsPlayed 
               FROM Match WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@Id", ID);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    foundMatch = new Match
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        TournamentId = Convert.ToInt32(dr["Tournament_Id"]),
                        HomeTeamId = Convert.ToInt32(dr["Home_Team_Id"]),
                        AwayTeamId = Convert.ToInt32(dr["Away_Team_Id"]),
                        RoundNumber = Convert.ToInt32(dr["Round_Number"]),
                        Location = dr["Location"].ToString(),
                        DateTime = Convert.ToDateTime(dr["Date"]),
                        HomeGoals = Convert.ToInt32(dr["Home_Goals"]),
                        AwayGoals = Convert.ToInt32(dr["Away_Goals"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        IsPlayed = Convert.ToInt32(dr["IsPlayed"])
                    };
                }
                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return foundMatch;
        }

        public bool Save(Match match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match), "El partido no puede ser nulo.");

            string sql;

            Match existingMatch = GetById(match.Id);

            if (existingMatch != null)
            {
                sql = "UPDATE Match SET " +
                      "Tournament_Id = @TournamentId, " +
                      "Home_Team_Id = @HomeTeamId, " +
                      "Away_Team_Id = @AwayTeamId, " +
                      "Round_Number = @RoundNumber, " +
                      "Location = @Location, " +
                      "Date = @Date, " +
                      "Home_Goals = @HomeGoals, " +
                      "Away_Goals = @AwayGoals, " +
                      "Created_Date = @CreatedDate, " +
                      "IsPlayed = @IsPlayed " +
                      "WHERE Id = @Id";
            }
            else
            {
                sql = "INSERT INTO Match (Id, Tournament_Id, Home_Team_Id, Away_Team_Id, Round_Number, Location, Date, Home_Goals, Away_Goals, Created_Date, IsPlayed) VALUES(@Id, @TournamentId, @HomeTeamId, @AwayTeamId, @RoundNumber, @Location, @Date, @HomeGoals, @AwayGoals, @CreatedDate, @IsPlayed)";
            }

            try
            {
                DBConnection connection = new DBConnection();
                using (SqlCommand command = new SqlCommand(sql, connection.Connect()))
                {
                    command.Parameters.AddWithValue("@Id", match.Id);
                    command.Parameters.AddWithValue("@TournamentId", match.TournamentId);
                    command.Parameters.AddWithValue("@HomeTeamId", match.HomeTeamId);
                    command.Parameters.AddWithValue("@AwayTeamId", match.AwayTeamId);
                    command.Parameters.AddWithValue("@RoundNumber", match.RoundNumber);
                    command.Parameters.AddWithValue("@Location", match.Location ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Date", match.DateTime);
                    command.Parameters.AddWithValue("@HomeGoals", match.HomeGoals);
                    command.Parameters.AddWithValue("@AwayGoals", match.AwayGoals);
                    command.Parameters.AddWithValue("@CreatedDate", match.CreatedDate);
                    command.Parameters.AddWithValue("@IsPlayed", match.IsPlayed);

                    int affectedRows = command.ExecuteNonQuery();
                    connection.Disconnect();
                    return affectedRows == 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Delete(int ID)
        {
            Match existingMatch = GetById(ID);
            if (existingMatch == null)
                throw new KeyNotFoundException($"No se encontró un partido con el ID {ID}.");

            string sql = "DELETE FROM Match WHERE Id = @Id";

            try
            {
                DBConnection connection = new DBConnection();
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@Id", ID);
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
    }
}