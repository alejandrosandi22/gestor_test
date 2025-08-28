using GestorTorneosFutbolSala.Domain;
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
    /// Controller responsible for managing tournaments (torneos), including details such as category, year, and participants.
    /// </summary>
    /// 

    public class TournamentController
    {
        private readonly TournamentService _service;

        public TournamentController()
        {
            _service = new TournamentService();
        }

        public List<Tournament> GetAllTournaments()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los torneos.", ex);
            }
        }

        public int GetTournamentById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el torneo con ID {id}.", ex);
            }
        }

        public List<Team> GetStandingsByTournament(int tournamentId)
        {
            try
            {
                return _service.GetStandingsByTournament(tournamentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateTournament(Tournament tournament)
        {
            try
            {
                _service.Create(tournament);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el torneo.", ex);
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            try
            {
                _service.Update(tournament);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el torneo.", ex);
            }
        }

        public void DeleteTournament(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el torneo.", ex);
            }
        }
    }
}

