using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.Domain.Services;
using GestorTorneosFutbolSala.Infrastructure.Repositories;
using GestorTorneosFutbolSala.src.Infrastructure.Repositories;
using GestorTorneosFutbolSala.src.Views;
using GestorTorneosFutbolSala.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class DashboardForm : Form
    {
        private LoadFonts loadFonts = new LoadFonts();
        private User currentUser;
        private TournamentService tournamentService;
        private TeamService teamService;
        private PlayerService playerService;
        private MatchService matchService;
        private FineService fineService;
        private ReportRepository reportRepository;

        public DashboardForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
            InitializeServices();
            SetupForm();
            SetupHeaderControls();

            ViewManager.RegisterDashbaordPanels(pnlContent);

            LoadDashboardData();
        }

        private void InitializeServices()
        {
            tournamentService = new TournamentService();
            teamService = new TeamService();
            playerService = new PlayerService();
            matchService = new MatchService();
            fineService = new FineService();
            reportRepository = new ReportRepository();
        }

        private void SetupForm()
        {
            this.Size = new Size(1151, 689);
            this.MaximumSize = new Size(1535, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            btnUserSession.Text = currentUser.Name;
            btnUserSession.Font = loadFonts.SetDefaultFont(14f, FontStyle.Regular);
            btnUserSession.FlatAppearance.BorderSize = 0;
            btnUserSession.FlatStyle = FlatStyle.Flat;
            btnUserSession.BackColor = Color.White;

            userSessionMenu.Font = loadFonts.SetDefaultFont(12f, FontStyle.Regular);
            userSessionMenu.BackColor = Color.White;
            userSessionMenu.ForeColor = Color.FromArgb(0, 102, 204);
            userSessionMenu.RenderMode = ToolStripRenderMode.Professional;
            userSessionMenu.ShowImageMargin = false;

            roleItem.Text = $"Rol: {currentUser.Role}";
            roleItem.ForeColor = Color.FromArgb(0, 102, 204);
            roleItem.Font = new Font(loadFonts.SetDefaultFont(12f, FontStyle.Regular), FontStyle.Bold);
            roleItem.Enabled = false;

            logoutItem.BackColor = Color.FromArgb(0, 102, 204);
            logoutItem.ForeColor = Color.White;
            logoutItem.Click += (s, e) =>
            {
                ViewManager.ShowFormInPanel(new LoginForm(), TargetPanel.MAIN);
            };

            btnUserSession.ContextMenuStrip = userSessionMenu;
        }

        private void SetupHeaderControls()
        {
            Label[] menuLabels = { lblHome, lblTournaments, lblUsers, lblReports };
            Action[] actions = {
                () => OpenHome(),
                () => OpenTournaments(),
                () => OpenUsers(),
                () => OpenReports()
            };

            AddHoverEffect(menuLabels, actions);
        }

        private void AddHoverEffect(Label[] menuLabels, Action[] actions)
        {
            for (int i = 0; i < menuLabels.Length; i++)
            {
                Label label = menuLabels[i];
                Action action = actions[i];

                label.Font = loadFonts.SetDefaultFont(14f, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(64, 64, 64);

                Color originalBackColor = label.BackColor;
                Color originalForeColor = label.ForeColor;

                label.Cursor = Cursors.Hand;

                label.Click += (sender, e) => action();

                label.MouseEnter += (sender, e) =>
                {
                    label.BackColor = Color.FromArgb(252, 252, 252);
                    label.ForeColor = Color.FromArgb(0, 102, 204);
                };

                label.MouseLeave += (sender, e) =>
                {
                    label.BackColor = originalBackColor;
                    label.ForeColor = originalForeColor;
                };
            }
        }

        private void LoadDashboardData()
        {
            try
            {
                pnlContent.Controls.Clear();

                Panel scrollablePanel = new Panel
                {
                    AutoScroll = true,
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Padding = new Padding(10),
                    AutoSize = false
                };

                Panel contentWrapper = new Panel
                {
                    Width = 900,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Location = new Point(0, 0),
                    MaximumSize = new Size(1000, 0),
                    BackColor = Color.Transparent
                };

                Label titleLabel = new Label
                {
                    Text = "Estadísticas Generales",
                    Font = loadFonts.SetDefaultFont(20f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    AutoSize = true,
                    MaximumSize = new Size(1000, 0)
                };
                contentWrapper.Controls.Add(titleLabel);

                Panel kpiPanel = new Panel
                {
                    Location = new Point(0, titleLabel.Bottom + 20),
                    Size = new Size(1000, 200),
                    AutoSize = false,
                    BackColor = Color.Transparent
                };

                int totalTournaments = tournamentService.GetAll().Count;
                int totalTeams = teamService.GetAll().Count;
                int totalPlayers = playerService.GetAll().Count;
                int avgPlayersPerTeam = totalTeams > 0 ? totalPlayers / totalTeams : 0;
                int playedMatches = matchService.GetAll().Count(m => m.HomeGoals > 0 || m.AwayGoals > 0);

                decimal totalFines = 0;
                var fines = fineService.GetAll();
                totalFines = fines.Where(f => f.Paid).Sum(f => f.Amount);

                int totalGoals = matchService.GetAll().Sum(m => m.HomeGoals + m.AwayGoals);

                int kpiWidth = 280;
                int gap = (900 - (kpiWidth * 3)) / 4;

                CreateKpiControl(kpiPanel, "Total de Torneos", totalTournaments.ToString(), gap, 0, kpiWidth);
                CreateKpiControl(kpiPanel, "Total de Equipos", totalTeams.ToString(), gap * 2 + kpiWidth, 0, kpiWidth);
                CreateKpiControl(kpiPanel, "Total de Jugadores", $"{totalPlayers}", gap * 3 + kpiWidth * 2, 0, kpiWidth);
                CreateKpiControl(kpiPanel, "Partidos Jugados", playedMatches.ToString(), gap, 100, kpiWidth);
                CreateKpiControl(kpiPanel, "Recaudación por Sanciones", $"₡{totalFines:N2}", gap * 2 + kpiWidth, 100, kpiWidth);
                CreateKpiControl(kpiPanel, "Goles Totales Anotados", totalGoals.ToString(), gap * 3 + kpiWidth * 2, 100, kpiWidth);

                contentWrapper.Controls.Add(kpiPanel);

                Panel tablePanel = new Panel
                {
                    Location = new Point(0, kpiPanel.Bottom + 20),
                    Width = 1000,
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                Label tableTitle = new Label
                {
                    Text = "4 Mejores Equipos Globales (por promedio de puntos)",
                    Font = loadFonts.SetDefaultFont(16f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    AutoSize = true,
                    MaximumSize = new Size(1000, 0)
                };
                tablePanel.Controls.Add(tableTitle);

                var allTeams = teamService.GetAll().OrderByDescending(t => t.Points).Take(4).ToList();

                DataGridView dgvTeams = new DataGridView
                {
                    Location = new Point(0, tableTitle.Bottom + 10),
                    Width = 900,
                    Height = 250,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true,
                    RowHeadersVisible = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    BorderStyle = BorderStyle.None,
                    AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(245, 245, 245) },
                    GridColor = Color.FromArgb(230, 230, 230),
                    ScrollBars = ScrollBars.Vertical
                };

                dgvTeams.Columns.Add("Rank", "#");
                dgvTeams.Columns.Add("TeamName", "Nombre del Equipo");
                dgvTeams.Columns.Add("Points", "Puntos");
                dgvTeams.Columns.Add("GoalsFor", "Goles a Favor");
                dgvTeams.Columns.Add("GoalsAgainst", "Goles en Contra");
                dgvTeams.Columns.Add("GoalDifference", "Diferencia de Goles");

                foreach (DataGridViewColumn column in dgvTeams.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.FromArgb(0, 102, 204);
                    column.HeaderCell.Style.ForeColor = Color.White;
                    column.HeaderCell.Style.Font = loadFonts.SetDefaultFont(12f, FontStyle.Bold);
                }

                for (int i = 0; i < allTeams.Count; i++)
                {
                    var team = allTeams[i];
                    dgvTeams.Rows.Add(
                        i + 1,
                        team.Name,
                        team.Points,
                        team.GoalsFor,
                        team.GoalsAgainst,
                        team.GoalsFor - team.GoalsAgainst
                    );
                }

                tablePanel.Controls.Add(dgvTeams);
                contentWrapper.Controls.Add(tablePanel);

                scrollablePanel.Controls.Add(contentWrapper);
                pnlContent.Controls.Add(scrollablePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las estadísticas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateKpiControl(Panel parentPanel, string title, string value, int x, int y, int width)
        {
            Panel kpiContainer = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = loadFonts.SetDefaultFont(12f, FontStyle.Regular),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(10, 10),
                AutoSize = true,
                MaximumSize = new Size(width - 20, 0)
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = loadFonts.SetDefaultFont(18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(10, 35),
                AutoSize = true,
                MaximumSize = new Size(width - 20, 0)
            };

            kpiContainer.Controls.Add(titleLabel);
            kpiContainer.Controls.Add(valueLabel);
            parentPanel.Controls.Add(kpiContainer);
        }

        private void OpenHome()
        {
            LoadDashboardData();
        }

        private void OpenTournaments()
        {
            try
            {
                ViewManager.ShowFormInPanel(new TournamentForm(currentUser), TargetPanel.DASHBOARD);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir torneos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenUsers()
        {
            try
            {
                if (this.currentUser.Role.Equals(UserRoleEnum.Administrador))
                {
                    ViewManager.ShowFormInPanel(new UsersForm(), TargetPanel.DASHBOARD);
                }
                else
                {
                    MessageBox.Show("No tiene permisos para acceder a este apartado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenReports()
        {
            try
            {
                ViewManager.ShowFormInPanel(new ReportsForm(), TargetPanel.DASHBOARD);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir reportes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
            {
                e.Graphics.DrawLine(pen, 0, 60, this.Width, 60);
            }
        }

        private void btnUserSession_Click(object sender, EventArgs e)
        {
            userSessionMenu.Show(btnUserSession, new Point(0, btnUserSession.Height));
        }
    }
}