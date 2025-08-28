using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
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
    /// Provides business logic operations for incidents, including validation and orchestration of data operations.
    /// </summary>
    ///

    public class IncidentService
    {
        private readonly IncidentRepository _repository;

        public IncidentService()
        {
            _repository = new IncidentRepository();
        }

        public List<Incident> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del incidente debe ser mayor que cero.");

            int foundId = _repository.GetById(id);

            if (foundId == 0)
                throw new KeyNotFoundException($"No se encontró un incidente con el ID {id}.");

            return foundId;
        }

        public void Create(Incident incident)
        {
            if (incident == null)
                throw new ArgumentNullException(nameof(incident), "El incidente no puede ser nulo.");

            if (incident.MatchId <= 0)
                throw new ArgumentException("El ID del partido asociado debe ser válido.");

            if (incident.PlayerId <= 0)
                throw new ArgumentException("El ID del jugador asociado debe ser válido.");

            if (incident.Minute < 0)
                throw new ArgumentException("El minuto del incidente no puede ser negativo.");

            if (!Enum.IsDefined(typeof(IncidentTypeEnum), incident.Type))
                throw new ArgumentException("El tipo de incidente no es válido.");

            _repository.Save(incident);
        }

        public void Update(Incident updatedIncident)
        {
            if (updatedIncident == null)
                throw new ArgumentNullException(nameof(updatedIncident), "El incidente actualizado no puede ser nulo.");

            if (_repository.GetById(updatedIncident.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe un incidente con el ID {updatedIncident.Id}.");

            _repository.Save(updatedIncident);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del incidente debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe un incidente con el ID {id}.");

            _repository.Delete(id);
        }
    }
}

