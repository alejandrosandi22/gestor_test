using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContent;
        private Panel pnlHeader;
        private Button btnUserSession;
        private Label lblUsers;
        private Label lblTournaments;
        private Label lblHome;
        private PictureBox pictureBox1;
        private Label lblReports;
        private ContextMenuStrip userSessionMenu;
        private ToolStripMenuItem roleItem;
        private ToolStripSeparator separator;
        private ToolStripMenuItem logoutItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblReports = new System.Windows.Forms.Label();
            this.btnUserSession = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblTournaments = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userSessionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.roleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separator = new System.Windows.Forms.ToolStripSeparator();
            this.logoutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.userSessionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 74);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1535, 774);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblReports);
            this.pnlHeader.Controls.Add(this.btnUserSession);
            this.pnlHeader.Controls.Add(this.lblUsers);
            this.pnlHeader.Controls.Add(this.lblTournaments);
            this.pnlHeader.Controls.Add(this.lblHome);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1535, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.BackColor = System.Drawing.Color.Transparent;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblReports.Location = new System.Drawing.Point(814, 25);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(112, 29);
            this.lblReports.TabIndex = 6;
            this.lblReports.Text = "Reportes";
            // 
            // btnUserSession
            // 
            this.btnUserSession.FlatAppearance.BorderSize = 0;
            this.btnUserSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserSession.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserSession.Location = new System.Drawing.Point(1194, 16);
            this.btnUserSession.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUserSession.Name = "btnUserSession";
            this.btnUserSession.Size = new System.Drawing.Size(207, 47);
            this.btnUserSession.TabIndex = 5;
            this.btnUserSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserSession.UseVisualStyleBackColor = true;
            this.btnUserSession.Click += new System.EventHandler(this.btnUserSession_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsers.Location = new System.Drawing.Point(686, 25);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(108, 29);
            this.lblUsers.TabIndex = 4;
            this.lblUsers.Text = "Usuarios";
            // 
            // lblTournaments
            // 
            this.lblTournaments.AutoSize = true;
            this.lblTournaments.BackColor = System.Drawing.Color.Transparent;
            this.lblTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournaments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTournaments.Location = new System.Drawing.Point(562, 25);
            this.lblTournaments.Name = "lblTournaments";
            this.lblTournaments.Size = new System.Drawing.Size(104, 29);
            this.lblTournaments.TabIndex = 2;
            this.lblTournaments.Text = "Torneos";
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.BackColor = System.Drawing.Color.Transparent;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHome.Location = new System.Drawing.Point(475, 25);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(70, 29);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "Inicio";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // userSessionMenu
            // 
            this.userSessionMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.userSessionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roleItem,
            this.separator,
            this.logoutItem});
            this.userSessionMenu.Name = "userSessionMenu";
            this.userSessionMenu.Size = new System.Drawing.Size(203, 58);
            // 
            // roleItem
            // 
            this.roleItem.Name = "roleItem";
            this.roleItem.Size = new System.Drawing.Size(202, 24);
            this.roleItem.Text = "Rol: Administrador";
            // 
            // separator
            // 
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(199, 6);
            // 
            // logoutItem
            // 
            this.logoutItem.Name = "logoutItem";
            this.logoutItem.Size = new System.Drawing.Size(202, 24);
            this.logoutItem.Text = "Cerrar sesión";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 848);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.userSessionMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}