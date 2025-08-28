namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class MatchDetailsForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMatchTitle = new System.Windows.Forms.Label();
            this.pnlMatchInfo = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.pnlIncidentForm = new System.Windows.Forms.Panel();
            this.btnAddIncident = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.lblMinute = new System.Windows.Forms.Label();
            this.cmbIncidentType = new System.Windows.Forms.ComboBox();
            this.lblIncidentType = new System.Windows.Forms.Label();
            this.cmbPlayer = new System.Windows.Forms.ComboBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblAddIncident = new System.Windows.Forms.Label();
            this.pnlIncidentsList = new System.Windows.Forms.Panel();
            this.btnDeleteIncident = new System.Windows.Forms.Button();
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.lblIncidents = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMatchInfo.SuspendLayout();
            this.pnlIncidentForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            this.pnlIncidentsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnSave);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblMatchTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1151, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(951, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1051, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMatchTitle
            // 
            this.lblMatchTitle.AutoSize = true;
            this.lblMatchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblMatchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblMatchTitle.Location = new System.Drawing.Point(20, 18);
            this.lblMatchTitle.Name = "lblMatchTitle";
            this.lblMatchTitle.Size = new System.Drawing.Size(244, 29);
            this.lblMatchTitle.TabIndex = 0;
            this.lblMatchTitle.Text = "Detalles del Partido";
            // 
            // pnlMatchInfo
            // 
            this.pnlMatchInfo.BackColor = System.Drawing.Color.White;
            this.pnlMatchInfo.Controls.Add(this.lblDateTime);
            this.pnlMatchInfo.Controls.Add(this.lblLocation);
            this.pnlMatchInfo.Controls.Add(this.lblScore);
            this.pnlMatchInfo.Controls.Add(this.lblAwayTeam);
            this.pnlMatchInfo.Controls.Add(this.lblHomeTeam);
            this.pnlMatchInfo.Location = new System.Drawing.Point(20, 80);
            this.pnlMatchInfo.Name = "pnlMatchInfo";
            this.pnlMatchInfo.Size = new System.Drawing.Size(1111, 120);
            this.pnlMatchInfo.TabIndex = 1;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateTime.Location = new System.Drawing.Point(20, 85);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(129, 18);
            this.lblDateTime.TabIndex = 4;
            this.lblDateTime.Text = "Fecha: 01/01/2025";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblLocation.ForeColor = System.Drawing.Color.Gray;
            this.lblLocation.Location = new System.Drawing.Point(20, 60);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(183, 18);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Ubicación: Estadio Central";
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblScore.Location = new System.Drawing.Point(532, 29);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(210, 50);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0 - 0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblAwayTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblAwayTeam.Location = new System.Drawing.Point(790, 45);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(284, 30);
            this.lblAwayTeam.TabIndex = 1;
            this.lblAwayTeam.Text = "Equipo Visitante";
            this.lblAwayTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblHomeTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblHomeTeam.Location = new System.Drawing.Point(241, 45);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(264, 30);
            this.lblHomeTeam.TabIndex = 0;
            this.lblHomeTeam.Text = "Equipo Local";
            this.lblHomeTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlIncidentForm
            // 
            this.pnlIncidentForm.BackColor = System.Drawing.Color.White;
            this.pnlIncidentForm.Controls.Add(this.btnAddIncident);
            this.pnlIncidentForm.Controls.Add(this.txtNotes);
            this.pnlIncidentForm.Controls.Add(this.lblNotes);
            this.pnlIncidentForm.Controls.Add(this.nudMinute);
            this.pnlIncidentForm.Controls.Add(this.lblMinute);
            this.pnlIncidentForm.Controls.Add(this.cmbIncidentType);
            this.pnlIncidentForm.Controls.Add(this.lblIncidentType);
            this.pnlIncidentForm.Controls.Add(this.cmbPlayer);
            this.pnlIncidentForm.Controls.Add(this.lblPlayer);
            this.pnlIncidentForm.Controls.Add(this.lblAddIncident);
            this.pnlIncidentForm.Location = new System.Drawing.Point(20, 220);
            this.pnlIncidentForm.Name = "pnlIncidentForm";
            this.pnlIncidentForm.Size = new System.Drawing.Size(1111, 180);
            this.pnlIncidentForm.TabIndex = 2;
            // 
            // btnAddIncident
            // 
            this.btnAddIncident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnAddIncident.FlatAppearance.BorderSize = 0;
            this.btnAddIncident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddIncident.ForeColor = System.Drawing.Color.White;
            this.btnAddIncident.Location = new System.Drawing.Point(950, 130);
            this.btnAddIncident.Name = "btnAddIncident";
            this.btnAddIncident.Size = new System.Drawing.Size(140, 35);
            this.btnAddIncident.TabIndex = 9;
            this.btnAddIncident.Text = "Agregar Incidente";
            this.btnAddIncident.UseVisualStyleBackColor = false;
            this.btnAddIncident.Click += new System.EventHandler(this.btnAddIncident_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNotes.Location = new System.Drawing.Point(650, 90);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(280, 75);
            this.txtNotes.TabIndex = 8;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblNotes.Location = new System.Drawing.Point(650, 65);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(48, 18);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notas";
            // 
            // nudMinute
            // 
            this.nudMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nudMinute.Location = new System.Drawing.Point(480, 90);
            this.nudMinute.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(120, 24);
            this.nudMinute.TabIndex = 6;
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblMinute.Location = new System.Drawing.Point(480, 65);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(53, 18);
            this.lblMinute.TabIndex = 5;
            this.lblMinute.Text = "Minuto";
            // 
            // cmbIncidentType
            // 
            this.cmbIncidentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncidentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIncidentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbIncidentType.FormattingEnabled = true;
            this.cmbIncidentType.Location = new System.Drawing.Point(310, 90);
            this.cmbIncidentType.Name = "cmbIncidentType";
            this.cmbIncidentType.Size = new System.Drawing.Size(140, 26);
            this.cmbIncidentType.TabIndex = 4;
            // 
            // lblIncidentType
            // 
            this.lblIncidentType.AutoSize = true;
            this.lblIncidentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblIncidentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblIncidentType.Location = new System.Drawing.Point(310, 65);
            this.lblIncidentType.Name = "lblIncidentType";
            this.lblIncidentType.Size = new System.Drawing.Size(106, 18);
            this.lblIncidentType.TabIndex = 3;
            this.lblIncidentType.Text = "Tipo Incidencia";
            // 
            // cmbPlayer
            // 
            this.cmbPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbPlayer.FormattingEnabled = true;
            this.cmbPlayer.Location = new System.Drawing.Point(20, 90);
            this.cmbPlayer.Name = "cmbPlayer";
            this.cmbPlayer.Size = new System.Drawing.Size(260, 26);
            this.cmbPlayer.TabIndex = 2;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblPlayer.Location = new System.Drawing.Point(20, 65);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(62, 18);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "Jugador";
            // 
            // lblAddIncident
            // 
            this.lblAddIncident.AutoSize = true;
            this.lblAddIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblAddIncident.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblAddIncident.Location = new System.Drawing.Point(20, 20);
            this.lblAddIncident.Name = "lblAddIncident";
            this.lblAddIncident.Size = new System.Drawing.Size(187, 24);
            this.lblAddIncident.TabIndex = 0;
            this.lblAddIncident.Text = "Agregar Incidencia";
            // 
            // pnlIncidentsList
            // 
            this.pnlIncidentsList.BackColor = System.Drawing.Color.White;
            this.pnlIncidentsList.Controls.Add(this.btnDeleteIncident);
            this.pnlIncidentsList.Controls.Add(this.dgvIncidents);
            this.pnlIncidentsList.Controls.Add(this.lblIncidents);
            this.pnlIncidentsList.Location = new System.Drawing.Point(20, 420);
            this.pnlIncidentsList.Name = "pnlIncidentsList";
            this.pnlIncidentsList.Size = new System.Drawing.Size(1111, 249);
            this.pnlIncidentsList.TabIndex = 3;
            // 
            // btnDeleteIncident
            // 
            this.btnDeleteIncident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteIncident.FlatAppearance.BorderSize = 0;
            this.btnDeleteIncident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteIncident.ForeColor = System.Drawing.Color.White;
            this.btnDeleteIncident.Location = new System.Drawing.Point(970, 45);
            this.btnDeleteIncident.Name = "btnDeleteIncident";
            this.btnDeleteIncident.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteIncident.TabIndex = 2;
            this.btnDeleteIncident.Text = "Eliminar";
            this.btnDeleteIncident.UseVisualStyleBackColor = false;
            this.btnDeleteIncident.Click += new System.EventHandler(this.btnDeleteIncident_Click);
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.AllowUserToAddRows = false;
            this.dgvIncidents.AllowUserToDeleteRows = false;
            this.dgvIncidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncidents.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncidents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvIncidents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvIncidents.Location = new System.Drawing.Point(20, 90);
            this.dgvIncidents.MultiSelect = false;
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.ReadOnly = true;
            this.dgvIncidents.RowHeadersVisible = false;
            this.dgvIncidents.RowHeadersWidth = 51;
            this.dgvIncidents.RowTemplate.Height = 30;
            this.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidents.Size = new System.Drawing.Size(1070, 140);
            this.dgvIncidents.TabIndex = 1;
            // 
            // lblIncidents
            // 
            this.lblIncidents.AutoSize = true;
            this.lblIncidents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblIncidents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblIncidents.Location = new System.Drawing.Point(20, 20);
            this.lblIncidents.Name = "lblIncidents";
            this.lblIncidents.Size = new System.Drawing.Size(222, 24);
            this.lblIncidents.TabIndex = 0;
            this.lblIncidents.Text = "Incidencias del Partido";
            // 
            // MatchDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1151, 689);
            this.Controls.Add(this.pnlIncidentsList);
            this.Controls.Add(this.pnlIncidentForm);
            this.Controls.Add(this.pnlMatchInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MatchDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles del Partido";
            this.Load += new System.EventHandler(this.MatchDetailsForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMatchInfo.ResumeLayout(false);
            this.pnlMatchInfo.PerformLayout();
            this.pnlIncidentForm.ResumeLayout(false);
            this.pnlIncidentForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            this.pnlIncidentsList.ResumeLayout(false);
            this.pnlIncidentsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMatchTitle;
        private System.Windows.Forms.Panel pnlMatchInfo;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblAwayTeam;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Panel pnlIncidentForm;
        private System.Windows.Forms.Button btnAddIncident;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.ComboBox cmbIncidentType;
        private System.Windows.Forms.Label lblIncidentType;
        private System.Windows.Forms.ComboBox cmbPlayer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label lblAddIncident;
        private System.Windows.Forms.Panel pnlIncidentsList;
        private System.Windows.Forms.Button btnDeleteIncident;
        private System.Windows.Forms.DataGridView dgvIncidents;
        private System.Windows.Forms.Label lblIncidents;
    }
}