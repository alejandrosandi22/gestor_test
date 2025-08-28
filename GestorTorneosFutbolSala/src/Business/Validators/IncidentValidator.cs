using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class IncidentValidator
    {
        public static void Validate(Incident incident)
        {
            if (incident == null)
                throw new ArgumentNullException(nameof(incident), "El incidente no puede ser nulo.");

            if (incident.MatchId <= 0)
                throw new ArgumentException("El ID del partido asociado debe ser válido.");

            if (incident.PlayerId <= 0)
                throw new ArgumentException("El ID del jugador asociado debe ser válido.");

            if (!Enum.IsDefined(typeof(IncidentTypeEnum), incident.Type))
                throw new ArgumentException("El tipo de incidente no es válido.");

            if (incident.Minute < 0 || incident.Minute > 120)
                throw new ArgumentException("El minuto del incidente debe estar entre 0 y 120.");
        }
    }
}
