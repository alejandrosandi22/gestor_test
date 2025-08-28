using GestorTorneosFutbolSala.Domain.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    public partial class PlayerEntryForm : Form
    {
        private Player _player;
        private bool _isEditMode;
        private int _maxAge;

        public PlayerEntryForm(int maxAge, Player playerToEdit = null)
        {
            InitializeComponent();
            _player = playerToEdit ?? new Player();
            _isEditMode = playerToEdit != null;
            _maxAge = maxAge;

            InitializeForm();
        }

        private void InitializeForm()
        {
            if (_isEditMode)
            {
                LoadPlayerData();
                btnSave.Text = "Actualizar";
                this.Text = "Editar Jugador";
            }
            else
            {
                btnSave.Text = "Agregar";
                this.Text = "Agregar Jugador";
            }

            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.MaxDate = DateTime.Now;
            dtpBirthDate.MinDate = new DateTime(1900, 1, 1);
        }

        private void LoadPlayerData()
        {
            if (_player != null)
            {
                txtIdNumber.Text = _player.IdNumber;
                txtFullName.Text = _player.FullName;
                dtpBirthDate.Value = _player.BirthDate;
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            lblIdNumberError.Text = "";
            lblFullNameError.Text = "";
            lblBirthDateError.Text = "";

            if (string.IsNullOrWhiteSpace(txtIdNumber.Text))
            {
                lblIdNumberError.Text = "La cédula es obligatoria.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                lblFullNameError.Text = "El nombre completo es obligatorio.";
                isValid = false;
            }

            if (dtpBirthDate.Value >= DateTime.Now)
            {
                lblBirthDateError.Text = "La fecha de nacimiento debe ser anterior a hoy.";
                isValid = false;
            }

            var tempPlayer = new Player();
            tempPlayer.BirthDate = dtpBirthDate.Value;
            var age = tempPlayer.CalculateAge(DateTime.Now);

            if (age < 5 || age > 100)
            {
                lblBirthDateError.Text = "La edad debe estar entre 5 y 100 años.";
                isValid = false;
            }
            else if (age > _maxAge)
            {
                lblBirthDateError.Text = $"La edad máxima permitida para este torneo es {_maxAge} años. Edad actual: {age} años.";
                isValid = false;
            }

            return isValid;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            _player.IdNumber = txtIdNumber.Text.Trim();
            _player.FullName = txtFullName.Text.Trim();
            _player.BirthDate = dtpBirthDate.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}