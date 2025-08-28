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
    /// Provides business logic operations for fines, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class FineService
    {
        private readonly FineRepository _repository;

        public FineService()
        {
            _repository = new FineRepository();
        }

        public List<Fine> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la multa debe ser mayor que cero.");

            int foundId = _repository.GetById(id);

            if (foundId == 0)
                throw new KeyNotFoundException($"No se encontró una multa con el ID {id}.");

            return foundId;
        }

        public void Create(Fine fine)
        {
            if (fine == null)
                throw new ArgumentNullException(nameof(fine), "La multa no puede ser nula.");

            if (fine.PlayerId <= 0)
                throw new ArgumentException("El ID del jugador asociado debe ser válido.");

            if (fine.PenaltyId <= 0)
                throw new ArgumentException("El ID de la penalidad asociada debe ser válido.");

            if (fine.Amount < 0)
                throw new ArgumentException("El monto de la multa no puede ser negativo.");

            _repository.Save(fine);
        }

        public void Update(Fine updatedFine)
        {
            if (updatedFine == null)
                throw new ArgumentNullException(nameof(updatedFine), "La multa actualizada no puede ser nula.");

            if (_repository.GetById(updatedFine.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe una multa con el ID {updatedFine.Id}.");

            _repository.Save(updatedFine);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la multa debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe una multa con el ID {id}.");

            _repository.Delete(id);
        }
    }
}
