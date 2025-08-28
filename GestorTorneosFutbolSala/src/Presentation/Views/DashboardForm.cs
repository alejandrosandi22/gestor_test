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
            this.MaximumSize = new Size(1152, 700);
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
                    BackColor = Color.White
                };

                Label titleLabel = new Label
                {
                    Text = "Estadísticas Generales",
                    Font = loadFonts.SetDefaultFont(20f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    Location = new Point(20, 20),
                    AutoSize = true
                };
                scrollablePanel.Controls.Add(titleLabel);

                Panel kpiPanel = new Panel
                {
                    Location = new Point(20, 60),
                    Size = new Size(1100, 200),
                    AutoSize = false,
                    BackColor = Color.White
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

                CreateKpiControl(kpiPanel, "Total de Torneos", totalTournaments.ToString(), 0, 0);
                CreateKpiControl(kpiPanel, "Total de Equipos", totalTeams.ToString(), 366, 0);
                CreateKpiControl(kpiPanel, "Total de Jugadores", $"{totalPlayers} ({avgPlayersPerTeam} promedio por equipo)", 733, 0);
                CreateKpiControl(kpiPanel, "Partidos Jugados", playedMatches.ToString(), 0, 100);
                CreateKpiControl(kpiPanel, "Recaudación por Sanciones", $"₡{totalFines:N2}", 366, 100);
                CreateKpiControl(kpiPanel, "Goles Totales Anotados", totalGoals.ToString(), 733, 100);

                scrollablePanel.Controls.Add(kpiPanel);

                Panel tablePanel = new Panel
                {
                    Location = new Point(20, 280),
                    Size = new Size(1100, 300),
                    BackColor = Color.White
                };

                Label tableTitle = new Label
                {
                    Text = "4 Mejores Equipos Globales (por promedio de puntos)",
                    Font = loadFonts.SetDefaultFont(16f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 204),
                    Location = new Point(0, 0),
                    AutoSize = true
                };
                tablePanel.Controls.Add(tableTitle);

                var allTeams = teamService.GetAll().OrderByDescending(t => t.Points).Take(4).ToList();

                DataGridView dgvTeams = new DataGridView
                {
                    Location = new Point(0, 40),
                    Size = new Size(1100, 250),
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true,
                    RowHeadersVisible = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    BorderStyle = BorderStyle.None,
                    AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(245, 245, 245) },
                    GridColor = Color.FromArgb(230, 230, 230)
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
                scrollablePanel.Controls.Add(tablePanel);

                pnlContent.Controls.Add(scrollablePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las estadísticas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateKpiControl(Panel parentPanel, string title, string value, int x, int y)
        {
            Panel kpiContainer = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(350, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = loadFonts.SetDefaultFont(12f, FontStyle.Regular),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = loadFonts.SetDefaultFont(18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 204),
                Location = new Point(10, 35),
                AutoSize = true
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