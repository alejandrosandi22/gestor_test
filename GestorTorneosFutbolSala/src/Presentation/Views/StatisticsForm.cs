using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.src.Infrastructure.Repositories;
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
    public partial class StatisticsForm : Form
    {
        private Tournament _tournament;
        private TournamentController _tournamentController;
        private ReportRepository _reportRepository;
        private LoadFonts _loadFonts;

        public StatisticsForm(Tournament tournament)
        {
            InitializeComponent();
            _tournament = tournament;
            _tournamentController = new TournamentController();
            _reportRepository = new ReportRepository();

            try
            {
                _loadFonts = new LoadFonts();
                ApplyInterFont();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading fonts: {ex.Message}");
            }

            LoadStatistics();
        }

        private void ApplyInterFont()
        {
            Font interFont = _loadFonts.GetFont("Inter", 9f);
            Font interFontBold = _loadFonts.GetFont("Inter", 10f, FontStyle.Bold);
            Font interFontTitle = _loadFonts.GetFont("Inter", 11f, FontStyle.Bold);

            this.Font = interFont;

            tbcStatistics.Font = interFontBold;

            lblStandingsTitle.Font = interFontTitle;
            lblTopScorersTitle.Font = interFontTitle;

            dgvStandings.Font = interFont;
            dgvTopScorers.Font = interFont;

            dgvStandings.ColumnHeadersDefaultCellStyle.Font = interFontBold;
            dgvTopScorers.ColumnHeadersDefaultCellStyle.Font = interFontBold;
        }

        private void LoadStatistics()
        {
            LoadStandings();
            LoadTopScorers();
        }

        private void LoadStandings()
        {
            try
            {
                var standings = _tournamentController.GetStandingsByTournament(_tournament.Id);

                var standingsData = standings.Select((team, index) => new
                {
                    Posicion = index + 1,
                    Equipo = team.Name,
                    Puntos = team.Points,
                    GolesAFavor = team.GoalsFor,
                    GolesEnContra = team.GoalsAgainst,
                    DiferenciaGoles = team.GoalsFor - team.GoalsAgainst,
                    Entrenador = team.Manager,
                    Ubicacion = team.OriginLocation
                }).ToList();

                dgvStandings.DataSource = standingsData;

                if (dgvStandings.Columns.Count > 0)
                {
                    dgvStandings.Columns["Posicion"].HeaderText = "Pos";
                    dgvStandings.Columns["Posicion"].Width = 50;

                    dgvStandings.Columns["Equipo"].HeaderText = "Equipo";
                    dgvStandings.Columns["Equipo"].Width = 180;

                    dgvStandings.Columns["Puntos"].HeaderText = "Pts";
                    dgvStandings.Columns["Puntos"].Width = 60;

                    dgvStandings.Columns["GolesAFavor"].HeaderText = "GF";
                    dgvStandings.Columns["GolesAFavor"].Width = 50;

                    dgvStandings.Columns["GolesEnContra"].HeaderText = "GC";
                    dgvStandings.Columns["GolesEnContra"].Width = 50;

                    dgvStandings.Columns["DiferenciaGoles"].HeaderText = "DG";
                    dgvStandings.Columns["DiferenciaGoles"].Width = 50;

                    dgvStandings.Columns["Entrenador"].HeaderText = "Entrenador";
                    dgvStandings.Columns["Entrenador"].Width = 150;

                    dgvStandings.Columns["Ubicacion"].HeaderText = "Ubicación";
                    dgvStandings.Columns["Ubicacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                ColorStandingsRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tabla de posiciones: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorStandingsRows()
        {
            if (dgvStandings.Rows.Count > 0)
            {
                if (dgvStandings.Rows.Count >= 1)
                {
                    dgvStandings.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                    dgvStandings.Rows[0].DefaultCellStyle.ForeColor = Color.FromArgb(184, 134, 11);
                }

                if (dgvStandings.Rows.Count >= 2)
                {
                    dgvStandings.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    dgvStandings.Rows[1].DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                }

                if (dgvStandings.Rows.Count >= 3)
                {
                    dgvStandings.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    dgvStandings.Rows[2].DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                }
            }
        }

        private void LoadTopScorers()
        {
            try
            {
                DataTable topScorersData = _reportRepository.GetTop10Players();

                if (topScorersData != null && topScorersData.Rows.Count > 0)
                {
                    dgvTopScorers.DataSource = topScorersData;

                    if (dgvTopScorers.Columns.Count > 0)
                    {
                        dgvTopScorers.Columns["CEDULA"].HeaderText = "Cédula";
                        dgvTopScorers.Columns["CEDULA"].Width = 120;

                        dgvTopScorers.Columns["NOMBRE"].HeaderText = "Jugador";
                        dgvTopScorers.Columns["NOMBRE"].Width = 200;

                        dgvTopScorers.Columns["NOMBRE_EQUIPO"].HeaderText = "Equipo";
                        dgvTopScorers.Columns["NOMBRE_EQUIPO"].Width = 180;

                        dgvTopScorers.Columns["CANTIDAD_GOLES"].HeaderText = "Goles";
                        dgvTopScorers.Columns["CANTIDAD_GOLES"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    
                    AddPositionColumn();

                    ColorTopScorersRows();
                }
                else
                {
                    dgvTopScorers.DataSource = null;
                    ShowEmptyTopScorersMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar máximos goleadores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPositionColumn()
        {
            if (dgvTopScorers.Columns["Position"] == null)
            {
                DataGridViewTextBoxColumn positionColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Position",
                    HeaderText = "Pos",
                    Width = 50,
                    ReadOnly = true
                };

                dgvTopScorers.Columns.Insert(0, positionColumn);

                for (int i = 0; i < dgvTopScorers.Rows.Count; i++)
                {
                    dgvTopScorers.Rows[i].Cells["Position"].Value = (i + 1).ToString();
                }
            }
        }

        private void ColorTopScorersRows()
        {
            if (dgvTopScorers.Rows.Count > 0)
            {
                if (dgvTopScorers.Rows.Count >= 1)
                {
                    dgvTopScorers.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                    dgvTopScorers.Rows[0].DefaultCellStyle.ForeColor = Color.FromArgb(184, 134, 11);
                }

                if (dgvTopScorers.Rows.Count >= 2)
                {
                    dgvTopScorers.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    dgvTopScorers.Rows[1].DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                }

                if (dgvTopScorers.Rows.Count >= 3)
                {
                    dgvTopScorers.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    dgvTopScorers.Rows[2].DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                }
            }
        }

        private void ShowEmptyTopScorersMessage()
        {
            lblNoScorers.Visible = true;
            lblNoScorers.Text = "No hay goleadores registrados en este torneo.";
            lblNoScorers.ForeColor = Color.Gray;
            lblNoScorers.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
                MessageBox.Show("Estadísticas actualizadas correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar estadísticas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Estadísticas - {_tournament.Name}";

            if (lblNoScorers != null)
                lblNoScorers.Visible = false;
        }
    }
}