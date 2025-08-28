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
    /// Provides business logic operations for teams, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class TeamService
    {
        private readonly TeamRepository _repository;

        public TeamService()
        {
            _repository = new TeamRepository();
        }

        public List<Team> GetAll()
        {
            return _repository.GetAll();
        }

        public Team GetTeamById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del equipo debe ser mayor que cero.");

            return _repository.GetTeamById(id);
        }

        public List<Team> GetTeamsByTournament(int tournamentId)
        {
            try
            {
                return _repository.GetTeamsByTournament(tournamentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void Create(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

            if (string.IsNullOrWhiteSpace(team.Name))
                throw new ArgumentException("El nombre del equipo es obligatorio.");

            Team existingTeam = _repository.GetTeamById(team.Id);
            if (existingTeam != null)
            {
                throw new InvalidOperationException($"Ya existe un equipo con el ID {team.Id}.");
            }

            if (_repository.ExistsByName(team.Name))
            {
                throw new InvalidOperationException($"Ya existe un equipo con el nombre '{team.Name}'.");
            }

            _repository.Save(team);
        }

        public bool Update(Team updatedTeam)
        {
            if (updatedTeam == null)
                throw new ArgumentNullException(nameof(updatedTeam), "El equipo actualizado no puede ser nulo.");

            try
            {
                _repository.GetTeamById(updatedTeam.Id);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un equipo con el ID {updatedTeam.Id}.");
            }

            return _repository.Save(updatedTeam);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del equipo debe ser mayor que cero.");

            try
            {
                _repository.GetTeamById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un equipo con el ID {id}.");
            }

            _repository.Delete(id);
        }
    }
}
