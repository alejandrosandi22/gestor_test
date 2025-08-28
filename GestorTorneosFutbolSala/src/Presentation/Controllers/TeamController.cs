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
    /// Controller responsible for managing team (equipo) information and their association with tournaments.
    /// </summary>
    /// 

    public class TeamController
    {
        private readonly TeamService _service;
        
        public TeamController()
        {
            _service = new TeamService();
        }

        public List<Team> GetAllTeams()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los equipos.", ex);
            }
        }

        public List<Team> GetTeamsByTournament(int tournamentId)
        {
            try
            {
                return _service.GetTeamsByTournament(tournamentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Team GetTeamById(int id)
        {
            try
            {
                return _service.GetTeamById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el equipo con ID {id}.", ex);
            }
        }

        public void CreateTeam(Team team)
        {
            try
            {
                _service.Create(team);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el equipo.", ex);
            }
        }

        public bool UpdateTeam(Team team)
        {
            try
            {
                return _service.Update(team);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el equipo.", ex);
            }
        }

        public void DeleteTeam(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el equipo.", ex);
            }
        }
    }
}
