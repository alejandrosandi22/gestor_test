using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.utils
{
    public class ViewManager
    {
        private static Panel mainPanel;
        private static Panel dashboardPanel;
        private static Panel tournamentPanel;

        public static void RegisterMainPanel(Panel main)
        {
            mainPanel = main;
        }

        public static void RegisterDashbaordPanels(Panel dashboard)
        {
            dashboardPanel = dashboard;
        }

        public static void RegisterTournamentPanels(Panel tournament)
        {
            tournamentPanel = tournament;
        }

        public static void ShowFormInPanel(Form formToShow, TargetPanel targetPanel)
        {
            Panel container = GetTargetPanel(targetPanel);
            if (container == null) return;

            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Form frm)
                {
                    frm.Close();
                    break;
                }
            }

            formToShow.TopLevel = false;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Dock = DockStyle.Fill;

            container.Controls.Clear();
            container.Controls.Add(formToShow);
            formToShow.Show();
        }

        private static Panel GetTargetPanel(TargetPanel target)
        {
            switch (target)
            {
                case TargetPanel.MAIN:
                    return mainPanel;
                case TargetPanel.DASHBOARD:
                    return dashboardPanel;
                case TargetPanel.TOURNAMENT:
                    return tournamentPanel;
                default:
                    return null;
            }
        }

    }

    public enum TargetPanel
    {
        MAIN,
        DASHBOARD,
        TOURNAMENT
    }
}