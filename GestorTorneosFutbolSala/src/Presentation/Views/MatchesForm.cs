using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class MatchesForm : Form
    {
        private List<Match> matches;
        private LoadFonts fontLoader;
        private const int PANEL_WIDTH = 776;
        private int _tournamentId;
        private Tournament _tournament;

        private MatchController _matchController;
        private TeamController _teamController;
        private TournamentController _tournamentController;

        private Dictionary<int, Team> _teamsCache;
        private Font _headerFont;
        private Font _regularFont;
        private Font _boldFont;
        private Font _dateFont;

        public MatchesForm(int tournamentId)
        {
            _tournamentId = tournamentId;
            _matchController = new MatchController();
            _teamController = new TeamController();
            _tournamentController = new TournamentController();

            InitializeComponent();

            InitializeFontsAsync();
            LoadDataAsync();
        }

        private async void InitializeFontsAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    fontLoader = new LoadFonts();
                    _headerFont = GetInterFont(12F, FontStyle.Bold);
                    _regularFont = GetInterFont(10F);
                    _boldFont = GetInterFont(11F, FontStyle.Bold);
                    _dateFont = GetInterFont(9F, FontStyle.Bold);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading fonts: {ex.Message}");
                    _headerFont = new Font("Segoe UI", 12F, FontStyle.Bold);
                    _regularFont = new Font("Segoe UI", 10F);
                    _boldFont = new Font("Segoe UI", 11F, FontStyle.Bold);
                    _dateFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            });
        }

        private async void LoadDataAsync()
        {
            this.UseWaitCursor = true;

            try
            {
                await Task.Run(() =>
                {
                    LoadTournamentData();
                    LoadTeamsCache();
                });

                LoadMatches();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private Font GetInterFont(float size, FontStyle style = FontStyle.Regular)
        {
            if (fontLoader != null)
            {
                try
                {
                    return fontLoader.GetFont("Inter", size, style);
                }
                catch
                {
                }
            }
            return new Font("Segoe UI", size, style);
        }

        private void LoadTournamentData()
        {
            try
            {
                int tournamentExists = _tournamentController.GetTournamentById(_tournamentId);
                if (tournamentExists == 0)
                {
                    throw new Exception($"No se encontró el torneo con ID {_tournamentId}");
                }

                var tournaments = _tournamentController.GetAllTournaments();
                _tournament = tournaments.FirstOrDefault(t => t.Id == _tournamentId);

                if (_tournament == null)
                {
                    throw new Exception($"No se pudo cargar la información del torneo con ID {_tournamentId}");
                }

                matches = _matchController.GetMatchesByTournament(_tournamentId);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No se encontraron partidos"))
                {
                    matches = new List<Match>();
                }
                else
                {
                    throw;
                }
            }
        }

        private void LoadTeamsCache()
        {
            try
            {
                var allTeams = _teamController.GetAllTeams();
                _teamsCache = allTeams?.ToDictionary(t => t.Id, t => t) ?? new Dictionary<int, Team>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading teams cache: {ex.Message}");
                _teamsCache = new Dictionary<int, Team>();
            }
        }

        private void LoadMatches()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LoadMatches));
                return;
            }

            pnlFirstPhase.SuspendLayout();
            pnlSemifinals.SuspendLayout();
            pnlFinal.SuspendLayout();
            pnlFirstPhase.Controls.Clear();
            pnlSemifinals.Controls.Clear();
            pnlFinal.Controls.Clear();

            if (matches == null || matches.Count == 0)
            {
                ShowGenerateFirstPhaseButton();
                ShowPhaseMessage(pnlSemifinals, "Las semifinales se generarán cuando termine la fase regular");
                ShowPhaseMessage(pnlFinal, "La final se generará cuando terminen las semifinales");
                pnlFirstPhase.ResumeLayout();
                pnlSemifinals.ResumeLayout();
                pnlFinal.ResumeLayout();
                return;
            }

            var teams = GetTournamentTeams();
            int firstPhaseRounds = teams.Count > 0 ? (teams.Count - 1) * 2 : 0;

            var firstPhaseMatches = matches.Where(m => m.RoundNumber <= firstPhaseRounds).ToList();
            var semifinalMatches = matches.Where(m => m.RoundNumber == firstPhaseRounds + 1).ToList();
            var finalMatches = matches.Where(m => m.RoundNumber == firstPhaseRounds + 2).ToList();

            LoadPhaseMatches(firstPhaseMatches, pnlFirstPhase, "primera");
            LoadPhaseMatches(semifinalMatches, pnlSemifinals, "semifinal");
            LoadPhaseMatches(finalMatches, pnlFinal, "final");

            pnlFirstPhase.ResumeLayout();
            pnlSemifinals.ResumeLayout();
            pnlFinal.ResumeLayout();
        }

        private List<Team> GetTournamentTeams()
        {
            try
            {
                return _teamController.GetTeamsByTournament(_tournamentId);
            }
            catch
            {
                return new List<Team>();
            }
        }

        private void LoadPhaseMatches(List<Match> phaseMatches, Panel targetPanel, string phaseType)
        {
            if (phaseMatches.Count == 0)
            {
                if (phaseType == "primera")
                {
                    ShowGenerateFirstPhaseButton();
                }
                else if (phaseType == "semifinal")
                {
                    ShowPhaseMessage(targetPanel, "Las semifinales se generarán cuando termine la fase regular");
                }
                else if (phaseType == "final")
                {
                    ShowPhaseMessage(targetPanel, "La final se generará cuando terminen las semifinales");
                }
                return;
            }

            var matchesByRound = phaseMatches
                .GroupBy(m => m.RoundNumber)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.OrderBy(m => m.DateTime).ToList());

            int yPosition = 10;
            var controlsToAdd = new List<Control>();

            foreach (var round in matchesByRound)
            {
                var roundHeader = CreateRoundHeader(round.Key, yPosition, phaseType);
                controlsToAdd.Add(roundHeader);
                yPosition += 45;

                foreach (var match in round.Value)
                {
                    var matchPanel = CreateMatchPanel(match, yPosition);
                    controlsToAdd.Add(matchPanel);
                    yPosition += 80;
                }

                yPosition += 15;
            }

            if (phaseType == "primera" && ShouldShowGenerateNextPhaseButton())
            {
                var nextPhaseButton = CreateNextPhaseButton(yPosition);
                controlsToAdd.Add(nextPhaseButton);
            }

            targetPanel.Controls.AddRange(controlsToAdd.ToArray());
            targetPanel.AutoScroll = true;
        }

        private void ShowPhaseMessage(Panel targetPanel, string message)
        {
            Panel pnlEmpty = new Panel
            {
                Location = new Point(10, 50),
                Size = new Size(PANEL_WIDTH, 200),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblMessage = new Label
            {
                Text = message,
                Location = new Point(0, 60),
                Size = new Size(pnlEmpty.Width, 60),
                Font = GetInterFont(12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlEmpty.Controls.Add(lblMessage);
            targetPanel.Controls.Add(pnlEmpty);
        }

        private Panel CreateRoundHeader(int roundNumber, int yPosition, string phaseType)
        {
            Panel pnlRoundHeader = new Panel
            {
                Location = new Point(10, yPosition),
                Size = new Size(PANEL_WIDTH, 40),
                BackColor = Color.FromArgb(0, 102, 204),
                BorderStyle = BorderStyle.None
            };

            string phaseText = GetPhaseText(roundNumber, phaseType);
            Label lblRound = new Label
            {
                Text = $"{phaseText} - JORNADA {roundNumber}",
                Location = new Point(0, 0),
                Size = new Size(pnlRoundHeader.Width, pnlRoundHeader.Height),
                Font = _headerFont,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            pnlRoundHeader.Controls.Add(lblRound);
            return pnlRoundHeader;
        }

        private string GetPhaseText(int roundNumber, string phaseType)
        {
            switch (phaseType)
            {
                case "primera":
                    return "FASE REGULAR";
                case "semifinal":
                    return "SEMIFINALES";
                case "final":
                    return "FINAL";
                default:
                    return "TORNEO";
            }
        }

        private Panel CreateMatchPanel(Match match, int yPosition)
        {
            Panel pnlMatchContainer = new Panel
            {
                Location = new Point(10, yPosition),
                Size = new Size(PANEL_WIDTH, 75),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = match
            };

            Label lblDate = new Label
            {
                Text = match.DateTime.ToString("dd/MM/yyyy HH:mm"),
                Location = new Point(10, 5),
                Size = new Size(pnlMatchContainer.Width - 20, 20),
                Font = _dateFont,
                ForeColor = Color.FromArgb(0, 102, 204),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Panel pnlTeams = new Panel
            {
                Location = new Point(10, 28),
                Size = new Size(pnlMatchContainer.Width - 20, 35),
                BackColor = Color.Transparent
            };

            int teamLabelWidth = (pnlTeams.Width - 100) / 2;

            string homeTeamName = _teamsCache.ContainsKey(match.HomeTeamId) ?
                _teamsCache[match.HomeTeamId].Name : "Equipo Local";
            string awayTeamName = _teamsCache.ContainsKey(match.AwayTeamId) ?
                _teamsCache[match.AwayTeamId].Name : "Equipo Visitante";

            Label lblHomeTeam = new Label
            {
                Text = homeTeamName,
                Location = new Point(0, 8),
                Size = new Size(teamLabelWidth, 20),
                Font = _regularFont,
                TextAlign = ContentAlignment.MiddleRight
            };

            bool isPlayed = match.IsPlayed == 1;
            string scoreText = isPlayed ? $"{match.HomeGoals} - {match.AwayGoals}" : "- - -";

            Label lblScore = new Label
            {
                Text = scoreText,
                Location = new Point(teamLabelWidth, 8),
                Size = new Size(100, 20),
                Font = _boldFont,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = isPlayed ? Color.Black : Color.Gray
            };

            Label lblAwayTeam = new Label
            {
                Text = awayTeamName,
                Location = new Point(teamLabelWidth + 100, 8),
                Size = new Size(teamLabelWidth, 20),
                Font = _regularFont,
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnlTeams.Controls.Add(lblHomeTeam);
            pnlTeams.Controls.Add(lblScore);
            pnlTeams.Controls.Add(lblAwayTeam);

            pnlMatchContainer.Controls.Add(lblDate);
            pnlMatchContainer.Controls.Add(pnlTeams);

            EventHandler clickHandler = (s, e) => MatchPanel_Click(s, e);
            foreach (Control c in pnlMatchContainer.Controls)
            {
                c.Click += clickHandler;
                c.Tag = match;
            }

            pnlMatchContainer.MouseEnter += (s, e) => pnlMatchContainer.BackColor = Color.FromArgb(245, 245, 245);
            pnlMatchContainer.MouseLeave += (s, e) => pnlMatchContainer.BackColor = Color.White;

            return pnlMatchContainer;
        }

        private void ShowGenerateFirstPhaseButton()
        {
            Panel pnlEmpty = new Panel
            {
                Location = new Point(10, 50),
                Size = new Size(PANEL_WIDTH, 200),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblMessage = new Label
            {
                Text = "No hay partidos generados para este torneo",
                Location = new Point(0, 60),
                Size = new Size(pnlEmpty.Width, 30),
                Font = GetInterFont(14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnGenerate = new Button
            {
                Text = "Generar Partidos Primera Fase",
                Location = new Point((pnlEmpty.Width - 250) / 2, 120),
                Size = new Size(250, 45),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = GetInterFont(11F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.Click += BtnGenerateMatches_Click;

            pnlEmpty.Controls.Add(lblMessage);
            pnlEmpty.Controls.Add(btnGenerate);
            pnlFirstPhase.Controls.Add(pnlEmpty);
        }

        private bool ShouldShowGenerateNextPhaseButton()
        {
            try
            {
                Console.WriteLine($"DEBUG: Tournament Stage: {_tournament?.Stage}");

                if (_tournament == null)
                {
                    Console.WriteLine("DEBUG: Tournament is null");
                    return false;
                }

                var teams = GetTournamentTeams();
                Console.WriteLine($"DEBUG: Teams count: {teams.Count}");

                if (teams.Count < 4)
                {
                    Console.WriteLine("DEBUG: Less than 4 teams");
                    return false;
                }

                // Stage 1: Mostrar botón si todos los partidos de primera fase están completos
                if (_tournament.Stage == 1)
                {
                    int firstPhaseRounds = (teams.Count - 1) * 2;
                    var firstPhaseMatches = matches.Where(m => m.RoundNumber <= firstPhaseRounds).ToList();
                    int expectedFirstPhaseMatches = teams.Count * (teams.Count - 1);

                    Console.WriteLine($"DEBUG: Expected matches: {expectedFirstPhaseMatches}, Actual matches: {firstPhaseMatches.Count}");
                    bool allCompleted = AllFirstPhaseMatchesCompleted();
                    Console.WriteLine($"DEBUG: All completed: {allCompleted}");

                    bool result = firstPhaseMatches.Count >= expectedFirstPhaseMatches && allCompleted;
                    Console.WriteLine($"DEBUG: Should show 'Generate Semifinals' button: {result}");
                    return result;
                }

                // Stage 2: Mostrar botón si todas las semifinales están completas
                if (_tournament.Stage == 2)
                {
                    int firstPhaseRounds = (teams.Count - 1) * 2;
                    var semifinalMatches = matches.Where(m => m.RoundNumber == firstPhaseRounds + 1).ToList();

                    bool allSemifinalsCompleted = semifinalMatches.Count >= 2 && semifinalMatches.All(m => m.IsPlayed == 1);
                    Console.WriteLine($"DEBUG: Should show 'Generate Final' button: {allSemifinalsCompleted}");
                    return allSemifinalsCompleted;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG: Error in ShouldShowGenerateNextPhaseButton: {ex.Message}");
                return false;
            }
        }

        private bool AllFirstPhaseMatchesCompleted()
        {
            try
            {
                var teams = GetTournamentTeams();
                int firstPhaseRounds = (teams.Count - 1) * 2;
                var firstPhaseMatches = matches.Where(m => m.RoundNumber <= firstPhaseRounds).ToList();

                var playedMatches = firstPhaseMatches.Where(m => m.IsPlayed == 1).Count();
                Console.WriteLine($"DEBUG: Played matches: {playedMatches} / {firstPhaseMatches.Count}");

                return firstPhaseMatches.All(m => m.IsPlayed == 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DEBUG: Error in AllFirstPhaseMatchesCompleted: {ex.Message}");
                return false;
            }
        }

        private Panel CreateNextPhaseButton(int yPosition)
        {
            Panel pnlNextPhase = new Panel
            {
                Location = new Point(10, yPosition + 20),
                Size = new Size(PANEL_WIDTH, 120),
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            string buttonText = "";
            string messageText = "";

            switch (_tournament.Stage)
            {
                case 1:
                    buttonText = "Generar Semifinales";
                    messageText = "Fase regular completada. Generar semifinales.";
                    break;
                case 2:
                    buttonText = "Generar Final";
                    messageText = "Semifinales completadas. Generar final.";
                    break;
                default:
                    buttonText = "Generar Fase Final";
                    messageText = "Generar siguiente fase.";
                    break;
            }

            Label lblMessage = new Label
            {
                Text = messageText,
                Location = new Point(0, 30),
                Size = new Size(pnlNextPhase.Width, 30),
                Font = GetInterFont(12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(73, 80, 87),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnGenerateNextPhase = new Button
            {
                Text = buttonText,
                Location = new Point((pnlNextPhase.Width - 180) / 2, 70),
                Size = new Size(180, 35),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = GetInterFont(10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnGenerateNextPhase.FlatAppearance.BorderSize = 0;
            btnGenerateNextPhase.Click += BtnGenerateNextPhase_Click;

            pnlNextPhase.Controls.Add(lblMessage);
            pnlNextPhase.Controls.Add(btnGenerateNextPhase);
            return pnlNextPhase;
        }

        private async void BtnGenerateMatches_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;

                var teams = await Task.Run(() => GetTournamentTeams());

                if (teams.Count < 2)
                {
                    MessageBox.Show("Se necesitan al menos 2 equipos para generar partidos.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"¿Generar partidos para {teams.Count} equipos?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await Task.Run(() => GenerateFirstPhaseMatches(teams));
                    LoadTournamentData();
                    LoadMatches();
                    MessageBox.Show("Partidos generados correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar partidos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private async void BtnGenerateNextPhase_Click(object sender, EventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;

                string confirmMessage = "";
                switch (_tournament.Stage)
                {
                    case 1:
                        confirmMessage = "¿Generar semifinales?";
                        break;
                    case 2:
                        confirmMessage = "¿Generar final?";
                        break;
                    default:
                        confirmMessage = "¿Generar siguiente fase?";
                        break;
                }

                var result = MessageBox.Show(confirmMessage, "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await Task.Run(() => GenerateSecondPhaseMatches());

                    if (_tournament != null)
                    {
                        _tournament.Stage = _tournament.Stage + 1;
                        _tournamentController.UpdateTournament(_tournament);
                    }

                    LoadTournamentData();
                    LoadMatches();

                    string successMessage = "";
                    switch (_tournament.Stage - 1)
                    {
                        case 1:
                            successMessage = "Semifinales generadas correctamente.";
                            break;
                        case 2:
                            successMessage = "Final generada correctamente.";
                            break;
                        default:
                            successMessage = "Fase generada correctamente.";
                            break;
                    }

                    MessageBox.Show(successMessage, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar fase: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void CreateMatch(int homeTeamId, int awayTeamId, int roundNumber,
                       DateTime matchDate, List<Match> roundMatches)
        {
            if (homeTeamId == awayTeamId) return;

            var match = new Match
            {
                TournamentId = _tournamentId,
                HomeTeamId = homeTeamId,
                AwayTeamId = awayTeamId,
                RoundNumber = roundNumber,
                Location = "Por definir",
                DateTime = matchDate.AddHours(roundMatches.Count * 2),
                HomeGoals = 0,
                AwayGoals = 0,
                CreatedDate = DateTime.Now,
                IsPlayed = 0
            };

            roundMatches.Add(match);
        }

        private void GenerateFirstPhaseMatches(List<Team> teams)
        {
            int totalTeams = teams.Count;
            int roundNumber = 1;
            DateTime currentDate = DateTime.Now.AddDays(7);

            for (int round = 0; round < totalTeams - 1; round++)
            {
                var roundMatches = new List<Match>();

                for (int i = 0; i < totalTeams / 2; i++)
                {
                    int homeTeamIndex = i;
                    int awayTeamIndex = totalTeams - 1 - i;

                    if (round % 2 == 0)
                    {
                        CreateMatch(teams[homeTeamIndex].Id, teams[awayTeamIndex].Id,
                                  roundNumber, currentDate, roundMatches);
                    }
                    else
                    {
                        CreateMatch(teams[awayTeamIndex].Id, teams[homeTeamIndex].Id,
                                  roundNumber, currentDate, roundMatches);
                    }
                }

                foreach (var match in roundMatches)
                {
                    match.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Match);
                    if (match.Id <= 0)
                        throw new Exception("No se pudo generar un ID válido para el partido");

                    _matchController.CreateMatch(match);
                }

                roundNumber++;
                currentDate = currentDate.AddDays(7);

                if (totalTeams > 2)
                {
                    Team temp = teams[1];
                    for (int i = 1; i < totalTeams - 1; i++)
                    {
                        teams[i] = teams[i + 1];
                    }
                    teams[totalTeams - 1] = temp;
                }
            }

            teams = GetTournamentTeams();
            for (int round = 0; round < totalTeams - 1; round++)
            {
                var roundMatches = new List<Match>();

                for (int i = 0; i < totalTeams / 2; i++)
                {
                    int homeTeamIndex = i;
                    int awayTeamIndex = totalTeams - 1 - i;

                    if (round % 2 == 0)
                    {
                        CreateMatch(teams[awayTeamIndex].Id, teams[homeTeamIndex].Id,
                                  roundNumber, currentDate, roundMatches);
                    }
                    else
                    {
                        CreateMatch(teams[homeTeamIndex].Id, teams[awayTeamIndex].Id,
                                  roundNumber, currentDate, roundMatches);
                    }
                }

                foreach (var match in roundMatches)
                {
                    match.Id = IdGenerator.GetNextId(IdGenerator.DbTable.Match);
                    if (match.Id <= 0)
                        throw new Exception("No se pudo generar un ID válido para el partido");

                    _matchController.CreateMatch(match);
                }

                roundNumber++;
                currentDate = currentDate.AddDays(7);

                if (totalTeams > 2)
                {
                    Team temp = teams[1];
                    for (int i = 1; i < totalTeams - 1; i++)
                    {
                        teams[i] = teams[i + 1];
                    }
                    teams[totalTeams - 1] = temp;
                }
            }
        }

        private void GenerateSecondPhaseMatches()
        {
            var standings = _tournamentController.GetStandingsByTournament(_tournamentId);
            var top4Teams = standings.Take(4).ToList();

            if (top4Teams.Count < 4)
            {
                throw new Exception("Se necesitan al menos 4 equipos clasificados para la fase final.");
            }

            var existingMatches = _matchController.GetAllMatches()
                .Where(m => m.TournamentId == _tournamentId)
                .ToList();
            int nextRound = existingMatches.Any() ? existingMatches.Max(m => m.RoundNumber) + 1 : 1;

            DateTime semifinalDate = DateTime.Now.AddDays(14);

            // Stage 1: Generar semifinales
            if (_tournament.Stage == 1)
            {
                // Primera semifinal
                int semifinal1Id = IdGenerator.GetNextId(IdGenerator.DbTable.Match);
                string homeTeam1Location = _teamsCache.ContainsKey(top4Teams[0].Id) ?
                    _teamsCache[top4Teams[0].Id].OriginLocation : "Estadio Central";

                var semifinal1 = new Match
                {
                    Id = semifinal1Id,
                    TournamentId = _tournamentId,
                    HomeTeamId = top4Teams[0].Id,
                    AwayTeamId = top4Teams[3].Id,
                    RoundNumber = nextRound,
                    Location = homeTeam1Location,
                    DateTime = semifinalDate,
                    HomeGoals = 0,
                    AwayGoals = 0,
                    CreatedDate = DateTime.Now,
                    IsPlayed = 0
                };

                _matchController.CreateMatch(semifinal1);

                // Segunda semifinal
                int semifinal2Id = IdGenerator.GetNextId(IdGenerator.DbTable.Match);
                string homeTeam2Location = _teamsCache.ContainsKey(top4Teams[1].Id) ?
                    _teamsCache[top4Teams[1].Id].OriginLocation : "Estadio Central";

                var semifinal2 = new Match
                {
                    Id = semifinal2Id,
                    TournamentId = _tournamentId,
                    HomeTeamId = top4Teams[1].Id,
                    AwayTeamId = top4Teams[2].Id,
                    RoundNumber = nextRound,
                    Location = homeTeam2Location,
                    DateTime = semifinalDate.AddHours(3),
                    HomeGoals = 0,
                    AwayGoals = 0,
                    CreatedDate = DateTime.Now,
                    IsPlayed = 0
                };

                _matchController.CreateMatch(semifinal2);
            }
            // Stage 2: Generar final
            else if (_tournament.Stage == 2)
            {
                var finalists = top4Teams.Take(2).ToList();
                int finalId = IdGenerator.GetNextId(IdGenerator.DbTable.Match);
                string finalLocation = _teamsCache.ContainsKey(finalists[0].Id) ?
                    _teamsCache[finalists[0].Id].OriginLocation : "Estadio Central";

                var final = new Match
                {
                    Id = finalId,
                    TournamentId = _tournamentId,
                    HomeTeamId = finalists[0].Id,
                    AwayTeamId = finalists[1].Id,
                    RoundNumber = nextRound,
                    Location = finalLocation,
                    DateTime = semifinalDate.AddDays(7),
                    HomeGoals = 0,
                    AwayGoals = 0,
                    CreatedDate = DateTime.Now,
                    IsPlayed = 0
                };

                _matchController.CreateMatch(final);
            }
        }

        private void MatchPanel_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Match match = control?.Tag as Match;

            if (match != null)
            {
                ShowMatchDetails(match);
            }
        }

        private void ShowMatchDetails(Match match)
        {
            ViewManager.ShowFormInPanel(new MatchDetailsForm(match), TargetPanel.TOURNAMENT);
        }
    }
}