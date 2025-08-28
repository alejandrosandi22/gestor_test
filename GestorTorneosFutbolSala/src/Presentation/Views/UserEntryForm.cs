using GestorTorneosFutbolSala.Domain;
using GestorTorneosFutbolSala.Domain.Enums;
using GestorTorneosFutbolSala.src.Presentation.Controllers;
using GestorTorneosFutbolSala.utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class UserEntryForm : Form
    {
        private readonly UserController _userController;
        private User _currentUser;
        private bool _isEditMode;

        public UserEntryForm(User userToEdit = null)
        {
            InitializeComponent();
            _userController = new UserController();
            _currentUser = userToEdit;
            _isEditMode = userToEdit != null;

            InitializeForm();
        }

        private void InitializeForm()
        {
            InitializeRoleComboBox();

            if (_isEditMode)
            {
                LoadUserData();
                btnSave.Text = "Actualizar Usuario";
                this.Text = "Editar Usuario";
            }
            else
            {
                _currentUser = new User();
                btnSave.Text = "Crear Usuario";
                this.Text = "Crear Usuario";
                cmbRole.SelectedIndex = 0;
            }
        }

        private void InitializeRoleComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Administrador");
            cmbRole.Items.Add("SubAdministrador");
            cmbRole.Items.Add("Árbitro");
        }

        private void LoadUserData()
        {
            if (_currentUser != null)
            {
                txtName.Text = _currentUser.Name;
                txtUsername.Text = _currentUser.Username;
                txtPassword.Text = _currentUser.Password;

                // Convertir el enum a su valor numérico para el índice del ComboBox
                switch (_currentUser.Role)
                {
                    case UserRoleEnum.Administrador:
                        cmbRole.SelectedIndex = 0;
                        break;
                    case UserRoleEnum.SubAdministrador:
                        cmbRole.SelectedIndex = 1;
                        break;
                    case UserRoleEnum.Arbitro:
                        cmbRole.SelectedIndex = 2;
                        break;
                    default:
                        cmbRole.SelectedIndex = 0;
                        break;
                }
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            lblNameError.Text = "";
            lblUsernameError.Text = "";
            lblPasswordError.Text = "";
            lblRoleError.Text = "";

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblNameError.Text = "El nombre es obligatorio.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblUsernameError.Text = "El nombre de usuario es obligatorio.";
                isValid = false;
            }
            else if (txtUsername.Text.Length < 3)
            {
                lblUsernameError.Text = "El nombre de usuario debe tener al menos 3 caracteres.";
                isValid = false;
            }
            else if (!_isEditMode && IsUsernameExists(txtUsername.Text))
            {
                lblUsernameError.Text = "Este nombre de usuario ya existe.";
                isValid = false;
            }
            else if (_isEditMode && txtUsername.Text != _currentUser.Username && IsUsernameExists(txtUsername.Text))
            {
                lblUsernameError.Text = "Este nombre de usuario ya existe.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblPasswordError.Text = "La contraseña es obligatoria.";
                isValid = false;
            }
            else if (txtPassword.Text.Length < 4)
            {
                lblPasswordError.Text = "La contraseña debe tener al menos 4 caracteres.";
                isValid = false;
            }

            if (cmbRole.SelectedIndex == -1)
            {
                lblRoleError.Text = "Debe seleccionar un rol.";
                isValid = false;
            }

            return isValid;
        }

        private bool IsUsernameExists(string username)
        {
            try
            {
                var existingUsers = _userController.GetAllUsers();
                foreach (var user in existingUsers)
                {
                    if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void SaveUserData()
        {
            if (!_isEditMode)
            {
                _currentUser.Id = IdGenerator.GetNextId(IdGenerator.DbTable.User);
            }

            _currentUser.Name = txtName.Text.Trim();
            _currentUser.Username = txtUsername.Text.Trim();
            _currentUser.Password = txtPassword.Text;
            _currentUser.Role = (UserRoleEnum)cmbRole.SelectedIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm())
                {
                    return;
                }

                SaveUserData();

                if (_isEditMode)
                {
                    _userController.UpdateUser(_currentUser);
                    MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _userController.CreateUser(_currentUser);
                    MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRoleDescription();
        }

        private void UpdateRoleDescription()
        {
            if (cmbRole.SelectedIndex == -1)
            {
                lblRoleDescription.Text = "";
                return;
            }

            var selectedRole = (UserRoleEnum)cmbRole.SelectedIndex;

            switch (selectedRole)
            {
                case UserRoleEnum.SubAdministrador:
                    lblRoleDescription.Text = "Registra equipos, genera partidos y visualiza estadísticas.";
                    lblRoleDescription.ForeColor = Color.Orange;
                    break;
                case UserRoleEnum.Arbitro:
                    lblRoleDescription.Text = "Registra incidencias de partidos (goles, tarjetas).";
                    lblRoleDescription.ForeColor = Color.Green;
                    break;
                default:
                    lblRoleDescription.Text = "";
                    break;
            }
        }

        public User GetUser()
        {
            return _currentUser;
        }
    }
}
