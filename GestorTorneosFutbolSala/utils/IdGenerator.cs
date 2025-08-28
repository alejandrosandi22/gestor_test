using System;
using System.Data.SqlClient;
using GestorTorneosFutbolSala.src.Infrastructure.Data;

namespace GestorTorneosFutbolSala.utils
{
    public static class IdGenerator
    {
        public enum DbTable
        {
            Tournament,
            Team,
            Player,
            Match,
            Incident,
            Penalty,
            Fine,
            User
        }

        public static int GetNextId(DbTable table)
        {
            string tableName = table.ToString();

            DBConnection db = new DBConnection();
            SqlConnection conn = db.Connect();

            if (conn == null)
                throw new Exception("No se pudo establecer conexión con la base de datos.");

            try
            {
                string sql = $"SELECT ISNULL(MAX(Id), 0) + 1 FROM [{tableName}]";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}
