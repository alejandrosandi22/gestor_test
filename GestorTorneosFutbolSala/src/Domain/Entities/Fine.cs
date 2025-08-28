using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Represents a represents a specific financial penalty applied to a player for 
    /// an infraction (example: a yellow, blue or red card).
    /// </summary>
    /// 

    public class Fine
    {
        private int id;
        private int playerId;
        private int penaltyId;
        private DateTime date;
        private decimal amount;
        private bool paid;
        private DateTime createdDate;

        public Fine()
        {
            createdDate = DateTime.Now;
        }

        public Fine(int id, int playerId, int penaltyId, DateTime date, decimal amount, bool paid, DateTime createdDate)
        {
            this.id = id;
            this.playerId = playerId;
            this.penaltyId = penaltyId;
            this.date = date;
            this.amount = amount;
            this.paid = paid;
            this.createdDate = createdDate;
        }

        public int Id { get => id; set => id = value; }
        public int PlayerId { get => playerId; set => playerId = value; }
        public int PenaltyId { get => penaltyId; set => penaltyId = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public bool Paid { get => paid; set => paid = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
    }
}
