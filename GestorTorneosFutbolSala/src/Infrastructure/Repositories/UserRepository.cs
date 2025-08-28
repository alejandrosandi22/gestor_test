using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.src.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Infrastructure.Repositories
{
    public class UserRepository
    {
        public UserRepository() { }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM [User]";
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Username = dr["Username"].ToString(),
                        Password = dr["Password"].ToString(),
                        Role = (UserRoleEnum)Convert.ToInt32(dr["Role"])
                    };

                    users.Add(user);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

            return users;
        }

        public int GetById(int ID)
        {
            int foundId = 0;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT Id FROM [User] WHERE Id = " + ID;
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    foundId = Convert.ToInt32(dr["Id"]);
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return foundId;
        }

        public User GetUserById(int ID)
        {
            User user = null;

            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT * FROM [User] WHERE Id = " + ID;
                SqlCommand command = new SqlCommand(sql, connection.Connect());
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Username = dr["Username"].ToString(),
                        Password = dr["Password"].ToString(),
                        Role = (UserRoleEnum)Convert.ToInt32(dr["Role"])
                    };
                }

                connection.Disconnect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return user;
        }

        public bool ExistsByUsername(string username)
        {
            try
            {
                DBConnection connection = new DBConnection();
                string sql = "SELECT COUNT(*) FROM [User] WHERE Username = '" + username + "'";
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

        public bool Save(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");

            string sql;

            if (GetById(user.Id) != 0)
            {
                sql = "UPDATE [User] SET " +
                      "Name = '" + user.Name + "', " +
                      "Username = '" + user.Username + "', " +
                      "Password = '" + user.Password + "', " +
                      "Role = " + (int)user.Role + " " +
                      "WHERE Id = " + user.Id;
            }
            else
            {
                sql = "INSERT INTO [User] (Id, Name, Username, Password, Role) VALUES(" +
                      user.Id + ", '" +
                      user.Name + "', '" +
                      user.Username + "', '" +
                      user.Password + "', " +
                      (int)user.Role + ")";
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
                throw new KeyNotFoundException($"No se encontró un usuario con el ID {ID}.");

            string sql = "DELETE FROM [User] WHERE Id = " + ID;

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
    }
}