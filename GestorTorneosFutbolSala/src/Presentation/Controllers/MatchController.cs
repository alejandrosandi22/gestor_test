using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.src.Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling CRUD operations and data access for matches (partidos) in the system.
    /// </summary>
    /// 

    public class MatchController
    {
        private readonly MatchService _service;

        public MatchController()
        {
            _service = new MatchService();
        }

        public List<Match> GetAllMatches()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los partidos.", ex);
            }
        }

        public Match GetMatchById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el partido con ID {id}.", ex);
            }
        }

        public List<Match> GetMatchesByTournament(int tournamentId)
        {
            try
            {
                return _service.GetMatchesByTournament(tournamentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateMatch(Match match)
        {
            try
            {
                _service.Create(match);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el partido.", ex);
            }
        }

        public void UpdateMatch(Match match)
        {
            try
            {
                _service.Update(match);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el partido.", ex);
            }
        }

        public void DeleteMatch(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el partido.", ex);
            }
        }
    }
}
