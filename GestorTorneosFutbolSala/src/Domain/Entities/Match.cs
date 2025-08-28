using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain.Entities
{
    /// <summary>
    /// Models a futsal match within a tournament.
    /// Includes location, and match details.
    /// </summary>
    /// 

    public class Match
    {
        private int id;
        private int tournamentId;
        private int homeTeamId;
        private int awayTeamId;
        private int roundNumber; // to organize the regular phase matches in jornadas
        private string location; // indicate where the match is played, especially in the final phase
        private DateTime dateTime;
        private int homeGoals;
        private int awayGoals;
        private DateTime createdDate;
        private int isPlayed;

        public Match()
        {
            createdDate = DateTime.Now;
            dateTime = DateTime.Now;
            homeGoals = 0;
            awayGoals = 0;
            incidents = new List<Incident>();
            isPlayed = 0;
        }

        public Match(int id, int tournamentId, int homeTeamId, int awayTeamId, int roundNumber, string location, DateTime dateTime, DateTime createdDate, int isPlayed)
        {
            this.id = id;
            this.tournamentId = tournamentId;
            this.homeTeamId = homeTeamId;
            this.awayTeamId = awayTeamId;
            this.roundNumber = roundNumber;
            this.location = location;
            this.dateTime = DateTime.Now;
            this.createdDate = createdDate;
            this.isPlayed = isPlayed; // 0 = No jugado, 1 = Jugado

            homeGoals = 0;
            awayGoals = 0;
            incidents = new List<Incident>();
        }

        public int Id { get => id; set => id = value; }
        public int TournamentId { get => tournamentId; set => tournamentId = value; }
        public int HomeTeamId { get => homeTeamId; set => homeTeamId = value; }
        public int AwayTeamId { get => awayTeamId; set => awayTeamId = value; }
        public int RoundNumber { get => roundNumber; set => roundNumber = value; }
        public string Location { get => location; set => location = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public int HomeGoals { get => homeGoals; set => homeGoals = value; }
        public int AwayGoals { get => awayGoals; set => awayGoals = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int IsPlayed { get; set; }

        public List<Incident> incidents { get; set; }

    }
}