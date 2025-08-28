using GestorTorneosFutbolSala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class FineValidator
    {
        public static void Validate(Fine fine)
        {
            if (fine == null)
                throw new ArgumentNullException(nameof(fine), "La multa no puede ser nula.");

            if (fine.PlayerId <= 0)
                throw new ArgumentException("El ID del jugador asociado debe ser válido.");

            if (fine.PenaltyId <= 0)
                throw new ArgumentException("El ID de la penalización debe ser válido.");

            if (fine.Date == default)
                throw new ArgumentException("La fecha de la multa debe ser válida.");

            if (fine.Amount < 0)
                throw new ArgumentException("El monto de la multa no puede ser negativo.");

            if (fine.CreatedDate == default)
                throw new ArgumentException("La fecha de creación debe ser válida.");
        }
    }
}
