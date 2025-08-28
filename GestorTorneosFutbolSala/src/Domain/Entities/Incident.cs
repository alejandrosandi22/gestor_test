using GestorTorneosFutbolSala.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Represents an incident that occurs during a futsal match.
    /// Used by the referee to register game statistics.
    /// </summary>
    /// 

    public class Incident
    {
        private int id;
        private int matchId;
        private int playerId;
        private IncidentTypeEnum type;
        private int minute;
        private string notes;
        private DateTime createdDate;

        public Incident()
        {
            createdDate = DateTime.Now;
        }

        public Incident(int id, int matchId, int playerId, IncidentTypeEnum type, int minute, string notes, DateTime createdDate)
        {
            this.id = id;
            this.matchId = matchId;
            this.playerId = playerId;
            this.type = type;
            this.minute = minute;
            this.notes = notes;
            this.createdDate = createdDate;
        }

        public int Id { get => id; set => id = value; }
        public int MatchId { get => matchId; set => matchId = value; }
        public int PlayerId { get => playerId; set => playerId = value; }
        public IncidentTypeEnum Type { get => type; set => type = value; }
        public int Minute { get => minute; set => minute = value; }
        public string Notes { get => notes; set => notes = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
    }
}
