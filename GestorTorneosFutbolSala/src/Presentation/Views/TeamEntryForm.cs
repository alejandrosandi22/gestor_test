using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using GestorTorneosFutbolSala.Domain;
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
    public partial class TeamEntryForm : Form
    {
        private readonly TeamController _teamController;
        private readonly PlayerController _playerController;
        private readonly TournamentController _tournamentController;
        private Team _currentTeam;
        private Tournament _currentTournament;
        private bool _isEditMode;
        private int _tournamentId;

        public TeamEntryForm(int tournamentId, Team teamToEdit = null)
        {
            InitializeComponent();
            _teamController = new TeamController();
            _playerController = new PlayerController();
            _tournamentController = new TournamentController();
            _tournamentId = tournamentId;
            _currentTeam = teamToEdit;
            _isEditMode = teamToEdit != null;

            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadTournamentData();

            if (_isEditMode)
            {
                LoadTeamData();
                LoadTeamPlayers();
                btnSave.Text = "Actualizar Equipo";
                this.Text = "Editar Equipo";
            }
            else
            {
                _currentTeam = new Team();
                _currentTeam.TournamentId = _tournamentId;
                btnSave.Text = "Crear Equipo";
                this.Text = "Crear Equipo";
            }

            LoadPlayersGrid();
        }

        private void LoadTournamentData()
        {
            try
            {
                var tournaments = _tournamentController.GetAllTournaments();
                _currentTournament = tournaments?.FirstOrDefault(t => t.Id == _tournamentId);

                if (_currentTournament == null)
                {
                    throw new Exception("No se pudo cargar la información del torneo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del torneo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _currentTournament = new Tournament { AgeCategory = 18 };
            }
        }

        private void LoadTeamPlayers()
        {
            if (_currentTeam?.Id > 0)
            {
                try
                {
                    var allPlayers = _playerController.GetAllPlayers();
                    var teamPlayers = allPlayers?.Where(p => p.TeamId == _currentTeam.Id).ToList();

                    if (teamPlayers != null && teamPlayers.Any())
                    {
                        _currentTeam.Players = teamPlayers;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar jugadores del equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadTeamData()
        {
            if (_currentTeam != null)
            {
                txtTeamName.Text = _currentTeam.Name;
                txtOriginLocation.Text = _currentTeam.OriginLocation;
                txtManager.Text = _currentTeam.Manager;
                txtContactPhone.Text = _currentTeam.ContactPhone;
            }
        }

        private void LoadPlayersGrid()
        {
            dgvPlayers.Rows.Clear();
            if (_currentTeam?.Players != null)
            {
                foreach (var player in _currentTeam.Players)
                {
                    AddPlayerToGrid(player);
                }
            }

            btnAddPlayer.Enabled = dgvPlayers.Rows.Count < 12;
            lblPlayersCount.Text = $"Jugadores: {dgvPlayers.Rows.Count}/12";
        }

        private void AddPlayerToGrid(Player player)
        {
            int rowIndex = dgvPlayers.Rows.Add();
            DataGridViewRow row = dgvPlayers.Rows[rowIndex];

            row.Cells["colPlayerId"].Value = player.Id;
            row.Cells["colPlayerIdNumber"].Value = player.IdNumber;
            row.Cells["colPlayerName"].Value = player.FullName;
            row.Cells["colPlayerBirthDate"].Value = player.BirthDate.ToString("dd/MM/yyyy");
            row.Cells["colPlayerAge"].Value = player.CalculateAge(DateTime.Now);
        }

        private bool ValidateTeamForm()
        {
            bool isValid = true;

            lblTeamNameError.Text = "";
            lblOriginLocationError.Text = "";
            lblManagerError.Text = "";
            lblContactPhoneError.Text = "";

            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                lblTeamNameError.Text = "El nombre del equipo es obligatorio.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtOriginLocation.Text))
            {
                lblOriginLocationError.Text = "El lugar de origen es obligatorio.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtManager.Text))
            {
                lblManagerError.Text = "El encargado es obligatorio.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtContactPhone.Text))
            {
                lblContactPhoneError.Text = "El teléfono de contacto es obligatorio.";
                isValid = false;
            }

            return isValid;
        }

        private void SaveTeamData()
        {
            if (!_isEditMode)
            {
                _currentTeam.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Team);
            }

            _currentTeam.Name = txtTeamName.Text.Trim();
            _currentTeam.OriginLocation = txtOriginLocation.Text.Trim();
            _currentTeam.Manager = txtManager.Text.Trim();
            _currentTeam.ContactPhone = txtContactPhone.Text.Trim();
            _currentTeam.TournamentId = _tournamentId;

            _currentTeam.Players.Clear();
            foreach (DataGridViewRow row in dgvPlayers.Rows)
            {
                if (row.Cells["colPlayerIdNumber"].Value != null)
                {
                    var player = new Player
                    {
                        Id = Convert.ToInt32(row.Cells["colPlayerId"].Value ?? 0),
                        IdNumber = row.Cells["colPlayerIdNumber"].Value.ToString(),
                        FullName = row.Cells["colPlayerName"].Value.ToString(),
                        BirthDate = DateTime.ParseExact(row.Cells["colPlayerBirthDate"].Value.ToString(), "dd/MM/yyyy", null),
                        TeamId = _currentTeam.Id
                    };

                    if (!_isEditMode && player.Id == 0)
                    {
                        player.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Player);
                    }

                    _currentTeam.Players.Add(player);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTeamForm())
                {
                    return;
                }

                SaveTeamData();

                if (_isEditMode)
                {
                    _teamController.UpdateTeam(_currentTeam);
                    SaveAllPlayers();
                    MessageBox.Show("Equipo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _teamController.CreateTeam(_currentTeam);
                    SaveAllPlayers();
                    MessageBox.Show("Equipo creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ViewManager.ShowFormInPanel(new TeamsForm(_currentTournament), TargetPanel.TOURNAMENT);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al guardar el equipo:\n\n{ex.Message}";
                if (ex.InnerException != null)
                {
                    mensaje += $"\n\nDetalle interno:\n{ex.InnerException.Message}";
                }
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAllPlayers()
        {
            try
            {
                if (_isEditMode)
                {
                    var existingPlayers = _playerController.GetAllPlayers()?.Where(p => p.TeamId == _currentTeam.Id).ToList();
                    if (existingPlayers != null)
                    {
                        foreach (var existingPlayer in existingPlayers)
                        {
                            bool stillInTeam = _currentTeam.Players.Any(p => p.Id == existingPlayer.Id);
                            if (!stillInTeam)
                            {
                                _playerController.DeletePlayer(existingPlayer.Id);
                            }
                        }
                    }
                }

                // Luego, guardar o actualizar cada jugador
                foreach (var player in _currentTeam.Players)
                {
                    player.TeamId = _currentTeam.Id;

                    if (player.Id == 0 || !PlayerExists(player.Id))
                    {
                        // Es un nuevo jugador
                        if (player.Id == 0)
                        {
                            player.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Player);
                        }
                        _playerController.CreatePlayer(player);
                    }
                    else
                    {
                        // Es un jugador existente, actualizarlo
                        _playerController.UpdatePlayer(player);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar jugadores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool PlayerExists(int playerId)
        {
            try
            {
                int foundId = _playerController.GetPlayerById(playerId);
                return foundId > 0;
            }
            catch
            {
                return false;
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            ViewManager.ShowFormInPanel(new TeamsForm(_currentTournament), TargetPanel.TOURNAMENT);
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.Rows.Count >= 12)
            {
                MessageBox.Show("Un equipo no puede tener más de 12 jugadores.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maxAge = _currentTournament?.AgeCategory ?? 18;
            using (var playerForm = new PlayerEntryForm(maxAge))
            {
                if (playerForm.ShowDialog() == DialogResult.OK)
                {
                    var player = playerForm.GetPlayer();
                    if (player != null)
                    {
                        if (ValidatePlayerAge(player, maxAge))
                        {
                            AddPlayerToGrid(player);
                            btnAddPlayer.Enabled = dgvPlayers.Rows.Count < 12;
                            lblPlayersCount.Text = $"Jugadores: {dgvPlayers.Rows.Count}/12";
                        }
                        else
                        {
                            MessageBox.Show($"El jugador no cumple con la edad requerida para este torneo. Edad máxima permitida: {maxAge} años.",
                                "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un jugador para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPlayers.CurrentRow;
            var player = new Player
            {
                Id = Convert.ToInt32(row.Cells["colPlayerId"].Value ?? 0),
                IdNumber = row.Cells["colPlayerIdNumber"].Value?.ToString(),
                FullName = row.Cells["colPlayerName"].Value?.ToString(),
                BirthDate = DateTime.ParseExact(row.Cells["colPlayerBirthDate"].Value?.ToString(), "dd/MM/yyyy", null)
            };

            int maxAge = _currentTournament?.AgeCategory ?? 18;
            using (var playerForm = new PlayerEntryForm(maxAge, player))
            {
                if (playerForm.ShowDialog() == DialogResult.OK)
                {
                    var updatedPlayer = playerForm.GetPlayer();
                    if (updatedPlayer != null)
                    {
                        if (ValidatePlayerAge(updatedPlayer, maxAge))
                        {
                            row.Cells["colPlayerIdNumber"].Value = updatedPlayer.IdNumber;
                            row.Cells["colPlayerName"].Value = updatedPlayer.FullName;
                            row.Cells["colPlayerBirthDate"].Value = updatedPlayer.BirthDate.ToString("dd/MM/yyyy");
                            row.Cells["colPlayerAge"].Value = updatedPlayer.CalculateAge(DateTime.Now);
                        }
                        else
                        {
                            MessageBox.Show($"El jugador no cumple con la edad requerida para este torneo. Edad máxima permitida: {maxAge} años.",
                                "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private bool ValidatePlayerAge(Player player, int maxAge)
        {
            var playerAge = player.CalculateAge(DateTime.Now);
            return playerAge <= maxAge;
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un jugador para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("¿Está seguro de que desea eliminar este jugador?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgvPlayers.Rows.RemoveAt(dgvPlayers.CurrentRow.Index);
                btnAddPlayer.Enabled = dgvPlayers.Rows.Count < 12;
                lblPlayersCount.Text = $"Jugadores: {dgvPlayers.Rows.Count}/12";
            }
        }

        private void dgvPlayers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditPlayer_Click(sender, e);
            }
        }
    }
}