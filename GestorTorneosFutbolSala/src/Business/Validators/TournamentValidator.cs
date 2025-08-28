using GestorTorneosFutbolSala.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class TournamentValidator
    {
        public static void Validate(Tournament tournament)
        {
            if (tournament == null)
                throw new ArgumentNullException(nameof(tournament), "El torneo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(tournament.Name))
                throw new ArgumentException("El nombre del torneo es obligatorio.");

            if (tournament.Year < 2000 || tournament.Year > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del torneo no es válido.");
        }

        public static void ValidateNameDoesNotExist(string name, TournamentRepository repository)
        {
            if (repository.ExistsByName(name))
                throw new InvalidOperationException($"Ya existe un torneo con el nombre '{name}'.");
        }
    }
}
