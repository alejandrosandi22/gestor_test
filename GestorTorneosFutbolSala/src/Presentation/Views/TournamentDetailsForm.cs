using GestorTorneosFutbolSala.Domain;
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
    public partial class TournamentDetailsForm : Form
    {
        private Tournament _tournament;

        public TournamentDetailsForm(Tournament tournament)
        {
            InitializeComponent();
            _tournament = tournament;
            lblTournamentName.Text = tournament.Name;
            ViewManager.RegisterTournamentPanels(this.pnlContent);
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            SetSelectedButton(btnTeams);
            ViewManager.ShowFormInPanel(new TeamsForm(_tournament), TargetPanel.TOURNAMENT);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            SetSelectedButton(btnStatistics);
            ViewManager.ShowFormInPanel(new StatisticsForm(_tournament), TargetPanel.TOURNAMENT);
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            SetSelectedButton(btnMatch);
            ViewManager.ShowFormInPanel(new MatchesForm(_tournament.Id), TargetPanel.TOURNAMENT);
        }

        private void SetSelectedButton(Button selectedButton)
        {
            ResetButtonStyles();

            selectedButton.BackColor = SystemColors.HotTrack;
            selectedButton.ForeColor = Color.White;
        }

        private void ResetButtonStyles()
        {
            Button[] sidebarButtons = { btnTeams, btnMatch, btnStatistics, btnSettings };

            foreach (Button button in sidebarButtons)
            {
                button.BackColor = Color.WhiteSmoke;
                button.ForeColor = Color.Black;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SetSelectedButton(btnSettings);
            ViewManager.ShowFormInPanel(new SettingsForm(_tournament), TargetPanel.TOURNAMENT);
        }

        private void TournamentDetailsForm_Load(object sender, EventArgs e)
        {
            SetSelectedButton(btnTeams);
            ViewManager.ShowFormInPanel(new TeamsForm(_tournament), TargetPanel.TOURNAMENT);
        }
    }
}