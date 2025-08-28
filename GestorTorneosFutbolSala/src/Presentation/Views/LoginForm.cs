using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.src.Presentation.Views;
using GestorTorneosFutbolSala.utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        private LoadFonts fonts;

        public LoginForm()
        {
            InitializeComponent();
            _userController = new UserController();
            SetupFonts();
        }

        private void SetupFonts()
        {
            fonts = new LoadFonts();

            lblTitle.Font = fonts.SetDefaultFont(20f, FontStyle.Bold);
            lblSubtext.Font = fonts.SetDefaultFont(12f, FontStyle.Regular);

            txtUsername.Font = fonts.SetDefaultFont(14f, FontStyle.Regular);
            lblUsername.Font = fonts.SetDefaultFont(14f, FontStyle.Regular);
            lblUsernameError.Font = fonts.SetDefaultFont(8f, FontStyle.Regular);

            txtPassword.Font = fonts.SetDefaultFont(14f, FontStyle.Regular);
            lblPassword.Font = fonts.SetDefaultFont(14f, FontStyle.Regular);
            lblPasswordError.Font = fonts.SetDefaultFont(8f, FontStyle.Regular);

            btnLogin.Font = fonts.SetDefaultFont(14f, FontStyle.Regular);

            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                lblUsernameError.Text = "El nombre de usuario es obligatorio.";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Text = "La contraseña es obligatoria.";
                return;
            }

            try
            {
                User user = _userController.Authenticate(username, password);

                ViewManager.ShowFormInPanel(new DashboardForm(user), TargetPanel.MAIN);
            }
            catch (Exception ex)
            {
                lblPasswordError.Text = ex.Message;
            }
        }
    }
}
