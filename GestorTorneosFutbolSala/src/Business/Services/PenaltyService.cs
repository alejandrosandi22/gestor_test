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
    /// Provides business logic operations for penalties, including validation and orchestration of data operations.
    /// </summary>
    /// 

    public class PenaltyService
    {
        private readonly PenaltyRepository _repository;

        public PenaltyService()
        {
            _repository = new PenaltyRepository();
        }

        public List<Penalty> GetAll()
        {
            return _repository.GetAll();
        }

        public int GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la sanción debe ser mayor que cero.");

            int foundId = _repository.GetById(id);

            if (foundId == 0)
                throw new KeyNotFoundException($"No se encontró una sanción con el ID {id}.");

            return foundId;
        }

        public void Create(Penalty penalty)
        {
            if (penalty == null)
                throw new ArgumentNullException(nameof(penalty), "La sanción no puede ser nula.");

            if (string.IsNullOrWhiteSpace(penalty.Name))
                throw new ArgumentException("El nombre de la sanción es obligatorio.");

            if (penalty.Amount <= 0)
                throw new ArgumentException("El monto de la sanción debe ser mayor que cero.");

            if (_repository.GetById(penalty.Id) != 0)
                throw new InvalidOperationException($"Ya existe una sanción con el ID {penalty.Id}.");

            if (_repository.ExistsByName(penalty.Name))
                throw new InvalidOperationException($"Ya existe una penalización con el nombre '{penalty.Name}'.");

            _repository.Save(penalty);
        }

        public void Update(Penalty updatedPenalty)
        {
            if (updatedPenalty == null)
                throw new ArgumentNullException(nameof(updatedPenalty), "La sanción actualizada no puede ser nula.");

            if (_repository.GetById(updatedPenalty.Id) == 0)
                throw new KeyNotFoundException($"No se puede actualizar porque no existe una sanción con el ID {updatedPenalty.Id}.");

            _repository.Save(updatedPenalty);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la sanción debe ser mayor que cero.");

            if (_repository.GetById(id) == 0)
                throw new KeyNotFoundException($"No se puede eliminar porque no existe una sanción con el ID {id}.");

            _repository.Delete(id);
        }
    }
}
