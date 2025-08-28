using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Represents a futsal player with personal information.
    /// Includes a method to calculate the player's age based on their birth date.
    /// </summary>
    /// 

    public class Player
    {
        private int id;
        private string idNumber;
        private string fullName;
        private DateTime birthDate;
        private int teamId;
        private DateTime createdDate;

        //For the reports
        private int goalsScored = 0;
        private int yellowCards = 0;
        private int blueCards = 0;
        private int redCards = 0;

        public Player()
        {
            createdDate = DateTime.Now;
        }

        public Player(int id, string idNumber, string fullName, DateTime birthDate, int teamId, DateTime createdDate)
        {
            this.id = id;
            this.idNumber = idNumber;
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.teamId = teamId;
            this.createdDate = createdDate;
        }

        public int Id { get => id; set => id = value; }
        public string IdNumber { get => idNumber; set => idNumber = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public int TeamId { get => teamId; set => teamId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int GoalsScored { get => goalsScored; set => goalsScored = value; }
        public int YellowCards { get => yellowCards; set => yellowCards = value; }
        public int BlueCards { get => blueCards; set => blueCards = value; }
        public int RedCards { get => redCards; set => redCards = value; }

        public int CalculateAge(DateTime date)
        {
            int age = date.Year - birthDate.Year;
            if (birthDate.Date > date.AddYears(-age))
                age--;
            return age;
        }

    }
}