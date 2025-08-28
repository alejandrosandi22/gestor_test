using GestorTorneosFutbolSala.src.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Infrastructure.Repositories
{
    /// <summary>
    /// Responsible for data access operations related to tournament reports.
    /// Provides methods to retrieve top scorers, player penalties, 
    /// and team-related statistics for reporting purposes.
    /// </summary>
    /// 

    public class ReportRepository
    {
        public ReportRepository() { }


        public DataTable GetTop10Players()
        {
            try
            {
                DBConnection connection = new DBConnection();

                string sql = "SELECT TOP 10 " +
                             "pla.Id_Number AS CEDULA, " +
                             "pla.FullName AS NOMBRE, " +
                             "tea.Name AS NOMBRE_EQUIPO, " +
                             "pla.Goals_Scored AS CANTIDAD_GOLES " +
                             "FROM Player pla " +
                             "JOIN Team tea ON pla.Team_Id = tea.Id " +
                             "ORDER BY pla.Goals_Scored DESC";

                SqlCommand command = new SqlCommand(sql, connection.Connect());

                SqlDataReader dr = command.ExecuteReader();

                DataTable TopGoleadores = new DataTable();
                TopGoleadores.Load(dr); 

                connection.Disconnect();

                return TopGoleadores;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }

        public DataTable GetPenaltiesByTeam()
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT " +
                             "tea.Name AS NOMBRE_EQUIPO, " +
                             "pla.Id_Number AS CEDULA_JUGADOR, " +
                             "pla.FullName AS NOMBRE_JUGADOR, " +
                             "pen.Name AS SANCION, " +
                             "COUNT(inc.Id) * pen.Amount AS MONTO " +
                             "FROM Incident inc " +
                             "JOIN Player pla ON inc.Player_Id = pla.Id " +
                             "JOIN Penalty pen ON inc.Type = pen.Id " +
                             "JOIN Team tea ON pla.Team_Id = tea.Id " +
                             "GROUP BY tea.Name, pla.Id_Number, pla.FullName, pen.Name, pen.Amount " +
                             "ORDER BY tea.Name, pla.FullName";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                connection.Disconnect();

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public DataTable GetallPenalties()
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT " +
                             "pla.Id_Number AS CEDULA, " +
                             "pla.FullName AS NOMBRE, " +
                             "pen.Name AS SANCION, " +
                             "SUM(fin.Amount) AS MONTO_TOTAL " +
                             "FROM Fine fin " +
                             "JOIN Player pla ON fin.Player_Id = pla.Id " +
                             "JOIN Penalty pen ON fin.Penalty_Id = pen.Id " +
                             "GROUP BY pla.Id_Number, pla.FullName, pen.Name " +
                             "ORDER BY pla.FullName";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                connection.Disconnect();

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public DataTable GetTeamsPositions()
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT " +
                             "tea.Name AS NOMBRE_EQUIPO, " +
                             "SUM( " +
                             "IIF(tea.Id = mat.Home_Team_Id AND mat.Home_Goals > mat.Away_Goals, 3, " +
                             "IIF(tea.Id = mat.Away_Team_Id AND mat.Away_Goals > mat.Home_Goals, 3, " +
                             "IIF((tea.Id = mat.Home_Team_Id OR tea.Id = mat.Away_Team_Id) AND mat.Home_Goals = mat.Away_Goals, 1, 0))) " +
                             ") AS PUNTOS, " +
                             "SUM( " +
                             "IIF(tea.Id = mat.Home_Team_Id, mat.Home_Goals, " +
                             "IIF(tea.Id = mat.Away_Team_Id, mat.Away_Goals, 0)) " +
                             ") AS GOLES " +
                             "FROM Team tea " +
                             "LEFT JOIN Match mat ON tea.Id = mat.Home_Team_Id OR tea.Id = mat.Away_Team_Id " +
                             "GROUP BY tea.Name " +
                             "ORDER BY PUNTOS DESC, GOLES DESC, tea.Name ASC;";

                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                connection.Disconnect();

                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

    }
}
