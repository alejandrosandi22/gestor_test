using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class TeamValidator
    {

        public static void Validate(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team), "El equipo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(team.Name))
                throw new ArgumentException("El nombre del equipo es obligatorio.");

            if (string.IsNullOrWhiteSpace(team.OriginLocation))
                throw new ArgumentException("La ubicación de origen es obligatoria.");

            if (string.IsNullOrWhiteSpace(team.Manager))
                throw new ArgumentException("El nombre del manager es obligatorio.");

            if (string.IsNullOrWhiteSpace(team.ContactPhone))
                throw new ArgumentException("El teléfono de contacto es obligatorio.");

            if (team.TournamentId <= 0)
                throw new ArgumentException("El ID del torneo debe ser válido.");
        }

        public static void ValidateNameDoesNotExist(string name, TeamRepository repository)
        {
            if (repository.ExistsByName(name))
                throw new InvalidOperationException($"Ya existe un equipo con el nombre '{name}'.");
        }

    }
}

