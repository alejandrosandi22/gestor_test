using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Services
{
    /// <summary>
    /// Provides business logic operations for players, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class PlayerService
    {
        private readonly PlayerRepository _repository;

        public PlayerService()
        {
            _repository = new PlayerRepository();
        }

        public List<Player> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del jugador debe ser mayor que cero.");

            int foundId = _repository.GetById(id);

            if (foundId == 0)
                throw new KeyNotFoundException($"No se encontró un jugador con el ID {id}.");

            return foundId;
        }

        public List<Player> GetPlayersByTeam(int teamId)
        {
            try
            {
                return _repository.GetPlayersByTeam(teamId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Create(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player), "El jugador no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(player.FullName))
                throw new ArgumentException("El nombre completo del jugador es obligatorio.");

            if (string.IsNullOrWhiteSpace(player.IdNumber))
                throw new ArgumentException("El número de identificación del jugador es obligatorio.");

            if (player.BirthDate == default)
                throw new ArgumentException("La fecha de nacimiento del jugador es obligatoria.");

            if (player.TeamId <= 0)
                throw new ArgumentException("El ID del equipo al que pertenece el jugador es obligatorio y debe ser mayor que cero.");

            if (_repository.ExistsByIdNumber(player.IdNumber))
                throw new InvalidOperationException($"Ya existe un jugador con el número de identificación '{player.IdNumber}'.");

            _repository.Save(player);
        }

        public void Update(Player updatedPlayer)
        {
            if (updatedPlayer == null)
                throw new ArgumentNullException(nameof(updatedPlayer), "El jugador actualizado no puede ser nulo.");

            if (_repository.GetById(updatedPlayer.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un jugador con el ID {updatedPlayer.Id}.");

            _repository.Save(updatedPlayer);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del jugador debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un jugador con el ID {id}.");

            _repository.Delete(id);
        }

    }
}
