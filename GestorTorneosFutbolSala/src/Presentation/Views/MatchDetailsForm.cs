using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class MatchDetailsForm : Form
    {
        private Match _currentMatch;
        private Match _originalMatch;
        private PlayerController _playerController;
        private IncidentController _incidentController;
        private MatchController _matchController;
        private TeamController _teamController;
        private LoadFonts _loadFonts;
        private List<Player> _homeTeamPlayers;
        private List<Player> _awayTeamPlayers;
        private List<Incident> _pendingIncidents;
        private List<Incident> _existingIncidents;

        public MatchDetailsForm(Match match)
        {
            InitializeComponent();
            _currentMatch = match;
            _originalMatch = new Match
            {
                Id = match.Id,
                TournamentId = match.TournamentId,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                HomeGoals = match.HomeGoals,
                AwayGoals = match.AwayGoals,
                DateTime = match.DateTime,
                Location = match.Location,
                RoundNumber = match.RoundNumber,
                IsPlayed = match.IsPlayed
            };
            _playerController = new PlayerController();
            _incidentController = new IncidentController();
            _matchController = new MatchController();
            _teamController = new TeamController();
            _pendingIncidents = new List<Incident>();
            _existingIncidents = new List<Incident>();

            try
            {
                _loadFonts = new LoadFonts();
                ApplyInterFont();
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error loading fonts: {ex.Message}");
            }

            LoadMatchData();
        }

        private void ApplyInterFont()
        {
            Font interFont = _loadFonts.GetFont("Inter", 9f);
            Font interFontBold = _loadFonts.GetFont("Inter", 10f, FontStyle.Bold);
            Font interFontTitle = _loadFonts.GetFont("Inter", 12f, FontStyle.Bold);

            this.Font = interFont;
            lblMatchTitle.Font = interFontTitle;
            lblHomeTeam.Font = interFontBold;
            lblAwayTeam.Font = interFontBold;
            lblScore.Font = interFontTitle;
            lblIncidents.Font = interFontBold;

            foreach (Control control in this.Controls)
            {
                if (control is Button)
                    control.Font = interFont;
                else if (control is Label && control != lblMatchTitle && control != lblHomeTeam &&
                         control != lblAwayTeam && control != lblScore && control != lblIncidents)
                    control.Font = interFont;
                else if (control is ComboBox || control is TextBox || control is NumericUpDown)
                    control.Font = interFont;
                else if (control is DataGridView)
                    control.Font = interFont;
            }
        }

        private void LoadMatchData()
        {
            try
            {
                _homeTeamPlayers = _playerController.GetPlayersByTeam(_currentMatch.HomeTeamId);
                _awayTeamPlayers = _playerController.GetPlayersByTeam(_currentMatch.AwayTeamId);

                lblMatchTitle.Text = $"Partido - Jornada {_currentMatch.RoundNumber}";
                lblHomeTeam.Text = GetTeamName(_currentMatch.HomeTeamId);
                lblAwayTeam.Text = GetTeamName(_currentMatch.AwayTeamId);
                UpdateScoreDisplay();
                lblLocation.Text = $"Ubicación: {_currentMatch.Location}";
                lblDateTime.Text = $"Fecha: {_currentMatch.DateTime.ToString("dd/MM/yyyy HH:mm")}";

                PopulatePlayerComboBox();
                LoadExistingIncidents();
                RefreshIncidentsDisplay();

                if (_currentMatch.IsPlayed == 1)
                {
                    btnAddIncident.Enabled = false;
                    btnDeleteIncident.Enabled = false;
                    btnSave.Enabled = false;
                    lblMatchTitle.Text += " (Finalizado)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del partido: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateScoreDisplay()
        {
            int homeGoals = _currentMatch.HomeGoals;
            int awayGoals = _currentMatch.AwayGoals;

            // Add pending goal incidents to the score
            foreach (var incident in _pendingIncidents)
            {
                if (incident.Type == IncidentTypeEnum.Goal)
                {
                    bool isHomePlayer = _homeTeamPlayers.Any(p => p.Id == incident.PlayerId);
                    if (isHomePlayer)
                        homeGoals++;
                    else
                        awayGoals++;
                }
            }

            lblScore.Text = $"{homeGoals} - {awayGoals}";

            if (_pendingIncidents.Any())
                lblScore.ForeColor = Color.Orange;
            else
                lblScore.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private string GetTeamName(int teamId)
        {
            try
            {
                Team team = _teamController.GetTeamById(teamId);
                return team.Name ?? $"Equipo {teamId}";
            }
            catch
            {
                return $"Equipo {teamId}";
            }
        }

        private void PopulatePlayerComboBox()
        {
            cmbPlayer.Items.Clear();

            foreach (var player in _homeTeamPlayers)
            {
                cmbPlayer.Items.Add(new PlayerItem
                {
                    Id = player.Id,
                    Name = $"{player.FullName} ({lblHomeTeam.Text})"
                });
            }

            foreach (var player in _awayTeamPlayers)
            {
                cmbPlayer.Items.Add(new PlayerItem
                {
                    Id = player.Id,
                    Name = $"{player.FullName} ({lblAwayTeam.Text})"
                });
            }

            cmbPlayer.DisplayMember = "Name";
            cmbPlayer.ValueMember = "Id";
        }

        private void LoadExistingIncidents()
        {
            try
            {
                var allIncidents = _incidentController.GetAllIncidents();
                _existingIncidents = allIncidents.Where(i => i.MatchId == _currentMatch.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar incidentes existentes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshIncidentsDisplay()
        {
            try
            {
                var allIncidents = new List<Incident>();
                allIncidents.AddRange(_existingIncidents);
                allIncidents.AddRange(_pendingIncidents);

                dgvIncidents.DataSource = allIncidents.OrderBy(i => i.Minute).Select(i => new
                {
                    Id = i.Id,
                    Jugador = GetPlayerName(i.PlayerId),
                    Tipo = GetIncidentTypeText(i.Type),
                    Minuto = i.Minute,
                    Notas = i.Notes,
                    Estado = _existingIncidents.Any(e => e.Id == i.Id) ? "Guardado" : "Pendiente"
                }).ToList();

                dgvIncidents.Columns["Id"].Visible = false;

                foreach (DataGridViewRow row in dgvIncidents.Rows)
                {
                    if (row.Cells["Estado"].Value.ToString() == "Pendiente")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar vista de incidentes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetPlayerName(int playerId)
        {
            var player = _homeTeamPlayers.FirstOrDefault(p => p.Id == playerId)
                        ?? _awayTeamPlayers.FirstOrDefault(p => p.Id == playerId);
            return player?.FullName ?? "Desconocido";
        }

        private string GetIncidentTypeText(IncidentTypeEnum type)
        {
            switch (type)
            {
                case IncidentTypeEnum.Goal:
                    return "Gol";
                case IncidentTypeEnum.YellowCard:
                    return "Tarjeta Amarilla";
                case IncidentTypeEnum.BlueCard:
                    return "Tarjeta Azul";
                case IncidentTypeEnum.RedCard:
                    return "Tarjeta Roja";
                case IncidentTypeEnum.Injury:
                    return "Lesión";
                case IncidentTypeEnum.Expulsion:
                    return "Expulsión";
                case IncidentTypeEnum.Other:
                    return "Otro";
                default:
                    return "Desconocido";
            }
        }

        private void btnAddIncident_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlayer.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un jugador.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbIncidentType.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un tipo de incidente.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var playerId = ((PlayerItem)cmbPlayer.SelectedItem).Id;
                var incidentType = (IncidentTypeEnum)cmbIncidentType.SelectedValue;
                var minute = (int)nudMinute.Value;
                var notes = txtNotes.Text.Trim();

                var incident = new Incident
                {
                    Id = GetTempId(),
                    MatchId = _currentMatch.Id,
                    PlayerId = playerId,
                    Type = incidentType,
                    Minute = minute,
                    Notes = string.IsNullOrEmpty(notes) ? null : notes
                };

                _pendingIncidents.Add(incident);

                ClearIncidentForm();
                UpdateScoreDisplay();
                RefreshIncidentsDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar incidente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetTempId()
        {
            return -(_pendingIncidents.Count + 1);
        }

        private void ClearIncidentForm()
        {
            cmbPlayer.SelectedIndex = -1;
            cmbIncidentType.SelectedIndex = -1;
            nudMinute.Value = 0;
            txtNotes.Clear();
        }

        private void btnDeleteIncident_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvIncidents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor seleccione un incidente para eliminar.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int incidentId = Convert.ToInt32(dgvIncidents.SelectedRows[0].Cells["Id"].Value);
                string estado = dgvIncidents.SelectedRows[0].Cells["Estado"].Value.ToString();

                var result = MessageBox.Show("¿Está seguro de eliminar este incidente?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (estado == "Pendiente")
                    {
                        var pendingIncident = _pendingIncidents.FirstOrDefault(i => i.Id == incidentId);
                        if (pendingIncident != null)
                        {
                            _pendingIncidents.Remove(pendingIncident);
                            UpdateScoreDisplay();
                            RefreshIncidentsDisplay();
                            MessageBox.Show("Incidente pendiente eliminado.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        var existingIncident = _existingIncidents.FirstOrDefault(i => i.Id == incidentId);
                        if (existingIncident != null)
                        {
                            _incidentController.DeleteIncident(incidentId);
                            _existingIncidents.Remove(existingIncident);

                            if (existingIncident.Type == IncidentTypeEnum.Goal)
                            {
                                UpdateMatchScoreOnGoalRemoval(existingIncident.PlayerId);
                            }

                            RefreshIncidentsDisplay();
                            MessageBox.Show("Incidente eliminado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar incidente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMatchScoreOnGoalRemoval(int playerId)
        {
            try
            {
                bool isHomePlayer = _homeTeamPlayers.Any(p => p.Id == playerId);

                if (isHomePlayer && _currentMatch.HomeGoals > 0)
                {
                    _currentMatch.HomeGoals--;
                }
                else if (!isHomePlayer && _currentMatch.AwayGoals > 0)
                {
                    _currentMatch.AwayGoals--;
                }

                _matchController.UpdateMatch(_currentMatch);
                UpdateScoreDisplay();

                RecalculateTeamStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar marcador tras eliminar gol: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_pendingIncidents.Any())
            {
                var result = MessageBox.Show("Hay incidentes pendientes sin guardar. ¿Está seguro de cerrar?",
                    "Cambios Pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }

            ViewManager.ShowFormInPanel(new MatchesForm(_currentMatch.TournamentId), TargetPanel.TOURNAMENT);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentMatch.IsPlayed == 1)
                {
                    MessageBox.Show("Este partido ya ha sido finalizado y no se pueden realizar cambios.", "Partido Finalizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_pendingIncidents.Count == 0)
                {
                    MessageBox.Show("No hay incidentes pendientes para guardar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show($"¿Está seguro de guardar {_pendingIncidents.Count} incidente(s) pendiente(s)? Esto finalizará el partido.", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CalculateFinalScore();

                    foreach (var incident in _pendingIncidents)
                    {
                        incident.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Incident);
                        _incidentController.CreateIncident(incident);
                    }

                    _currentMatch.IsPlayed = 1;
                    _matchController.UpdateMatch(_currentMatch);

                    RecalculateTeamStatistics();

                    _existingIncidents.AddRange(_pendingIncidents);
                    _pendingIncidents.Clear();
                    _originalMatch.HomeGoals = _currentMatch.HomeGoals;
                    _originalMatch.AwayGoals = _currentMatch.AwayGoals;
                    _originalMatch.IsPlayed = 1;

                    btnAddIncident.Enabled = false;
                    btnDeleteIncident.Enabled = false;
                    btnSave.Enabled = false;
                    lblMatchTitle.Text = lblMatchTitle.Text.Replace(" (Finalizado)", "") + " (Finalizado)";

                    UpdateScoreDisplay();
                    RefreshIncidentsDisplay();

                    MessageBox.Show("Partido finalizado correctamente. Estadísticas actualizadas.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateFinalScore()
        {
            int homeGoals = _originalMatch.HomeGoals;
            int awayGoals = _originalMatch.AwayGoals;

            foreach (var incident in _pendingIncidents)
            {
                if (incident.Type == IncidentTypeEnum.Goal)
                {
                    bool isHomePlayer = _homeTeamPlayers.Any(p => p.Id == incident.PlayerId);
                    if (isHomePlayer)
                        homeGoals++;
                    else
                        awayGoals++;
                }
            }

            _currentMatch.HomeGoals = homeGoals;
            _currentMatch.AwayGoals = awayGoals;
        }

        private void RecalculateTeamStatistics()
        {
            try
            {
                Team homeTeam = UpdateTeamStats(_currentMatch.HomeTeamId);
                Team awayTeam = UpdateTeamStats(_currentMatch.AwayTeamId);


                _teamController.UpdateTeam(homeTeam);
                _teamController.UpdateTeam(awayTeam);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar estadísticas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private Team UpdateTeamStats(int teamId)
        {
            try
            {
                Team team = _teamController.GetTeamById(teamId);

                if (_currentMatch.HomeTeamId == teamId)
                {
                    team.GoalsFor += _currentMatch.HomeGoals;
                    team.GoalsAgainst += _currentMatch.AwayGoals;
                    if (_currentMatch.HomeGoals > _currentMatch.AwayGoals)
                    {
                        team.Points += 3;
                    }
                    if (_currentMatch.HomeGoals == _currentMatch.AwayGoals)
                    {
                        team.Points += 1;
                    }
                }
                else
                {
                    team.GoalsFor += _currentMatch.AwayGoals;
                    team.GoalsAgainst += _currentMatch.HomeGoals;
                    if (_currentMatch.AwayGoals > _currentMatch.HomeGoals)
                    {
                        team.Points += 3;
                    }
                    if (_currentMatch.AwayGoals == _currentMatch.HomeGoals)
                    {
                        team.Points += 1;
                    }
                }

                return team;


            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar estadísticas del equipo ID {teamId}: {ex.Message}", ex);
            }
        }

        private void MatchDetailsForm_Load(object sender, EventArgs e)
        {
            PopulateIncidentTypes();
        }

        private void PopulateIncidentTypes()
        {
            cmbIncidentType.Items.Clear();

            var incidentTypes = new[]
            {
                new { Value = IncidentTypeEnum.Goal, Text = "Gol" },
                new { Value = IncidentTypeEnum.YellowCard, Text = "Tarjeta Amarilla" },
                new { Value = IncidentTypeEnum.BlueCard, Text = "Tarjeta Azul" },
                new { Value = IncidentTypeEnum.RedCard, Text = "Tarjeta Roja" },
                new { Value = IncidentTypeEnum.Injury, Text = "Lesión" },
                new { Value = IncidentTypeEnum.Expulsion, Text = "Expulsión" },
                new { Value = IncidentTypeEnum.Other, Text = "Otro" }
            };

            cmbIncidentType.DataSource = incidentTypes;
            cmbIncidentType.DisplayMember = "Text";
            cmbIncidentType.ValueMember = "Value";
        }
    }

    public class PlayerItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}