using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class TeamsForm : Form
    {
        private readonly TeamController _teamController;
        private List<Team> teams;
        private List<Team> filteredTeams;
        private const int CARD_HEIGHT = 120;
        private const int CARD_MARGIN = 10;
        private int _currentTournamentId;

        public TeamsForm(Tournament tournament)
        {
            InitializeComponent();
            _currentTournamentId = tournament.Id;
            _teamController = new TeamController();
            InitializeTeamsForm();
            
        }

        public TeamsForm(List<Team> teamsList)
        {
            InitializeComponent();
            _teamController = new TeamController();
            this.teams = teamsList;
            InitializeTeamsForm();
        }

        private void InitializeTeamsForm()
        {
            this.Text = "Gestión de Equipos";
            this.WindowState = FormWindowState.Maximized;

            pnlContent.AutoScroll = true;

            LoadTeamsData();

            filteredTeams = new List<Team>(teams);

            RenderTeamCards();
        }

        private void LoadTeamsData()
        {
            try
            {
                if (teams == null)
                {
                    teams = _teamController.GetTeamsByTournament(_currentTournamentId);

                    if (teams == null)
                    {
                        teams = new List<Team>();
                    }
                    else
                    {
                        LoadPlayersForTeams();
                    }
                }
            }
            catch (Exception ex)
            {
                teams = new List<Team>();
            }
        }

        private void LoadPlayersForTeams()
        {
            try
            {
                PlayerController playerController = new PlayerController();

                foreach (var team in teams)
                {
                    try
                    {
                        var teamPlayers = playerController.GetPlayersByTeam(team.Id);
                        team.Players = teamPlayers ?? new List<Player>();
                    }
                    catch (Exception)
                    {
                        team.Players = new List<Player>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar jugadores: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RenderTeamCards()
        {
            pnlContent.Controls.Clear();

            if (filteredTeams == null || filteredTeams.Count == 0)
            {
                ShowNoTeamsMessage();
                return;
            }

            int currentY = 15;

            foreach (var team in filteredTeams)
            {
                Panel pnlTeamCard = CreateTeamCard(team);

                int availableWidth = pnlContent.ClientSize.Width - 40;

                pnlTeamCard.Location = new Point(20, currentY);
                pnlTeamCard.Width = Math.Max(400, availableWidth);

                pnlContent.Controls.Add(pnlTeamCard);

                currentY += CARD_HEIGHT + CARD_MARGIN;
            }
        }

        private Panel CreateTeamCard(Team team)
        {
            Panel pnlTeamCard = new Panel();
            pnlTeamCard.Height = CARD_HEIGHT;
            pnlTeamCard.BorderStyle = BorderStyle.FixedSingle;
            pnlTeamCard.BackColor = Color.White;
            pnlTeamCard.Cursor = Cursors.Hand;
            pnlTeamCard.Tag = team;

            pnlTeamCard.Click += PnlTeamCard_Click;

            Label lblTeamName = new Label();
            lblTeamName.Text = team.Name;
            lblTeamName.Font = new Font("Arial", 14, FontStyle.Bold);
            lblTeamName.ForeColor = Color.DarkBlue;
            lblTeamName.Location = new Point(15, 10);
            lblTeamName.Size = new Size(300, 25);
            lblTeamName.Click += PnlTeamCard_Click;
            lblTeamName.Tag = team;
            lblTeamName.Cursor = Cursors.Hand;

            Label lblLocationManager = new Label();
            lblLocationManager.Text = $"{team.OriginLocation} - {team.Manager}";
            lblLocationManager.Font = new Font("Arial", 10);
            lblLocationManager.ForeColor = Color.Gray;
            lblLocationManager.Location = new Point(15, 40);
            lblLocationManager.Size = new Size(500, 20);
            lblLocationManager.Click += PnlTeamCard_Click;
            lblLocationManager.Tag = team;
            lblLocationManager.Cursor = Cursors.Hand;

            Label lblPhoneStats = new Label();
            lblPhoneStats.Text = $"{team.ContactPhone}";
            lblPhoneStats.Font = new Font("Arial", 10);
            lblPhoneStats.ForeColor = Color.Black;
            lblPhoneStats.Location = new Point(15, 65);
            lblPhoneStats.Size = new Size(600, 20);
            lblPhoneStats.Click += PnlTeamCard_Click;
            lblPhoneStats.Tag = team;
            lblPhoneStats.Cursor = Cursors.Hand;

            Label lblCreatedDate = new Label();
            lblCreatedDate.Text = $"Creado: {team.CreatedDate:dd/MM/yyyy} - Jugadores: {team.Players?.Count ?? 0}";
            lblCreatedDate.Font = new Font("Arial", 9);
            lblCreatedDate.ForeColor = Color.DarkGray;
            lblCreatedDate.Location = new Point(15, 90);
            lblCreatedDate.Size = new Size(400, 20);
            lblCreatedDate.Click += PnlTeamCard_Click;
            lblCreatedDate.Tag = team;
            lblCreatedDate.Cursor = Cursors.Hand;

            Panel pnlButtons = new Panel();
            pnlButtons.Size = new Size(160, 35);
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Size = new Size(75, 30);
            btnEdit.Location = new Point(0, 2);
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderColor = Color.Blue;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Tag = team;
            btnEdit.Click += BtnEdit_Click;

            Button btnDelete = new Button();
            btnDelete.Text = "Eliminar";
            btnDelete.Size = new Size(80, 30);
            btnDelete.Location = new Point(80, 2);
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Tag = team;
            btnDelete.Click += BtnDelete_Click;

            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnDelete);

            pnlTeamCard.Controls.Add(lblTeamName);
            pnlTeamCard.Controls.Add(lblLocationManager);
            pnlTeamCard.Controls.Add(lblPhoneStats);
            pnlTeamCard.Controls.Add(lblCreatedDate);
            pnlTeamCard.Controls.Add(pnlButtons);

            pnlTeamCard.Resize += (sender, e) =>
            {
                if (sender is Panel panel)
                {
                    var buttonsPanel = panel.Controls.OfType<Panel>().FirstOrDefault();
                    if (buttonsPanel != null)
                    {
                        buttonsPanel.Location = new Point(panel.Width - buttonsPanel.Width - 15, 25);
                    }
                }
            };

            return pnlTeamCard;
        }

        private void ShowNoTeamsMessage()
        {
            Label lblNoTeams = new Label();
            lblNoTeams.Text = filteredTeams?.Count == 0 && teams?.Count > 0
                ? "No se encontraron equipos con la búsqueda aplicada"
                : "No hay equipos para mostrar";
            lblNoTeams.Font = new Font("Arial", 14, FontStyle.Bold);
            lblNoTeams.ForeColor = Color.Gray;
            lblNoTeams.TextAlign = ContentAlignment.MiddleCenter;
            lblNoTeams.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblNoTeams);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ApplySearch();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            ViewManager.ShowFormInPanel(new TeamEntryForm(_currentTournamentId), TargetPanel.TOURNAMENT);
        }

        private void ApplySearch()
        {
            if (teams == null)
            {
                filteredTeams = new List<Team>();
                RenderTeamCards();
                return;
            }

            var searchText = txtSearch.Text.ToLower().Trim();

            filteredTeams = teams.Where(team =>
                string.IsNullOrEmpty(searchText) ||
                team.Name.ToLower().Contains(searchText) ||
                team.OriginLocation.ToLower().Contains(searchText) ||
                team.Manager.ToLower().Contains(searchText)
            ).ToList();

            RenderTeamCards();
        }

        private void PnlTeamCard_Click(object sender, EventArgs e)
        {
            Team team = null;

            if (sender is Panel panel)
                team = panel.Tag as Team;
            else if (sender is Label label)
                team = label.Tag as Team;

            if (team != null)
            {
                ShowTeamDetails(team);
            }
        }

        private void ShowTeamDetails(Team team)
        {
            string details = $"INFORMACION DEL EQUIPO\n\n" +
                           $"ID: {team.Id}\n" +
                           $"Nombre: {team.Name}\n" +
                           $"Ubicacion: {team.OriginLocation}\n" +
                           $"Manager: {team.Manager}\n" +
                           $"Telefono: {team.ContactPhone}\n" +
                           $"ID Torneo: {team.TournamentId}\n" +
                           $"Fecha Creacion: {team.CreatedDate:dd/MM/yyyy}\n" +
                           $"Jugadores: {team.Players?.Count ?? 0}\n\n" +
                           $"ESTADISTICAS\n" +
                           $"Goles a Favor: {team.GoalsFor}\n" +
                           $"Goles en Contra: {team.GoalsAgainst}\n" +
                           $"Diferencia de Goles: {team.GoalsFor - team.GoalsAgainst}";

            MessageBox.Show(details, $"Detalles: {team.Name}",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btnEdit && btnEdit.Tag is Team team)
            {
                ViewManager.ShowFormInPanel(new TeamEntryForm(team.TournamentId, team), TargetPanel.TOURNAMENT);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is Button btnDelete && btnDelete.Tag is Team team)
            {
                string message = $"Esta seguro que desea eliminar el equipo '{team.Name}'?\n\n" +
                               "Esta accion no se puede deshacer.";

                var result = MessageBox.Show(message, "Eliminar Equipo",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteTeamUsingController(team.Id, team.Name);
                }
            }
        }

        private void DeleteTeamUsingController(int teamId, string teamName)
        {
            try
            {
                _teamController.DeleteTeam(teamId);

                var teamToRemove = teams.FirstOrDefault(t => t.Id == teamId);
                if (teamToRemove != null)
                {
                    teams.Remove(teamToRemove);
                }

                ApplySearch();

                MessageBox.Show($"El equipo '{teamName}' ha sido eliminado correctamente.",
                              "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el equipo '{teamName}': {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddTeamUsingController(Team team)
        {
            try
            {
                _teamController.CreateTeam(team);

                if (teams == null)
                    teams = new List<Team>();

                teams.Add(team);
                ApplySearch();

                MessageBox.Show($"El equipo '{team.Name}' ha sido agregado correctamente.",
                              "Equipo Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el equipo: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTeamUsingController(Team team)
        {
            try
            {
                _teamController.UpdateTeam(team);

                var existingTeam = teams.FirstOrDefault(t => t.Id == team.Id);
                if (existingTeam != null)
                {
                    int index = teams.IndexOf(existingTeam);
                    teams[index] = team;
                }

                ApplySearch();

                MessageBox.Show($"El equipo '{team.Name}' ha sido actualizado correctamente.",
                              "Equipo Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el equipo: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadDataFromController()
        {
            try
            {
                teams = _teamController.GetTeamsByTournament(_currentTournamentId);
                if (teams != null)
                {
                    LoadPlayersForTeams();
                }
                ApplySearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar los datos: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}