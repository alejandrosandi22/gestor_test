using GestorTorneosFutbolSala.src.Application.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                EnvironmentLoader.LoadEnvironmentFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando .env: {ex.Message}");
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm());
            //System.Windows.Forms.Application.Run(new src.Presentation.Views.ReportsForm());
        }
    }
}
