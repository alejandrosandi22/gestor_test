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
    /// Controller responsible for managing penalties (penales) available in the tournament.
    /// </summary>
    /// 

    public class PenaltyController
    {
        private readonly PenaltyService _service;

        public PenaltyController()
        {
            _service = new PenaltyService();
        }

        public List<Penalty> GetAllPenalties()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las penalizaciones.", ex);
            }
        }

        public int GetPenaltyById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la penalización con ID {id}.", ex);
            }
        }

        public void CreatePenalty(Penalty penalty)
        {
            try
            {
                _service.Create(penalty);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la penalización.", ex);
            }
        }

        public void UpdatePenalty(Penalty penalty)
        {
            try
            {
                _service.Update(penalty);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la penalización.", ex);
            }
        }

        public void DeletePenalty(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la penalización.", ex);
            }
        }
    }
}
