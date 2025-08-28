using GestorTorneosFutbolSala.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.Domain
{

    /// <summary>
    /// Represents a user of the system with authentication and role information.
    /// </summary>
    public class User
    {
        private int id;
        private string name;
        private string username;
        private string password;
        private UserRoleEnum role;

        public User()
        { }

        public User(int id, string name, string username, string password, UserRoleEnum role)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public UserRoleEnum Role { get => role; set => role = value; }
    }
}
