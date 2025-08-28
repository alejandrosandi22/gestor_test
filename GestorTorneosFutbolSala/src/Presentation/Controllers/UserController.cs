using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Services;
using GestorTorneosFutbolSala.src.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.src.Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for managing users (usuarios), including roles, authentication, and access control.
    /// </summary>
    /// 

    public class UserController
    {
	    private readonly UserService _service;

        public UserController()
	    {
		    _service = new UserService();
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los usuarios.", ex);
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el usuario con ID {id}.", ex);
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                _service.Create(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario.", ex);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _service.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario.", ex);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario.", ex);
            }
        }

        public User Authenticate(string username, string password)
        {
            try
            {
                var user = _service.GetAll()
                                   .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user == null)
                    throw new Exception("Usuario o contraseña incorrectos.");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la autenticación.", ex);
            }
        }

    }
}
