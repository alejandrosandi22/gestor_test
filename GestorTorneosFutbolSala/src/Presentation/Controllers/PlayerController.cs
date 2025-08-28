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
    /// Controller responsible for managing player (jugador) information, including statistics and personal data.
    /// </summary>
    public class PlayerController
    {
        private readonly PlayerService _service;

        public PlayerController()
        {
            _service = new PlayerService();
        }

        public List<Player> GetAllPlayers()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los jugadores.", ex);
            }
        }

        public List<Player> GetPlayersByTeam(int teamId)
        {
            try
            {
                return _service.GetPlayersByTeam(teamId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetPlayerById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el jugador con ID {id}.", ex);
            }
        }

        public void CreatePlayer(Player player)
        {
            try
            {
                _service.Create(player);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el jugador.", ex);
            }
        }

        public void UpdatePlayer(Player player)
        {
            try
            {
                _service.Update(player);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el jugador.", ex);
            }
        }

        public void DeletePlayer(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el jugador.", ex);
            }
        }
    }
}
