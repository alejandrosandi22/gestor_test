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
    /// Controller responsible for managing incidents (incidentes) related to players and matches.
    /// </summary>
    /// 

    public class IncidentController
    {
        private readonly IncidentService _service;

        public IncidentController()
        {
            _service = new IncidentService();
        }

        public List<Incident> GetAllIncidents()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los incidentes.", ex);
            }
        }

        public int GetIncidentById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el incidente con ID {id}.", ex);
            }
        }

        public void CreateIncident(Incident incident)
        {
            try
            {
                _service.Create(incident);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el incidente.", ex);
            }
        }

        public void UpdateIncident(Incident incident)
        {
            try
            {
                _service.Update(incident);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el incidente.", ex);
            }
        }

        public void DeleteIncident(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el incidente.", ex);
            }
        }
    }
}
