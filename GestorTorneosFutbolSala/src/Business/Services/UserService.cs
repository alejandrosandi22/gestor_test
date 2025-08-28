using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.src.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.src.Business.Services
{
    /// <summary>
    /// Provides business logic operations for users, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class UserService
    {
        private readonly UserRepository _repository;

    public UserService()
        {
            _repository = new UserRepository();
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor que cero.");

            var user = _repository.GetAll().Find(u => u.Id == id);

            if (user == null)
                throw new KeyNotFoundException($"No se encontró un usuario con el ID {id}.");

            return user;
        }

        public void Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (_repository.GetById(user.Id) != 0)
                throw new InvalidOperationException($"Ya existe un usuario con el ID {user.Id}.");

            if (_repository.ExistsByUsername(user.Username))
                throw new InvalidOperationException($"Ya existe un usuario con el nombre de usuario '{user.Username}'.");

            _repository.Save(user);
        }

        public void Update(User updatedUser)
        {
            if (updatedUser == null)
                throw new ArgumentNullException(nameof(updatedUser), "El usuario actualizado no puede ser nulo.");

            if (_repository.GetById(updatedUser.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un usuario con el ID {updatedUser.Id}.");

            _repository.Save(updatedUser);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del usuario debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un usuario con el ID {id}.");

            _repository.Delete(id);
        }
    }
}
