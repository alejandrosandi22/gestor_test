using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Represents a futsal team that participates in a tournament.
    /// </summary>
    /// 

    public class Team
    {
        private int id;
        private string name;
        private string originLocation;
        private string manager;
        private string contactPhone;
        private int tournamentId;
        private DateTime createdDate;
        private List<Player> players;

        private int points = 0;
        private int goalsFor = 0;
        private int goalsAgainst = 0;

        public Team()
        {
            createdDate = DateTime.Now;
            players = new List<Player>();
        }

        public Team(int id, string name, string originLocation, string manager, string contactPhone, int tournamentId, DateTime createdDate)
        {
            this.id = id;
            this.name = name;
            this.originLocation = originLocation;
            this.manager = manager;
            this.contactPhone = contactPhone;
            this.tournamentId = tournamentId;
            this.createdDate = createdDate;
            this.players = new List<Player>();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string OriginLocation { get => originLocation; set => originLocation = value; }
        public string Manager { get => manager; set => manager = value; }
        public string ContactPhone { get => contactPhone; set => contactPhone = value; }
        public int TournamentId { get => tournamentId; set => tournamentId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public List<Player> Players { get => players; set => players = value; }
        public int Points { get => points; set => points = value; }
        public int GoalsFor { get => goalsFor; set => goalsFor = value; }
        public int GoalsAgainst { get => goalsAgainst; set => goalsAgainst = value; }
    }
}
