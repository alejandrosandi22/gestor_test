using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Represents a sanction rule with a name and amount (example: Yellow Card = ₡10,000).
    /// Allows defining penalties.
    /// </summary>
    /// 

    public class Penalty
    {
        private int id;
        private string name;
        private decimal amount;
        private bool active; //If it is valid
        private DateTime createdDate;

        public Penalty()
        {
            createdDate = DateTime.Now;
        }

        public Penalty(int id, string name, decimal amount, bool active, DateTime createdDate)
        {
            this.id = id;
            this.name = name;
            this.amount = amount;
            this.active = active;
            this.createdDate = createdDate;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public bool Active { get => active; set => active = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
    }
}
