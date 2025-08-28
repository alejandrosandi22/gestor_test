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
    /// Provides business logic operations for matches, including validation and orchestration of data operations.
    /// </summary>
    public class MatchService
    {
        private readonly MatchRepository _repository;

        public MatchService()
        {
            _repository = new MatchRepository();
        }

        public List<Match> GetAll()
        {
            return _repository.GetAll();
        }

        public Match GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del partido debe ser mayor que cero.");

            Match foundMatch = _repository.GetById(id);

            if (foundMatch == null)
                throw new KeyNotFoundException($"No se encontró un partido con el ID {id}.");

            return foundMatch;
        }

        public List<Match> GetMatchesByTournament(int tournamentId)
        {
            try
            {
                return _repository.GetMatchesByTournament(tournamentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Create(Match match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match), "El partido no puede ser nulo.");

            if (match.TournamentId <= 0)
                throw new ArgumentException("El ID del torneo asociado debe ser válido.");

            if (match.HomeTeamId <= 0 || match.AwayTeamId <= 0)
                throw new ArgumentException("Los equipos local y visitante deben tener IDs válidos.");

            if (match.HomeTeamId == match.AwayTeamId)
                throw new ArgumentException("El equipo local y visitante no pueden ser el mismo.");

            if (string.IsNullOrWhiteSpace(match.Location))
                throw new ArgumentException("La ubicación del partido es obligatoria.");

            Match existingMatch = _repository.GetById(match.Id);
            if (existingMatch != null)
                throw new InvalidOperationException($"Ya existe un partido con el ID {match.Id}.");

            _repository.Save(match);
        }

        public void Update(Match updatedMatch)
        {
            if (updatedMatch == null)
                throw new ArgumentNullException(nameof(updatedMatch), "El partido actualizado no puede ser nulo.");

            Match existingMatch = _repository.GetById(updatedMatch.Id);
            if (existingMatch == null)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un partido con el ID {updatedMatch.Id}.");

            _repository.Save(updatedMatch);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del partido debe ser mayor que cero.");

            Match existingMatch = _repository.GetById(id);
            if (existingMatch == null)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un partido con el ID {id}.");

            _repository.Delete(id);
        }
    }
}