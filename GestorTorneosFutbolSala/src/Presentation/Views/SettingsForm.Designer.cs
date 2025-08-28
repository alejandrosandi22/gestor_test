namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlFines = new System.Windows.Forms.Panel();
            this.lblFinesTitle = new System.Windows.Forms.Label();
            this.dgvFines = new System.Windows.Forms.DataGridView();
            this.pnlPenalties = new System.Windows.Forms.Panel();
            this.btnSavePenalties = new System.Windows.Forms.Button();
            this.lblPenaltiesTitle = new System.Windows.Forms.Label();
            this.dgvPenalties = new System.Windows.Forms.DataGridView();
            this.pnlTournament = new System.Windows.Forms.Panel();
            this.btnSaveTournament = new System.Windows.Forms.Button();
            this.cmbAgeCategory = new System.Windows.Forms.ComboBox();
            this.lblAgeCategory = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTournamentTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).BeginInit();
            this.pnlPenalties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalties)).BeginInit();
            this.pnlTournament.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1167, 728);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlFines);
            this.pnlContent.Controls.Add(this.pnlPenalties);
            this.pnlContent.Controls.Add(this.pnlTournament);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(20, 20);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1127, 1200);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlFines
            // 
            this.pnlFines.Controls.Add(this.lblFinesTitle);
            this.pnlFines.Controls.Add(this.dgvFines);
            this.pnlFines.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFines.Location = new System.Drawing.Point(0, 800);
            this.pnlFines.Name = "pnlFines";
            this.pnlFines.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlFines.Size = new System.Drawing.Size(1127, 400);
            this.pnlFines.TabIndex = 2;
            // 
            // lblFinesTitle
            // 
            this.lblFinesTitle.AutoSize = true;
            this.lblFinesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFinesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFinesTitle.Location = new System.Drawing.Point(0, 20);
            this.lblFinesTitle.Name = "lblFinesTitle";
            this.lblFinesTitle.Size = new System.Drawing.Size(231, 21);
            this.lblFinesTitle.TabIndex = 0;
            this.lblFinesTitle.Text = "Multas por Tarjetas - Pagos";
            // 
            // dgvFines
            // 
            this.dgvFines.AllowUserToAddRows = false;
            this.dgvFines.AllowUserToDeleteRows = false;
            this.dgvFines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFines.BackgroundColor = System.Drawing.Color.White;
            this.dgvFines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvFines.Location = new System.Drawing.Point(0, 55);
            this.dgvFines.MultiSelect = false;
            this.dgvFines.Name = "dgvFines";
            this.dgvFines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFines.Size = new System.Drawing.Size(1127, 325);
            this.dgvFines.TabIndex = 1;
            // 
            // pnlPenalties
            // 
            this.pnlPenalties.Controls.Add(this.btnSavePenalties);
            this.pnlPenalties.Controls.Add(this.lblPenaltiesTitle);
            this.pnlPenalties.Controls.Add(this.dgvPenalties);
            this.pnlPenalties.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPenalties.Location = new System.Drawing.Point(0, 300);
            this.pnlPenalties.Name = "pnlPenalties";
            this.pnlPenalties.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnlPenalties.Size = new System.Drawing.Size(1127, 500);
            this.pnlPenalties.TabIndex = 1;
            // 
            // btnSavePenalties
            // 
            this.btnSavePenalties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSavePenalties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePenalties.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePenalties.ForeColor = System.Drawing.Color.White;
            this.btnSavePenalties.Location = new System.Drawing.Point(0, 430);
            this.btnSavePenalties.Name = "btnSavePenalties";
            this.btnSavePenalties.Size = new System.Drawing.Size(180, 40);
            this.btnSavePenalties.TabIndex = 2;
            this.btnSavePenalties.Text = "Guardar Cambios";
            this.btnSavePenalties.UseVisualStyleBackColor = false;
            this.btnSavePenalties.Click += new System.EventHandler(this.btnSavePenalties_Click);
            // 
            // lblPenaltiesTitle
            // 
            this.lblPenaltiesTitle.AutoSize = true;
            this.lblPenaltiesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPenaltiesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPenaltiesTitle.Location = new System.Drawing.Point(0, 20);
            this.lblPenaltiesTitle.Name = "lblPenaltiesTitle";
            this.lblPenaltiesTitle.Size = new System.Drawing.Size(265, 21);
            this.lblPenaltiesTitle.TabIndex = 0;
            this.lblPenaltiesTitle.Text = "Penalidades - Precios de Tarjetas";
            // 
            // dgvPenalties
            // 
            this.dgvPenalties.AllowUserToAddRows = false;
            this.dgvPenalties.AllowUserToDeleteRows = false;
            this.dgvPenalties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPenalties.BackgroundColor = System.Drawing.Color.White;
            this.dgvPenalties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPenalties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenalties.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvPenalties.Location = new System.Drawing.Point(0, 55);
            this.dgvPenalties.MultiSelect = false;
            this.dgvPenalties.Name = "dgvPenalties";
            this.dgvPenalties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPenalties.Size = new System.Drawing.Size(1127, 360);
            this.dgvPenalties.TabIndex = 1;
            // 
            // pnlTournament
            // 
            this.pnlTournament.Controls.Add(this.btnSaveTournament);
            this.pnlTournament.Controls.Add(this.cmbAgeCategory);
            this.pnlTournament.Controls.Add(this.lblAgeCategory);
            this.pnlTournament.Controls.Add(this.cmbGender);
            this.pnlTournament.Controls.Add(this.lblGender);
            this.pnlTournament.Controls.Add(this.txtYear);
            this.pnlTournament.Controls.Add(this.lblYear);
            this.pnlTournament.Controls.Add(this.txtName);
            this.pnlTournament.Controls.Add(this.lblName);
            this.pnlTournament.Controls.Add(this.lblTournamentTitle);
            this.pnlTournament.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTournament.Location = new System.Drawing.Point(0, 0);
            this.pnlTournament.Name = "pnlTournament";
            this.pnlTournament.Size = new System.Drawing.Size(1127, 300);
            this.pnlTournament.TabIndex = 0;
            // 
            // btnSaveTournament
            // 
            this.btnSaveTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSaveTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTournament.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveTournament.ForeColor = System.Drawing.Color.White;
            this.btnSaveTournament.Location = new System.Drawing.Point(0, 240);
            this.btnSaveTournament.Name = "btnSaveTournament";
            this.btnSaveTournament.Size = new System.Drawing.Size(180, 40);
            this.btnSaveTournament.TabIndex = 9;
            this.btnSaveTournament.Text = "Guardar Torneo";
            this.btnSaveTournament.UseVisualStyleBackColor = false;
            this.btnSaveTournament.Click += new System.EventHandler(this.btnSaveTournament_Click);
            // 
            // cmbAgeCategory
            // 
            this.cmbAgeCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgeCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAgeCategory.FormattingEnabled = true;
            this.cmbAgeCategory.Location = new System.Drawing.Point(400, 150);
            this.cmbAgeCategory.Name = "cmbAgeCategory";
            this.cmbAgeCategory.Size = new System.Drawing.Size(200, 25);
            this.cmbAgeCategory.TabIndex = 8;
            // 
            // lblAgeCategory
            // 
            this.lblAgeCategory.AutoSize = true;
            this.lblAgeCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAgeCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAgeCategory.Location = new System.Drawing.Point(400, 125);
            this.lblAgeCategory.Name = "lblAgeCategory";
            this.lblAgeCategory.Size = new System.Drawing.Size(137, 19);
            this.lblAgeCategory.TabIndex = 7;
            this.lblAgeCategory.Text = "Categoría de Edad:";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(0, 150);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 25);
            this.cmbGender.TabIndex = 6;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGender.Location = new System.Drawing.Point(0, 125);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(62, 19);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Género:";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYear.Location = new System.Drawing.Point(400, 85);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(200, 25);
            this.txtYear.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblYear.Location = new System.Drawing.Point(400, 60);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(36, 19);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(0, 85);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 25);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblName.Location = new System.Drawing.Point(0, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(141, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nombre del Torneo:";
            // 
            // lblTournamentTitle
            // 
            this.lblTournamentTitle.AutoSize = true;
            this.lblTournamentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTournamentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTournamentTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTournamentTitle.Name = "lblTournamentTitle";
            this.lblTournamentTitle.Size = new System.Drawing.Size(163, 21);
            this.lblTournamentTitle.TabIndex = 0;
            this.lblTournamentTitle.Text = "Datos del Torneo";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 728);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlFines.ResumeLayout(false);
            this.pnlFines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).EndInit();
            this.pnlPenalties.ResumeLayout(false);
            this.pnlPenalties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalties)).EndInit();
            this.pnlTournament.ResumeLayout(false);
            this.pnlTournament.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlTournament;
        private System.Windows.Forms.Label lblTournamentTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblAgeCategory;
        private System.Windows.Forms.ComboBox cmbAgeCategory;
        private System.Windows.Forms.Button btnSaveTournament;
        private System.Windows.Forms.Panel pnlPenalties;
        private System.Windows.Forms.Label lblPenaltiesTitle;
        private System.Windows.Forms.DataGridView dgvPenalties;
        private System.Windows.Forms.Button btnSavePenalties;
        private System.Windows.Forms.Panel pnlFines;
        private System.Windows.Forms.Label lblFinesTitle;
        private System.Windows.Forms.DataGridView dgvFines;
    }
}