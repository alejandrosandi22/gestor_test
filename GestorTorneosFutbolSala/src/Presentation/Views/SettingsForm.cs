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
    public partial class SettingsForm : Form
    {
        private Tournament _tournament;
        private TournamentController _tournamentController;
        private PenaltyController _penaltyController;
        private FineController _fineController;
        private IncidentController _incidentController;
        private LoadFonts _loadFonts;

        private List<Penalty> _penalties;
        private List<Fine> _fines;
        private List<Incident> _incidents;

        public SettingsForm(Tournament tournament)
        {
            InitializeComponent();

            _tournament = tournament;
            _tournamentController = new TournamentController();
            _penaltyController = new PenaltyController();
            _fineController = new FineController();
            _incidentController = new IncidentController();

            try
            {
                _loadFonts = new LoadFonts();
                ApplyInterFont();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading fonts: {ex.Message}");
            }

            LoadData();
            InitializeForm();
        }

        private void ApplyInterFont()
        {
            Font interFont = _loadFonts.GetFont("Inter", 9f);
            Font interFontBold = _loadFonts.GetFont("Inter", 10f, FontStyle.Bold);
            Font interFontTitle = _loadFonts.GetFont("Inter", 12f, FontStyle.Bold);

            this.Font = interFont;

            lblTournamentTitle.Font = interFontTitle;
            lblPenaltiesTitle.Font = interFontTitle;
            lblIncidentsTitle.Font = interFontTitle;
            lblFinesTitle.Font = interFontTitle;

            lblName.Font = interFontBold;
            lblYear.Font = interFontBold;
            lblGender.Font = interFontBold;
            lblAgeCategory.Font = interFontBold;

            txtName.Font = interFont;
            txtYear.Font = interFont;
            cmbGender.Font = interFont;
            cmbAgeCategory.Font = interFont;
            txtYellowCardPrice.Font = interFont;
            txtRedCardPrice.Font = interFont;
            txtBlueCardPrice.Font = interFont;

            dgvIncidents.Font = interFont;
            dgvFines.Font = interFont;

            btnSaveTournament.Font = interFontBold;
            btnSavePenalties.Font = interFontBold;
        }

        private void LoadData()
        {
            try
            {
                _penalties = _penaltyController.GetAllPenalties() ?? new List<Penalty>();
                _fines = _fineController.GetAllFines() ?? new List<Fine>();
                _incidents = _incidentController.GetAllIncidents() ?? new List<Incident>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _penalties = new List<Penalty>();
                _fines = new List<Fine>();
                _incidents = new List<Incident>();
            }
        }

        private void InitializeForm()
        {
            LoadTournamentData();
            LoadPenaltyPrices();
            SetupIncidentsGrid();
            SetupFinesGrid();
            LoadIncidentsData();
            LoadFinesData();
        }

        private void LoadTournamentData()
        {
            txtName.Text = _tournament.Name;
            txtYear.Text = _tournament.Year.ToString();

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Masculino", "Femenino", "Mixto" });
            cmbGender.SelectedIndex = (int)_tournament.Gender;

            cmbAgeCategory.Items.Clear();
            cmbAgeCategory.Items.AddRange(new string[] { "Adultos", "Sub-12", "Sub-14", "Sub-16", "Sub-18", "Sub-21" });

            if (_tournament.AgeCategory == 0)
            {
                cmbAgeCategory.SelectedIndex = 0;
            }
            else
            {
                switch (_tournament.AgeCategory)
                {
                    case 12:
                        cmbAgeCategory.SelectedIndex = 1;
                        break;
                    case 14:
                        cmbAgeCategory.SelectedIndex = 2;
                        break;
                    case 16:
                        cmbAgeCategory.SelectedIndex = 3;
                        break;
                    case 18:
                        cmbAgeCategory.SelectedIndex = 4;
                        break;
                    case 21:
                        cmbAgeCategory.SelectedIndex = 5;
                        break;
                    default:
                        cmbAgeCategory.SelectedIndex = 0;
                        break;
                }
            }
        }

        private void LoadPenaltyPrices()
        {
            Penalty yellowCardPenalty = null;
            Penalty redCardPenalty = null;
            Penalty blueCardPenalty = null;

            foreach (Penalty p in _penalties)
            {
                if (p.Name.Contains("Amarilla") || p.Name.Contains("Yellow"))
                    yellowCardPenalty = p;
                else if (p.Name.Contains("Roja") || p.Name.Contains("Red"))
                    redCardPenalty = p;
                else if (p.Name.Contains("Azul") || p.Name.Contains("Blue"))
                    blueCardPenalty = p;
            }

            txtYellowCardPrice.Text = yellowCardPenalty != null ? yellowCardPenalty.Amount.ToString("0") : "5000";
            txtRedCardPrice.Text = redCardPenalty != null ? redCardPenalty.Amount.ToString("0") : "15000";
            txtBlueCardPrice.Text = blueCardPenalty != null ? blueCardPenalty.Amount.ToString("0") : "10000";
        }

        private void SetupIncidentsGrid()
        {
            dgvIncidents.AutoGenerateColumns = false;
            dgvIncidents.AllowUserToAddRows = false;
            dgvIncidents.AllowUserToDeleteRows = false;
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidents.MultiSelect = false;
            dgvIncidents.ReadOnly = true;
            dgvIncidents.ScrollBars = ScrollBars.Vertical;

            dgvIncidents.Columns.Clear();

            DataGridViewTextBoxColumn matchColumn = new DataGridViewTextBoxColumn
            {
                Name = "MatchId",
                HeaderText = "ID Partido",
                DataPropertyName = "MatchId",
                Width = 100
            };

            DataGridViewTextBoxColumn playerColumn = new DataGridViewTextBoxColumn
            {
                Name = "PlayerId",
                HeaderText = "ID Jugador",
                DataPropertyName = "PlayerId",
                Width = 100
            };

            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn
            {
                Name = "TypeText",
                HeaderText = "Tipo",
                Width = 120
            };

            DataGridViewTextBoxColumn minuteColumn = new DataGridViewTextBoxColumn
            {
                Name = "Minute",
                HeaderText = "Minuto",
                DataPropertyName = "Minute",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            DataGridViewTextBoxColumn notesColumn = new DataGridViewTextBoxColumn
            {
                Name = "Notes",
                HeaderText = "Notas",
                DataPropertyName = "Notes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Fecha",
                DataPropertyName = "CreatedDate",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            };

            dgvIncidents.Columns.AddRange(new DataGridViewColumn[] { matchColumn, playerColumn, typeColumn, minuteColumn, notesColumn, dateColumn });
        }

        private void SetupFinesGrid()
        {
            dgvFines.AutoGenerateColumns = false;
            dgvFines.AllowUserToAddRows = false;
            dgvFines.AllowUserToDeleteRows = false;
            dgvFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFines.MultiSelect = false;
            dgvFines.ReadOnly = false;
            dgvFines.ScrollBars = ScrollBars.Vertical;

            dgvFines.Columns.Clear();

            DataGridViewTextBoxColumn playerColumn = new DataGridViewTextBoxColumn
            {
                Name = "PlayerId",
                HeaderText = "ID Jugador",
                DataPropertyName = "PlayerId",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn penaltyColumn = new DataGridViewTextBoxColumn
            {
                Name = "PenaltyName",
                HeaderText = "Penalidad",
                Width = 150,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Fecha",
                DataPropertyName = "Date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                },
                ReadOnly = true
            };

            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Monto (₡)",
                DataPropertyName = "Amount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                ReadOnly = true
            };

            DataGridViewCheckBoxColumn paidColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Paid",
                HeaderText = "Pagado",
                DataPropertyName = "Paid",
                Width = 80
            };

            dgvFines.Columns.AddRange(new DataGridViewColumn[] { playerColumn, penaltyColumn, dateColumn, amountColumn, paidColumn });
        }

        private void LoadIncidentsData()
        {
            var cardTypes = new HashSet<IncidentTypeEnum>
                {
                    IncidentTypeEnum.YellowCard,
                    IncidentTypeEnum.BlueCard,
                    IncidentTypeEnum.RedCard,
                    IncidentTypeEnum.Expulsion
                };

            dgvIncidents.Rows.Clear();

            foreach (Incident incident in _incidents)
            {
                if (!cardTypes.Contains(incident.Type))
                    continue;

                string typeText = GetIncidentTypeText(incident.Type);

                int rowIndex = dgvIncidents.Rows.Add();
                DataGridViewRow row = dgvIncidents.Rows[rowIndex];

                row.Cells["MatchId"].Value = incident.MatchId;
                row.Cells["PlayerId"].Value = incident.PlayerId;
                row.Cells["TypeText"].Value = typeText;
                row.Cells["Minute"].Value = incident.Minute;
                row.Cells["Notes"].Value = incident.Notes ?? "";
                row.Cells["CreatedDate"].Value = incident.CreatedDate;
                row.Tag = incident;
            }
        }

        private void LoadFinesData()
        {
            dgvFines.Rows.Clear();

            foreach (Fine fine in _fines)
            {
                string penaltyName = GetPenaltyName(fine.PenaltyId);

                int rowIndex = dgvFines.Rows.Add();
                DataGridViewRow row = dgvFines.Rows[rowIndex];

                row.Cells["PlayerId"].Value = fine.PlayerId;
                row.Cells["PenaltyName"].Value = penaltyName;
                row.Cells["Date"].Value = fine.Date;
                row.Cells["Amount"].Value = fine.Amount;
                row.Cells["Paid"].Value = fine.Paid;
                row.Tag = fine;
            }
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

        private string GetPenaltyName(int penaltyId)
        {
            foreach (Penalty p in _penalties)
            {
                if (p.Id == penaltyId)
                    return p.Name;
            }
            return "Penalidad desconocida";
        }

        private void btnSaveTournament_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTournamentData())
                {
                    _tournament.Name = txtName.Text.Trim();
                    _tournament.Year = int.Parse(txtYear.Text.Trim());
                    _tournament.Gender = (GenderCategoryEnum)cmbGender.SelectedIndex;

                    int selectedAge = cmbAgeCategory.SelectedIndex;
                    switch (selectedAge)
                    {
                        case 0:
                            _tournament.AgeCategory = 0;
                            break;
                        case 1:
                            _tournament.AgeCategory = 12;
                            break;
                        case 2:
                            _tournament.AgeCategory = 14;
                            break;
                        case 3:
                            _tournament.AgeCategory = 16;
                            break;
                        case 4:
                            _tournament.AgeCategory = 18;
                            break;
                        case 5:
                            _tournament.AgeCategory = 21;
                            break;
                        default:
                            _tournament.AgeCategory = 0;
                            break;
                    }

                    _tournamentController.UpdateTournament(_tournament);

                    MessageBox.Show("Datos del torneo guardados correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el torneo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTournamentData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El nombre del torneo es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!int.TryParse(txtYear.Text.Trim(), out int year) || year < 2020 || year > 2030)
            {
                MessageBox.Show("El año debe ser un número entre 2020 y 2030.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un género.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return false;
            }

            if (cmbAgeCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una categoría de edad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAgeCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnSavePenalties_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasChanges = false;

                if (decimal.TryParse(txtYellowCardPrice.Text, out decimal yellowPrice))
                {
                    hasChanges = UpdatePenaltyPrice("Amarilla", "Yellow", yellowPrice) || hasChanges;
                }

                if (decimal.TryParse(txtRedCardPrice.Text, out decimal redPrice))
                {
                    hasChanges = UpdatePenaltyPrice("Roja", "Red", redPrice) || hasChanges;
                }

                if (decimal.TryParse(txtBlueCardPrice.Text, out decimal bluePrice))
                {
                    hasChanges = UpdatePenaltyPrice("Azul", "Blue", bluePrice) || hasChanges;
                }

                foreach (DataGridViewRow row in dgvFines.Rows)
                {
                    if (row.IsNewRow) continue;

                    Fine fine = (Fine)row.Tag;
                    bool paid = Convert.ToBoolean(row.Cells["Paid"].Value ?? false);

                    if (fine.Paid != paid)
                    {
                        fine.Paid = paid;
                        _fineController.UpdateFine(fine);
                        hasChanges = true;
                    }
                }

                if (hasChanges)
                {
                    MessageBox.Show("Cambios guardados correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    LoadPenaltyPrices();
                    LoadFinesData();
                }
                else
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar las penalidades: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdatePenaltyPrice(string nameEs, string nameEn, decimal newPrice)
        {
            foreach (Penalty p in _penalties)
            {
                if (p.Name.Contains(nameEs) || p.Name.Contains(nameEn))
                {
                    if (p.Amount != newPrice)
                    {
                        p.Amount = newPrice;
                        _penaltyController.UpdatePenalty(p);
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Configuración - {_tournament.Name}";
        }
    }
}