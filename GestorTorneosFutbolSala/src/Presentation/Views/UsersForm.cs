using GestorTorneosFutbolSala.Domain;
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
    public partial class UsersForm : Form
    {
        private readonly UserController _userController;
        private List<User> users;
        private List<User> filteredUsers;
        private const int CARD_HEIGHT = 100;
        private const int CARD_MARGIN = 10;

        public UsersForm()
        {
            InitializeComponent();
            _userController = new UserController();
            InitializeUsersForm();
        }

        private void InitializeUsersForm()
        {
            this.Text = "Gestión de Usuarios";
            this.WindowState = FormWindowState.Maximized;

            pnlContent.AutoScroll = true;

            LoadUsersData();
            InitializeRoleFilter();
            filteredUsers = new List<User>(users);

            RenderUserCards();
        }

        private void LoadUsersData()
        {
            try
            {
                users = _userController.GetAllUsers();

                if (users == null)
                {
                    users = new List<User>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                users = new List<User>();
            }
        }

        private void InitializeRoleFilter()
        {
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.Add("Todos los roles");
            cmbRoleFilter.Items.Add("Administrador");
            cmbRoleFilter.Items.Add("SubAdministrador");
            cmbRoleFilter.Items.Add("Árbitro");
            cmbRoleFilter.SelectedIndex = 0;
        }

        private void RenderUserCards()
        {
            pnlContent.Controls.Clear();

            if (filteredUsers == null || filteredUsers.Count == 0)
            {
                ShowNoUsersMessage();
                return;
            }

            int currentY = 15;

            foreach (var user in filteredUsers)
            {
                Panel pnlUserCard = CreateUserCard(user);

                int availableWidth = pnlContent.ClientSize.Width - 40;

                pnlUserCard.Location = new Point(20, currentY);
                pnlUserCard.Width = Math.Max(400, availableWidth);

                pnlContent.Controls.Add(pnlUserCard);

                currentY += CARD_HEIGHT + CARD_MARGIN;
            }
        }

        private Panel CreateUserCard(User user)
        {
            Panel pnlUserCard = new Panel();
            pnlUserCard.Height = CARD_HEIGHT;
            pnlUserCard.BorderStyle = BorderStyle.FixedSingle;
            pnlUserCard.BackColor = Color.White;
            pnlUserCard.Cursor = Cursors.Hand;
            pnlUserCard.Tag = user;

            pnlUserCard.Click += PnlUserCard_Click;

            Label lblUserName = new Label();
            lblUserName.Text = user.Name;
            lblUserName.Font = new Font("Arial", 14, FontStyle.Bold);
            lblUserName.ForeColor = Color.DarkBlue;
            lblUserName.Location = new Point(15, 10);
            lblUserName.Size = new Size(300, 25);
            lblUserName.Click += PnlUserCard_Click;
            lblUserName.Tag = user;
            lblUserName.Cursor = Cursors.Hand;

            Label lblUsername = new Label();
            lblUsername.Text = $"Usuario: {user.Username}";
            lblUsername.Font = new Font("Arial", 10);
            lblUsername.ForeColor = Color.Gray;
            lblUsername.Location = new Point(15, 40);
            lblUsername.Size = new Size(300, 20);
            lblUsername.Click += PnlUserCard_Click;
            lblUsername.Tag = user;
            lblUsername.Cursor = Cursors.Hand;

            Label lblRole = new Label();
            lblRole.Text = $"Rol: {GetRoleDisplayName(user.Role)}";
            lblRole.Font = new Font("Arial", 10, FontStyle.Bold);
            lblRole.ForeColor = GetRoleColor(user.Role);
            lblRole.Location = new Point(15, 65);
            lblRole.Size = new Size(300, 20);
            lblRole.Click += PnlUserCard_Click;
            lblRole.Tag = user;
            lblRole.Cursor = Cursors.Hand;

            Panel pnlButtons = new Panel();
            pnlButtons.Size = new Size(160, 35);
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Size = new Size(75, 30);
            btnEdit.Location = new Point(0, 2);
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderColor = Color.Blue;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Tag = user;
            btnEdit.Click += BtnEdit_Click;

            Button btnDelete = new Button();
            btnDelete.Text = "Eliminar";
            btnDelete.Size = new Size(80, 30);
            btnDelete.Location = new Point(80, 2);
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Tag = user;
            btnDelete.Click += BtnDelete_Click;

            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnDelete);

            pnlUserCard.Controls.Add(lblUserName);
            pnlUserCard.Controls.Add(lblUsername);
            pnlUserCard.Controls.Add(lblRole);
            pnlUserCard.Controls.Add(pnlButtons);

            pnlUserCard.Resize += (sender, e) =>
            {
                if (sender is Panel panel)
                {
                    var buttonsPanel = panel.Controls.OfType<Panel>().FirstOrDefault();
                    if (buttonsPanel != null)
                    {
                        buttonsPanel.Location = new Point(panel.Width - buttonsPanel.Width - 15, 25);
                    }
                }
            };

            return pnlUserCard;
        }

        private string GetRoleDisplayName(UserRoleEnum role)
        {
            switch (role)
            {
                case UserRoleEnum.Administrador:
                    return "Administrador";
                case UserRoleEnum.SubAdministrador:
                    return "SubAdministrador";
                case UserRoleEnum.Arbitro:
                    return "Árbitro";
                default:
                    return role.ToString();
            }
        }

        private Color GetRoleColor(UserRoleEnum role)
        {
            switch (role)
            {
                case UserRoleEnum.Administrador:
                    return Color.Red;
                case UserRoleEnum.SubAdministrador:
                    return Color.Orange;
                case UserRoleEnum.Arbitro:
                    return Color.Green;
                default:
                    return Color.Black;
            }
        }

        private void ShowNoUsersMessage()
        {
            Label lblNoUsers = new Label();
            lblNoUsers.Text = filteredUsers?.Count == 0 && users?.Count > 0
                ? "No se encontraron usuarios con los filtros aplicados"
                : "No hay usuarios para mostrar";
            lblNoUsers.Font = new Font("Arial", 14, FontStyle.Bold);
            lblNoUsers.ForeColor = Color.Gray;
            lblNoUsers.TextAlign = ContentAlignment.MiddleCenter;
            lblNoUsers.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(lblNoUsers);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbRoleFilter.SelectedIndex = 0;
            ApplyFilters();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var userForm = new UserEntryForm())
            {
                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadDataFromController();
                }
            }
        }

        private void ApplyFilters()
        {
            if (users == null)
            {
                filteredUsers = new List<User>();
                RenderUserCards();
                return;
            }

            var searchText = txtSearch.Text.ToLower().Trim();
            var roleFilterIndex = cmbRoleFilter.SelectedIndex;

            var searchFiltered = users.Where(user =>
                string.IsNullOrEmpty(searchText) ||
                user.Name.ToLower().Contains(searchText) ||
                user.Username.ToLower().Contains(searchText) ||
                GetRoleDisplayName(user.Role).ToLower().Contains(searchText)
            ).ToList();

            switch (roleFilterIndex)
            {
                case 0:
                    filteredUsers = searchFiltered;
                    break;
                case 1:
                    filteredUsers = searchFiltered.Where(u => u.Role == UserRoleEnum.Administrador).ToList();
                    break;
                case 2:
                    filteredUsers = searchFiltered.Where(u => u.Role == UserRoleEnum.SubAdministrador).ToList();
                    break;
                case 3:
                    filteredUsers = searchFiltered.Where(u => u.Role == UserRoleEnum.Arbitro).ToList();
                    break;
                default:
                    filteredUsers = searchFiltered;
                    break;
            }

            RenderUserCards();
        }

        private void PnlUserCard_Click(object sender, EventArgs e)
        {
            User user = null;

            if (sender is Panel panel)
                user = panel.Tag as User;
            else if (sender is Label label)
                user = label.Tag as User;

            if (user != null)
            {
                using (var userForm = new UserEntryForm(user))
                {
                    if (userForm.ShowDialog() == DialogResult.OK)
                    {
                        ReloadDataFromController();
                    }
                }
            }
        }

        private void ShowUserDetails(User user)
        {
            string roleDescription = GetRoleDescription(user.Role);

            string details = $"INFORMACIÓN DEL USUARIO\n\n" +
                           $"ID: {user.Id}\n" +
                           $"Nombre: {user.Name}\n" +
                           $"Usuario: {user.Username}\n" +
                           $"Rol: {GetRoleDisplayName(user.Role)}\n\n" +
                           $"PERMISOS DEL ROL:\n{roleDescription}";

            MessageBox.Show(details, $"Detalles: {user.Name}",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetRoleDescription(UserRoleEnum role)
        {
            switch (role)
            {
                case UserRoleEnum.Administrador:
                    return "• Crea y gestiona torneos\n• Gestiona usuarios (crear, editar, asignar roles)\n• Acceso completo al sistema";
                case UserRoleEnum.SubAdministrador:
                    return "• Registra equipos y jugadores\n• Genera partidos y jornadas\n• Ingresa resultados de partidos\n• Visualiza estadísticas y tablas";
                case UserRoleEnum.Arbitro:
                    return "• Registra incidencias de partidos\n• Registra goles y tarjetas\n• Acceso limitado a funciones de arbitraje";
                default:
                    return "Permisos no definidos";
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btnEdit && btnEdit.Tag is User user)
            {
                using (var userForm = new UserEntryForm(user))
                {
                    if (userForm.ShowDialog() == DialogResult.OK)
                    {
                        ReloadDataFromController();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is Button btnDelete && btnDelete.Tag is User user)
            {
                string message = $"¿Está seguro que desea eliminar el usuario '{user.Name}'?\n\n" +
                               "Esta acción no se puede deshacer.";

                var result = MessageBox.Show(message, "Eliminar Usuario",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteUserUsingController(user.Id, user.Name);
                }
            }
        }

        private void DeleteUserUsingController(int userId, string userName)
        {
            try
            {
                _userController.DeleteUser(userId);

                var userToRemove = users.FirstOrDefault(u => u.Id == userId);
                if (userToRemove != null)
                {
                    users.Remove(userToRemove);
                }

                ApplyFilters();

                MessageBox.Show($"El usuario '{userName}' ha sido eliminado correctamente.",
                              "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario '{userName}': {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReloadDataFromController()
        {
            try
            {
                users = _userController.GetAllUsers();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar los datos: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateUsers(List<User> newUsers)
        {
            this.users = newUsers;
            ApplyFilters();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<User> GetFilteredUsers()
        {
            return filteredUsers;
        }

        public void RefreshView()
        {
            ApplyFilters();
        }
    }
}