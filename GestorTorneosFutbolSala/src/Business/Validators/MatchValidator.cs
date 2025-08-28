using GestorTorneosFutbolSala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class MatchValidator
    {

        public static void Validate(Match match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match), "El partido no puede ser nulo.");

            if (match.TournamentId <= 0)
                throw new ArgumentException("El ID del torneo debe ser mayor que cero.");

            if (match.HomeTeamId <= 0)
                throw new ArgumentException("El ID del equipo local debe ser mayor que cero.");

            if (match.AwayTeamId <= 0)
                throw new ArgumentException("El ID del equipo visitante debe ser mayor que cero.");

            if (match.HomeTeamId == match.AwayTeamId)
                throw new ArgumentException("El equipo local y el visitante no pueden ser el mismo.");

            if (match.RoundNumber <= 0)
                throw new ArgumentException("El número de la ronda debe ser mayor que cero.");

            if (string.IsNullOrWhiteSpace(match.Location))
                throw new ArgumentException("La ubicación del partido es obligatoria.");

            if (match.DateTime == default)
                throw new ArgumentException("La fecha del partido es obligatoria.");

            if (match.HomeGoals < 0)
                throw new ArgumentException("Los goles del equipo local no pueden ser negativos.");

            if (match.AwayGoals < 0)
                throw new ArgumentException("Los goles del equipo visitante no pueden ser negativos.");
        }
    }
}
