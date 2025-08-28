using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestorTorneosFutbolSala.Domain.Validators
{
    public class PlayerValidator
    {
        public static void Validate(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player), "El jugador no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(player.FullName))
                throw new ArgumentException("El nombre completo del jugador es obligatorio.");

            if (string.IsNullOrWhiteSpace(player.IdNumber))
                throw new ArgumentException("El número de identificación del jugador es obligatorio.");

            if (player.BirthDate == default)
                throw new ArgumentException("La fecha de nacimiento del jugador es obligatoria.");

            if (player.TeamId <= 0)
                throw new ArgumentException("El ID del equipo al que pertenece el jugador es obligatorio y debe ser mayor que cero.");
        }

        public static void ValidateIdNumberDoesNotExist(string idNumber, PlayerRepository repository)
        {
            if (repository.ExistsByIdNumber(idNumber))
                throw new InvalidOperationException($"Ya existe un jugador con esa cédula '{idNumber}'.");
        }

        public static void ValidateNameDoesNotExist(string fullName, PlayerRepository repository)
        {
            if (repository.ExistsByName(fullName))
                throw new InvalidOperationException($"Ya existe un jugador con ese nombre '{fullName}'.");
        }

    }
}
