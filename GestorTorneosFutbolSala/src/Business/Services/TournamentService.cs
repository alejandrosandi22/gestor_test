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
    /// Provides business logic operations for tournaments, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class TournamentService
    {
        private readonly TournamentRepository _repository;

        public TournamentService()
        {
            _repository = new TournamentRepository();
        }

        public List<Tournament> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del torneo debe ser mayor que cero.");

            int foundId = _repository.GetById(id);

            if (foundId == 0)
                throw new KeyNotFoundException($"No se encontró un torneo con el ID {id}.");

            return foundId;
        }

        public List<Team> GetStandingsByTournament(int tournamentId)
        {
            try
            {
                return _repository.GetStandingsByTournament(tournamentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Create(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException(nameof(tournament), "El torneo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(tournament.Name))
                throw new ArgumentException("El nombre del torneo es obligatorio.");

            if (tournament.Year < 2000 || tournament.Year > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del torneo no es válido.");

            if (_repository.GetById(tournament.Id) != 0)
                throw new InvalidOperationException($"Ya existe un torneo con el ID {tournament.Id}.");

            if (_repository.ExistsByName(tournament.Name))
                throw new InvalidOperationException($"Ya existe un torneo con el nombre '{tournament.Name}'.");

            _repository.Save(tournament);
        }

        public void Update(Tournament updatedTournament)
        {
            if (updatedTournament == null)
                throw new ArgumentNullException(nameof(updatedTournament), "El torneo actualizado no puede ser nulo.");

            if (_repository.GetById(updatedTournament.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un torneo con el ID {updatedTournament.Id}.");

            _repository.Save(updatedTournament);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del torneo debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un torneo con el ID {id}.");

            _repository.Delete(id);
        }
    }
}
