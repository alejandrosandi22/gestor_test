using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.Domain
{
    /// <summary>
    /// Represents a futsal tournament with its basic information.
    /// </summary>

    public class Tournament
    {
        private int id;
        private string name;
        private int ageCategory;
        private int year;
        private GenderCategoryEnum gender;
        private DateTime createdDate;
        private int stage; // Fase de grupos = 1, semifinales = 2, final = 3

        public Tournament()
        {
            createdDate = DateTime.Now;
            teams = new List<Team>();
            matchs = new List<Match>();
        }

        public Tournament(int id, string name, int ageCategory, int year, GenderCategoryEnum gender, DateTime createdDate, int stage)
        {
            this.id = id;
            this.name = name;
            this.ageCategory = ageCategory;
            this.year = year;
            this.gender = gender;
            this.createdDate = createdDate;
            teams = new List<Team>();
            matchs = new List<Match>();
            this.stage = stage;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int AgeCategory { get => ageCategory; set => ageCategory = value; }
        public int Year { get => year; set => year = value; }
        public GenderCategoryEnum Gender { get => gender; set => gender = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public List<Team> teams { get; set; }
        public List<Match> matchs { get; set; }
        public int Stage { get => stage; set => stage = value; }
    }
}
