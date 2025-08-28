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
    /// Responsible for data access operations related to the Player entity.
    /// Provides methods to query, insert, update, and delete players.
    /// </summary>
    /// 

    public class PlayerRepository
    {
        public PlayerRepository() { }

        public List<Player> GetAll()
        {
            List<Player> players = new List<Player>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM Player";
                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Player player = new Player
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdNumber = dr["Id_Number"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"]),
                        TeamId = Convert.ToInt32(dr["Team_Id"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        GoalsScored = Convert.ToInt32(dr["Goals_Scored"]),
                        YellowCards = Convert.ToInt32(dr["Yellow_Cards"]),
                        BlueCards = Convert.ToInt32(dr["Blue_Cards"]),
                        RedCards = Convert.ToInt32(dr["Red_Cards"])
                    };

                    players.Add(player);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return players;
        }

        public List<Player> GetPlayersByTeam(int teamId)
        {
            List<Player> players = new List<Player>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = @"SELECT Id, Id_Number, FullName, BirthDate, Team_Id, Created_Date,
                              Goals_Scored, Yellow_Cards, Blue_Cards, Red_Cards
                       FROM Player
                       WHERE Team_Id = @TeamId";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                command.Parameters.AddWithValue("@TeamId", teamId);

                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Player player = new Player
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        IdNumber = dr["Id_Number"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"]),
                        TeamId = Convert.ToInt32(dr["Team_Id"]),
                        CreatedDate = Convert.ToDateTime(dr["Created_Date"]),
                        GoalsScored = Convert.ToInt32(dr["Goals_Scored"]),
                        YellowCards = Convert.ToInt32(dr["Yellow_Cards"]),
                        BlueCards = Convert.ToInt32(dr["Blue_Cards"]),
                        RedCards = Convert.ToInt32(dr["Red_Cards"])
                    };

                    players.Add(player);
                }

                connection.Disconnect();

                if (players.Count == 0)
                    throw new KeyNotFoundException($"No se encontraron jugadores para el equipo con ID {teamId}.");

                return players;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener jugadores del equipo {teamId}: {ex.Message}", ex);
            }
        }



        public int GetById(int ID)
        {
            int foundId = 0;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM Player WHERE Id = " + ID;
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


        public bool Save(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player), "El jugador no puede ser nulo.");

            string sql;

            if (GetById(player.Id) != 0)
            {
                sql = "UPDATE Player SET " +
                      "Id_Number = '" + player.IdNumber + "', " +
                      "FullName = '" + player.FullName + "', " +
                      "BirthDate = '" + player.BirthDate.ToString("yyyy-MM-dd") + "', " +
                      "Team_Id = " + player.TeamId + ", " +
                      "Created_Date = '" + player.CreatedDate.ToString("yyyy-MM-dd") + "', " +
                      "Goals_Scored = " + player.GoalsScored + ", " +
                      "Yellow_Cards = " + player.YellowCards + ", " +
                      "Blue_Cards = " + player.BlueCards + ", " +
                      "Red_Cards = " + player.RedCards + " " +
                      "WHERE Id = " + player.Id;
            }
            else
            {
                sql = "INSERT INTO Player VALUES(" +
                      player.Id + ", '" +
                      player.IdNumber + "', '" +
                      player.FullName + "', '" +
                      player.BirthDate.ToString("yyyy-MM-dd") + "', " +
                      player.TeamId + ", '" +
                      player.CreatedDate.ToString("yyyy-MM-dd") + "', " +
                      player.GoalsScored + ", " +
                      player.YellowCards + ", " +
                      player.BlueCards + ", " +
                      player.RedCards + ")";
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
                throw new KeyNotFoundException($"No se encontró un jugador con el ID {ID}.");

            string sql = "DELETE FROM Player WHERE Id = " + ID;

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

        public bool ExistsByIdNumber(string idNumber)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(1) FROM Player WHERE IdNumber = '" + idNumber + "'";
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

        public bool ExistsByName(string name)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(*) FROM Player WHERE Name = '" + name + "'";
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
