using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class PenaltyValidator
    {
        public static void Validate(Penalty penalty)
        {
            if (penalty == null)
                throw new ArgumentNullException(nameof(penalty), "La penalización no puede ser nula.");

            if (string.IsNullOrWhiteSpace(penalty.Name))
                throw new ArgumentException("El nombre de la penalización es obligatorio.");

            if (penalty.Amount <= 0)
                throw new ArgumentException("El monto de la penalización debe ser mayor que cero.");
        }

        public static void ValidateNameDoesNotExist(string name, PenaltyRepository repository)
        {
            if (repository.ExistsByName(name))
                throw new InvalidOperationException($"Ya existe una penalización con el nombre '{name}'.");
        }
    }
}

