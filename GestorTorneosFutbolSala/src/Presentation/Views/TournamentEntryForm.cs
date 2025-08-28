using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class TournamentEntryForm : Form
    {
        private readonly TournamentController _controller;
        private Tournament tournament;
        private Boolean isEditing;
        private User _currentUser;

        public TournamentEntryForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            LoadYearOptions();
            LoadGenderOptions();
            this._controller = new TournamentController();
            this.isEditing = false;
        }

        public TournamentEntryForm(Tournament tournament)
        {
            InitializeComponent();
            LoadYearOptions();
            LoadGenderOptions();
            this.tournament = tournament;
            this.isEditing = true;
        }

        private void LoadGenderOptions()
        {
            var genderOptions = new[]
            {
                new { Text = "Masculino", Value = GenderCategoryEnum.Male },
                new { Text = "Femenino", Value = GenderCategoryEnum.Female },
                new { Text = "Mixto", Value = GenderCategoryEnum.Mixed }
            };

            cmbGender.DataSource = genderOptions;
            cmbGender.DisplayMember = "Text";
            cmbGender.ValueMember = "Value";

            cmbGender.SelectedValue = GenderCategoryEnum.Male;
        }

        private void LoadYearOptions()
        {
            int currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(2000, (currentYear + 5) - 1999).ToList();

            cmbYear.DataSource = years;
            cmbYear.SelectedItem = currentYear;
        }


        private void HandleCreateTournament()
        {
            lblTournamentNameError.Visible = false;
            lblAgeCategoryError.Visible = false;
            lblYearError.Visible = false;
            lblGenderError.Visible = false;

            bool hasErrors = false;

            string name = txtTournamentName.Text?.Trim();
            string ageCategoryText = txtAgeCategory.Text?.Trim();
            string yearSelected = cmbYear.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(name))
            {
                lblTournamentNameError.Text = "El nombre no puede estar vacío.";
                lblTournamentNameError.Visible = true;
                hasErrors = true;
            }

            if (!int.TryParse(ageCategoryText, out int ageCategory) || ageCategory < 0)
            {
                lblAgeCategoryError.Text = "La categoría de edad debe ser un número válido y positivo.";
                lblAgeCategoryError.Visible = true;
                hasErrors = true;
            }

            if (!int.TryParse(yearSelected, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
            {
                lblYearError.Text = "Seleccione un año válido.";
                lblYearError.Visible = true;
                hasErrors = true;
            }

            if (cmbGender.SelectedValue == null ||
                !Enum.IsDefined(typeof(GenderCategoryEnum), cmbGender.SelectedValue))
            {
                lblGenderError.Text = "Seleccione una categoría de género válida.";
                lblGenderError.Visible = true;
                hasErrors = true;
            }
            GenderCategoryEnum gender = (GenderCategoryEnum)cmbGender.SelectedValue;

            if (hasErrors)
                return;

            try
            {
                if (isEditing && tournament != null)
                {
                    tournament.Name = name;
                    tournament.AgeCategory = ageCategory;
                    tournament.Year = year;
                    tournament.Gender = gender;
                    tournament.CreatedDate = DateTime.Now;

                    _controller.UpdateTournament(tournament);

                    MessageBox.Show("Torneo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int tournamentId = IdGenerator.GetNextId(IdGenerator.DbTable.Tournament);
                    Tournament newTournament = new Tournament
                    {
                        Id = tournamentId,
                        Name = name,
                        AgeCategory = ageCategory,
                        Year = year,
                        Gender = gender,
                        CreatedDate = DateTime.Now,
                        Stage = 1 // Por defecto empieza en la fase 1
                    };

                    _controller.CreateTournament(newTournament);
                    tournament = newTournament;

                    MessageBox.Show("Torneo creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isEditing = false;
                ViewManager.ShowFormInPanel(new TournamentDetailsForm(tournament), TargetPanel.DASHBOARD);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el torneo:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnGoBack_Click(object sender, EventArgs e)
        {
            ViewManager.ShowFormInPanel(new TournamentForm(_currentUser), TargetPanel.DASHBOARD);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            HandleCreateTournament();
        }
    }
}
