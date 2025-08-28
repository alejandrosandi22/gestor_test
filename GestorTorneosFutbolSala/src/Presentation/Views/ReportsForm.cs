using GestorTorneosFutbolSala.src.Infrastructure.Repositories;
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
    /// <summary>
    /// Form responsible for displaying different reports related to the tournament.
    /// Show top players, player penalties, team penalties, 
    /// and team positions in the tournament.
    /// </summary>
    /// 

    public partial class ReportsForm : Form
    {
        private ReportRepository _report;

        public ReportsForm()
        {
            InitializeComponent();
            _report = new ReportRepository();
        }

        /// <summary>
        /// Loads the top 10 scorers into the corresponding DataGridView.
        /// </summary>
        private void LoadTop10Scorers()
        {
            DataTable dt = _report.GetTop10Players();
            if (dt != null)
            {
                grdTop10Players.DataSource = dt;
                grdTop10Players.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        /// <summary>
        /// Event triggered when the form loads.
        /// Loads top scorers and team positions reports by default.
        /// </summary>
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadTop10Scorers();
            LoadTeamPositions();
        }

        /// <summary>
        /// Loads the general player penalties report when the General button is clicked.
        /// </summary>
        private void btnGeneral_Click(object sender, EventArgs e)
        {
            DataTable dt = _report.GetallPenalties();
            if (dt != null)
            {
                grdTableIncidents.DataSource = dt;
                grdTableIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        /// <summary>
        /// Loads penalties grouped by team when the Team button is clicked.
        /// </summary>
        private void btnTeam_Click(object sender, EventArgs e)
        {
            DataTable dt = _report.GetPenaltiesByTeam();
            if (dt != null)
            {
                grdTableIncidents.DataSource = dt;
                grdTableIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        /// <summary>
        /// Loads the team positions report into the DataGridView.
        /// </summary>
        private void LoadTeamPositions()
        {
            DataTable dt = _report.GetTeamsPositions();
            if (dt != null)
            {
                grdTeamPositions.DataSource = dt;
                grdTeamPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
