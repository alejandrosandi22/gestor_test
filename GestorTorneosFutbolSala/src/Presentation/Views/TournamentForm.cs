using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class TournamentForm : Form
    {
        private List<Tournament> tournaments;
        private List<Tournament> filteredTournaments;
        private LoadFonts fontLoader;
        private Dictionary<string, Font> fontCache;
        private Timer searchTimer;
        private bool isUpdating = false;

        private TournamentController tournamentController;
        private TeamController teamController;
        private User _currentUser;

        public TournamentForm(User currentUser)
        {
            InitializeComponent();

            tournamentController = new TournamentController();
            teamController = new TeamController();

            _currentUser = currentUser;

            InitializeFontLoader();
            InitializeFontCache();
            InitializeSearchTimer();
            InitializeTournamentGrid();
            InitializeFilters();
            LoadTournaments();
        }

        private void InitializeFontLoader()
        {
            try
            {
                fontLoader = new LoadFonts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading fonts: {ex.Message}");
                fontLoader = null;
            }
        }

        private void InitializeFontCache()
        {
            fontCache = new Dictionary<string, Font>();
        }

        private void InitializeSearchTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 300;
            searchTimer.Tick += (s, e) =>
            {
                searchTimer.Stop();
                ApplyFilters();
            };
        }

        private void InitializeTournamentGrid()
        {
            flpGridPanel.SuspendLayout();
            flpGridPanel.AutoScroll = true;
            flpGridPanel.FlowDirection = FlowDirection.LeftToRight;
            flpGridPanel.WrapContents = true;
            flpGridPanel.Padding = new Padding(10);
            flpGridPanel.ResumeLayout(false);
        }

        private void InitializeFilters()
        {
            InitializeSearchTextBoxPlaceholder();
            txtSearch.KeyDown += OnSearchKeyDown;

            PopulateYearComboBox();
            cmbYears.SelectedIndexChanged += OnFilterChanged;

            PopulateGenderComboBox();
            cmbGenders.SelectedIndexChanged += OnFilterChanged;

            PopulateAgeCategoryComboBox();
            cmbAge.SelectedIndexChanged += OnFilterChanged;

            btnCleanFilters.Click += OnCleanFilters;
        }

        private void InitializeSearchTextBoxPlaceholder()
        {
            txtSearch.Text = "Buscar torneos...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Font = GetInterFont(12);

            txtSearch.GotFocus += (sender, e) =>
            {
                if (txtSearch.Text == "Buscar torneos...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Buscar torneos...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            txtSearch.TextChanged += OnSearchTextChanged;
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Buscar torneos...")
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
        }

        private void PopulateYearComboBox()
        {
            cmbYears.Items.Clear();
            cmbYears.Items.Add("Todos los años");

            if (tournaments != null && tournaments.Any())
            {
                var years = tournaments.Select(t => t.Year).Distinct().OrderByDescending(y => y);
                foreach (var year in years)
                {
                    cmbYears.Items.Add(year.ToString());
                }
            }
            else
            {
                for (int year = DateTime.Now.Year; year >= 2020; year--)
                {
                    cmbYears.Items.Add(year.ToString());
                }
            }

            cmbYears.SelectedIndex = 0;
        }

        private void PopulateGenderComboBox()
        {
            cmbGenders.Items.Clear();
            cmbGenders.Items.Add("Todos los géneros");

            if (tournaments != null && tournaments.Any())
            {
                var genders = tournaments.Select(t => t.Gender).Distinct();
                foreach (var gender in genders)
                {
                    cmbGenders.Items.Add(GetGenderText(gender));
                }
            }
            else
            {
                cmbGenders.Items.Add("Masculino");
                cmbGenders.Items.Add("Femenino");
                cmbGenders.Items.Add("Mixto");
            }

            cmbGenders.SelectedIndex = 0;
        }

        private void PopulateAgeCategoryComboBox()
        {
            cmbAge.Items.Clear();
            cmbAge.Items.Add("Todas las edades");

            if (tournaments != null && tournaments.Any())
            {
                var ageCategories = tournaments.Select(t => t.AgeCategory).Distinct().OrderBy(a => a);
                foreach (var age in ageCategories)
                {
                    cmbAge.Items.Add(GetAgeCategoryText(age));
                }
            }
            else
            {
                cmbAge.Items.Add("Adultos");
                cmbAge.Items.Add("Sub-21");
                cmbAge.Items.Add("Sub-18");
                cmbAge.Items.Add("Sub-16");
                cmbAge.Items.Add("Sub-14");
                cmbAge.Items.Add("Sub-12");
            }

            cmbAge.SelectedIndex = 0;
        }

        private Font GetInterFont(float size, FontStyle style = FontStyle.Regular)
        {
            string key = $"Inter-{size}-{style}";

            if (fontCache.ContainsKey(key))
                return fontCache[key];

            Font font;
            if (fontLoader != null)
            {
                try
                {
                    font = fontLoader.GetFont("Inter", size, style);
                }
                catch
                {
                    font = new Font("Segoe UI", size, style);
                }
            }
            else
            {
                font = new Font("Segoe UI", size, style);
            }

            fontCache[key] = font;
            return font;
        }

        private void LoadTournaments()
        {
            try
            {
                tournaments = tournamentController.GetAllTournaments();
                if (tournaments == null)
                    tournaments = new List<Tournament>();

                filteredTournaments = new List<Tournament>(tournaments);

                PopulateYearComboBox();
                PopulateGenderComboBox();
                PopulateAgeCategoryComboBox();

                RenderTournamentCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los torneos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tournaments = new List<Tournament>();
                filteredTournaments = new List<Tournament>();
            }
        }

        private void RenderTournamentCards()
        {
            if (isUpdating) return;

            isUpdating = true;
            flpGridPanel.SuspendLayout();
            flpGridPanel.Controls.Clear();

            if (_currentUser != null && _currentUser.Role == UserRoleEnum.Administrador)
            {
                var newTournamentCard = CreateNewTournamentCard();
                flpGridPanel.Controls.Add(newTournamentCard);
            }

            foreach (var tournament in filteredTournaments)
            {
                var tournamentCard = CreateTournamentCard(tournament);
                flpGridPanel.Controls.Add(tournamentCard);
            }

            flpGridPanel.ResumeLayout(true);
            UpdateResultsLabel();
            isUpdating = false;
        }

        private Panel CreateNewTournamentCard()
        {
            var card = new Panel
            {
                Size = new Size(315, 200),
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            var iconLabel = new Label
            {
                Text = "+",
                Font = GetInterFont(48, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 130, 180),
                Size = new Size(60, 60),
                Location = new Point(127, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var titleLabel = new Label
            {
                Text = "Nuevo Torneo",
                Font = GetInterFont(14, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Size = new Size(295, 30),
                Location = new Point(10, 120),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var subtitleLabel = new Label
            {
                Text = "Crear un nuevo torneo",
                Font = GetInterFont(10),
                ForeColor = Color.FromArgb(120, 120, 120),
                Size = new Size(295, 20),
                Location = new Point(10, 150),
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(iconLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(subtitleLabel);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(248, 249, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Click += OnNewTournamentClick;
            iconLabel.Click += OnNewTournamentClick;
            titleLabel.Click += OnNewTournamentClick;
            subtitleLabel.Click += OnNewTournamentClick;

            return card;
        }

        private Panel CreateTournamentCard(Tournament tournament)
        {
            var card = new Panel
            {
                Size = new Size(315, 200),
                BackColor = Color.White,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = tournament
            };

            var statusPanel = new Panel
            {
                Size = new Size(295, 4),
                Location = new Point(10, 10),
                BackColor = GetTournamentStatusColor(tournament)
            };

            var nameLabel = new Label
            {
                Text = tournament.Name,
                Font = GetInterFont(12, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50),
                Size = new Size(295, 40),
                Location = new Point(10, 25),
                AutoEllipsis = true
            };

            var yearLabel = new Label
            {
                Text = $"Año: {tournament.Year}",
                Font = GetInterFont(10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Size = new Size(140, 20),
                Location = new Point(10, 75)
            };

            var genderLabel = new Label
            {
                Text = $"Género: {GetGenderText(tournament.Gender)}",
                Font = GetInterFont(10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Size = new Size(140, 20),
                Location = new Point(10, 100)
            };

            var ageLabel = new Label
            {
                Text = $"Categoría: {GetAgeCategoryText(tournament.AgeCategory)}",
                Font = GetInterFont(10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Size = new Size(140, 20),
                Location = new Point(10, 125)
            };

            int teamCount = 0;
            try
            {
                var teams = teamController.GetTeamsByTournament(tournament.Id);
                teamCount = teams?.Count ?? 0;
            }
            catch
            {
                teamCount = 0;
            }

            var teamsLabel = new Label
            {
                Text = $"Equipos: {teamCount}",
                Font = GetInterFont(9),
                ForeColor = Color.FromArgb(120, 120, 120),
                Size = new Size(150, 20),
                Location = new Point(10, 150)
            };

            var dateLabel = new Label
            {
                Text = tournament.CreatedDate.ToString("dd/MM/yyyy"),
                Font = GetInterFont(9),
                ForeColor = Color.FromArgb(120, 120, 120),
                Size = new Size(140, 20),
                Location = new Point(170, 150)
            };

            card.Controls.AddRange(new Control[] { statusPanel, nameLabel, yearLabel, genderLabel, ageLabel, teamsLabel, dateLabel });

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(248, 249, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Click += (s, e) => OnTournamentClick(tournament);

            return card;
        }

        private string GetGenderText(GenderCategoryEnum gender)
        {
            switch (gender)
            {
                case GenderCategoryEnum.Male:
                    return "Masculino";
                case GenderCategoryEnum.Female:
                    return "Femenino";
                case GenderCategoryEnum.Mixed:
                    return "Mixto";
                default:
                    return "No especificado";
            }
        }

        private string GetAgeCategoryText(int ageCategory)
        {
            return ageCategory == 0 ? "Adultos" : $"Sub-{ageCategory}";
        }

        private Color GetTournamentStatusColor(Tournament tournament)
        {
            try
            {
                var teams = teamController.GetTeamsByTournament(tournament.Id);
                var hasTeams = teams != null && teams.Count > 0;

                if (hasTeams)
                    return Color.FromArgb(34, 197, 94);
                else
                    return Color.FromArgb(251, 191, 36);
            }
            catch
            {
                return Color.FromArgb(156, 163, 175);
            }
        }

        private void UpdateResultsLabel()
        {
            var count = filteredTournaments?.Count ?? 0;
            lblResultsFound.Text = $"{count} torneo{(count != 1 ? "s" : "")} encontrado{(count != 1 ? "s" : "")}";
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
                ApplyFilters();
        }

        private void OnSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTimer.Stop();
                ApplyFilters();
                e.Handled = true;
            }
        }

        private void OnCleanFilters(object sender, EventArgs e)
        {
            isUpdating = true;

            txtSearch.Text = "Buscar torneos...";
            txtSearch.ForeColor = Color.Gray;

            cmbYears.SelectedIndex = 0;
            cmbGenders.SelectedIndex = 0;
            cmbAge.SelectedIndex = 0;

            isUpdating = false;
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (tournaments == null || isUpdating) return;

            string searchText = txtSearch.Text == "Buscar torneos..." ? "" : txtSearch.Text.Trim();
            string year = cmbYears.SelectedItem?.ToString() ?? "Todos los años";
            string gender = cmbGenders.SelectedItem?.ToString() ?? "Todos los géneros";
            string ageCategory = cmbAge.SelectedItem?.ToString() ?? "Todas las edades";

            FilterTournaments(searchText, year, gender, ageCategory);
        }

        public void FilterTournaments(string searchText = "", string year = "", string gender = "", string ageCategory = "")
        {
            if (tournaments == null) return;

            var filtered = tournaments.AsEnumerable();

            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(t =>
                    t.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrEmpty(year) && year != "Todos los años")
            {
                if (int.TryParse(year, out int yearInt))
                {
                    filtered = filtered.Where(t => t.Year == yearInt);
                }
            }

            if (!string.IsNullOrEmpty(gender) && gender != "Todos los géneros")
            {
                GenderCategoryEnum genderEnum;
                if (gender.ToLower() == "masculino")
                {
                    genderEnum = GenderCategoryEnum.Male;
                }
                else if (gender.ToLower() == "femenino")
                {
                    genderEnum = GenderCategoryEnum.Female;
                }
                else if (gender.ToLower() == "mixto")
                {
                    genderEnum = GenderCategoryEnum.Mixed;
                }
                else
                {
                    return;
                }

                filtered = filtered.Where(t => t.Gender == genderEnum);
            }

            if (!string.IsNullOrEmpty(ageCategory) && ageCategory != "Todas las edades")
            {
                if (ageCategory.ToLower() == "adultos")
                {
                    filtered = filtered.Where(t => t.AgeCategory == 0);
                }
                else if (ageCategory.StartsWith("Sub-") && int.TryParse(ageCategory.Substring(4), out int age))
                {
                    filtered = filtered.Where(t => t.AgeCategory == age);
                }
            }

            filteredTournaments = filtered.ToList();
            RenderTournamentCards();
        }

        private void OnNewTournamentClick(object sender, EventArgs e)
        {
            ViewManager.ShowFormInPanel(new TournamentEntryForm(_currentUser), TargetPanel.DASHBOARD);
        }

        private void OnTournamentClick(Tournament tournament)
        {
            ViewManager.ShowFormInPanel(new TournamentDetailsForm(tournament), TargetPanel.DASHBOARD);
        }
    }
}