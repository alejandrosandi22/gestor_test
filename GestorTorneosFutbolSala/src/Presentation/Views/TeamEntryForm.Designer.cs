namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class TeamEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamEntryForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblSpace = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDivider2 = new System.Windows.Forms.Label();
            this.lblPlayersSection = new System.Windows.Forms.Label();
            this.pnlPlayersActions = new System.Windows.Forms.Panel();
            this.btnRemovePlayer = new System.Windows.Forms.Button();
            this.btnEditPlayer = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.lblPlayersCount = new System.Windows.Forms.Label();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.colPlayerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerIdNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDivider1 = new System.Windows.Forms.Label();
            this.lblContactPhoneError = new System.Windows.Forms.Label();
            this.txtContactPhone = new System.Windows.Forms.TextBox();
            this.lblContactPhone = new System.Windows.Forms.Label();
            this.lblManagerError = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblOriginLocationError = new System.Windows.Forms.Label();
            this.txtOriginLocation = new System.Windows.Forms.TextBox();
            this.lblOriginLocation = new System.Windows.Forms.Label();
            this.lblTeamNameError = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblBasicInformation = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlPlayersActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.lblSpace);
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.lblDivider2);
            this.pnlContent.Controls.Add(this.lblPlayersSection);
            this.pnlContent.Controls.Add(this.pnlPlayersActions);
            this.pnlContent.Controls.Add(this.lblPlayersCount);
            this.pnlContent.Controls.Add(this.dgvPlayers);
            this.pnlContent.Controls.Add(this.lblDivider1);
            this.pnlContent.Controls.Add(this.lblContactPhoneError);
            this.pnlContent.Controls.Add(this.txtContactPhone);
            this.pnlContent.Controls.Add(this.lblContactPhone);
            this.pnlContent.Controls.Add(this.lblManagerError);
            this.pnlContent.Controls.Add(this.txtManager);
            this.pnlContent.Controls.Add(this.lblManager);
            this.pnlContent.Controls.Add(this.lblOriginLocationError);
            this.pnlContent.Controls.Add(this.txtOriginLocation);
            this.pnlContent.Controls.Add(this.lblOriginLocation);
            this.pnlContent.Controls.Add(this.lblTeamNameError);
            this.pnlContent.Controls.Add(this.txtTeamName);
            this.pnlContent.Controls.Add(this.lblTeamName);
            this.pnlContent.Controls.Add(this.lblBasicInformation);
            this.pnlContent.Location = new System.Drawing.Point(0, 93);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.pnlContent.Size = new System.Drawing.Size(1151, 689);
            this.pnlContent.TabIndex = 0;
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Location = new System.Drawing.Point(874, 894);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(0, 16);
            this.lblSpace.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(804, 799);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(287, 53);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Crear Equipo";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDivider2
            // 
            this.lblDivider2.AutoSize = true;
            this.lblDivider2.Location = new System.Drawing.Point(40, 347);
            this.lblDivider2.Name = "lblDivider2";
            this.lblDivider2.Size = new System.Drawing.Size(0, 16);
            this.lblDivider2.TabIndex = 17;
            // 
            // lblPlayersSection
            // 
            this.lblPlayersSection.AutoSize = true;
            this.lblPlayersSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayersSection.Location = new System.Drawing.Point(38, 311);
            this.lblPlayersSection.Name = "lblPlayersSection";
            this.lblPlayersSection.Size = new System.Drawing.Size(127, 29);
            this.lblPlayersSection.TabIndex = 16;
            this.lblPlayersSection.Text = "Jugadores";
            // 
            // pnlPlayersActions
            // 
            this.pnlPlayersActions.Controls.Add(this.btnRemovePlayer);
            this.pnlPlayersActions.Controls.Add(this.btnEditPlayer);
            this.pnlPlayersActions.Controls.Add(this.btnAddPlayer);
            this.pnlPlayersActions.Location = new System.Drawing.Point(43, 743);
            this.pnlPlayersActions.Name = "pnlPlayersActions";
            this.pnlPlayersActions.Size = new System.Drawing.Size(1296, 50);
            this.pnlPlayersActions.TabIndex = 21;
            // 
            // btnRemovePlayer
            // 
            this.btnRemovePlayer.BackColor = System.Drawing.Color.Crimson;
            this.btnRemovePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemovePlayer.ForeColor = System.Drawing.Color.White;
            this.btnRemovePlayer.Location = new System.Drawing.Point(260, 10);
            this.btnRemovePlayer.Name = "btnRemovePlayer";
            this.btnRemovePlayer.Size = new System.Drawing.Size(120, 35);
            this.btnRemovePlayer.TabIndex = 2;
            this.btnRemovePlayer.Text = "Eliminar";
            this.btnRemovePlayer.UseVisualStyleBackColor = false;
            this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.BackColor = System.Drawing.Color.Orange;
            this.btnEditPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPlayer.ForeColor = System.Drawing.Color.White;
            this.btnEditPlayer.Location = new System.Drawing.Point(130, 10);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(120, 35);
            this.btnEditPlayer.TabIndex = 1;
            this.btnEditPlayer.Text = "Editar";
            this.btnEditPlayer.UseVisualStyleBackColor = false;
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAddPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPlayer.ForeColor = System.Drawing.Color.White;
            this.btnAddPlayer.Location = new System.Drawing.Point(0, 10);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(120, 35);
            this.btnAddPlayer.TabIndex = 0;
            this.btnAddPlayer.Text = "Agregar";
            this.btnAddPlayer.UseVisualStyleBackColor = false;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // lblPlayersCount
            // 
            this.lblPlayersCount.AutoSize = true;
            this.lblPlayersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayersCount.Location = new System.Drawing.Point(39, 380);
            this.lblPlayersCount.Name = "lblPlayersCount";
            this.lblPlayersCount.Size = new System.Drawing.Size(139, 22);
            this.lblPlayersCount.TabIndex = 20;
            this.lblPlayersCount.Text = "Jugadores: 0/12";
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlayerId,
            this.colPlayerIdNumber,
            this.colPlayerName,
            this.colPlayerBirthDate,
            this.colPlayerAge});
            this.dgvPlayers.Location = new System.Drawing.Point(43, 415);
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersWidth = 51;
            this.dgvPlayers.RowTemplate.Height = 24;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(1048, 322);
            this.dgvPlayers.TabIndex = 5;
            this.dgvPlayers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellDoubleClick);
            // 
            // colPlayerId
            // 
            this.colPlayerId.HeaderText = "ID";
            this.colPlayerId.MinimumWidth = 6;
            this.colPlayerId.Name = "colPlayerId";
            this.colPlayerId.ReadOnly = true;
            this.colPlayerId.Visible = false;
            // 
            // colPlayerIdNumber
            // 
            this.colPlayerIdNumber.HeaderText = "Cédula";
            this.colPlayerIdNumber.MinimumWidth = 6;
            this.colPlayerIdNumber.Name = "colPlayerIdNumber";
            this.colPlayerIdNumber.ReadOnly = true;
            // 
            // colPlayerName
            // 
            this.colPlayerName.HeaderText = "Nombre Completo";
            this.colPlayerName.MinimumWidth = 6;
            this.colPlayerName.Name = "colPlayerName";
            this.colPlayerName.ReadOnly = true;
            // 
            // colPlayerBirthDate
            // 
            this.colPlayerBirthDate.HeaderText = "Fecha de Nacimiento";
            this.colPlayerBirthDate.MinimumWidth = 6;
            this.colPlayerBirthDate.Name = "colPlayerBirthDate";
            this.colPlayerBirthDate.ReadOnly = true;
            // 
            // colPlayerAge
            // 
            this.colPlayerAge.HeaderText = "Edad";
            this.colPlayerAge.MinimumWidth = 6;
            this.colPlayerAge.Name = "colPlayerAge";
            this.colPlayerAge.ReadOnly = true;
            // 
            // lblDivider1
            // 
            this.lblDivider1.AutoSize = true;
            this.lblDivider1.Location = new System.Drawing.Point(40, 68);
            this.lblDivider1.Name = "lblDivider1";
            this.lblDivider1.Size = new System.Drawing.Size(0, 16);
            this.lblDivider1.TabIndex = 15;
            // 
            // lblContactPhoneError
            // 
            this.lblContactPhoneError.AutoSize = true;
            this.lblContactPhoneError.ForeColor = System.Drawing.Color.Red;
            this.lblContactPhoneError.Location = new System.Drawing.Point(504, 291);
            this.lblContactPhoneError.Name = "lblContactPhoneError";
            this.lblContactPhoneError.Size = new System.Drawing.Size(0, 16);
            this.lblContactPhoneError.TabIndex = 14;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPhone.Location = new System.Drawing.Point(603, 251);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.Size = new System.Drawing.Size(488, 34);
            this.txtContactPhone.TabIndex = 4;
            // 
            // lblContactPhone
            // 
            this.lblContactPhone.AutoSize = true;
            this.lblContactPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactPhone.Location = new System.Drawing.Point(598, 219);
            this.lblContactPhone.Name = "lblContactPhone";
            this.lblContactPhone.Size = new System.Drawing.Size(211, 29);
            this.lblContactPhone.TabIndex = 13;
            this.lblContactPhone.Text = "Teléfono Contacto";
            // 
            // lblManagerError
            // 
            this.lblManagerError.AutoSize = true;
            this.lblManagerError.ForeColor = System.Drawing.Color.Red;
            this.lblManagerError.Location = new System.Drawing.Point(40, 291);
            this.lblManagerError.Name = "lblManagerError";
            this.lblManagerError.Size = new System.Drawing.Size(0, 16);
            this.lblManagerError.TabIndex = 12;
            // 
            // txtManager
            // 
            this.txtManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManager.Location = new System.Drawing.Point(43, 251);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(402, 34);
            this.txtManager.TabIndex = 3;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManager.Location = new System.Drawing.Point(38, 219);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(130, 29);
            this.lblManager.TabIndex = 11;
            this.lblManager.Text = "Encargado";
            // 
            // lblOriginLocationError
            // 
            this.lblOriginLocationError.AutoSize = true;
            this.lblOriginLocationError.ForeColor = System.Drawing.Color.Red;
            this.lblOriginLocationError.Location = new System.Drawing.Point(504, 190);
            this.lblOriginLocationError.Name = "lblOriginLocationError";
            this.lblOriginLocationError.Size = new System.Drawing.Size(0, 16);
            this.lblOriginLocationError.TabIndex = 10;
            // 
            // txtOriginLocation
            // 
            this.txtOriginLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginLocation.Location = new System.Drawing.Point(603, 153);
            this.txtOriginLocation.Name = "txtOriginLocation";
            this.txtOriginLocation.Size = new System.Drawing.Size(488, 34);
            this.txtOriginLocation.TabIndex = 2;
            // 
            // lblOriginLocation
            // 
            this.lblOriginLocation.AutoSize = true;
            this.lblOriginLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginLocation.Location = new System.Drawing.Point(598, 121);
            this.lblOriginLocation.Name = "lblOriginLocation";
            this.lblOriginLocation.Size = new System.Drawing.Size(188, 29);
            this.lblOriginLocation.TabIndex = 9;
            this.lblOriginLocation.Text = "Lugar de Origen";
            // 
            // lblTeamNameError
            // 
            this.lblTeamNameError.AutoSize = true;
            this.lblTeamNameError.ForeColor = System.Drawing.Color.Red;
            this.lblTeamNameError.Location = new System.Drawing.Point(40, 190);
            this.lblTeamNameError.Name = "lblTeamNameError";
            this.lblTeamNameError.Size = new System.Drawing.Size(0, 16);
            this.lblTeamNameError.TabIndex = 8;
            // 
            // txtTeamName
            // 
            this.txtTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(43, 153);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(402, 34);
            this.txtTeamName.TabIndex = 1;
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(38, 121);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(224, 29);
            this.lblTeamName.TabIndex = 7;
            this.lblTeamName.Text = "Nombre del Equipo";
            // 
            // lblBasicInformation
            // 
            this.lblBasicInformation.AutoSize = true;
            this.lblBasicInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInformation.Location = new System.Drawing.Point(38, 32);
            this.lblBasicInformation.Name = "lblBasicInformation";
            this.lblBasicInformation.Size = new System.Drawing.Size(216, 29);
            this.lblBasicInformation.TabIndex = 0;
            this.lblBasicInformation.Text = "Información Básica";
            // 
            // btnGoBack
            // 
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Image = ((System.Drawing.Image)(resources.GetObject("btnGoBack.Image")));
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(43, 37);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(131, 36);
            this.btnGoBack.TabIndex = 1;
            this.btnGoBack.Text = "Volver";
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // TeamEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1149, 689);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.pnlContent);
            this.Name = "TeamEntryForm";
            this.Text = "TeamEntryForm";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlPlayersActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDivider2;
        private System.Windows.Forms.Label lblPlayersSection;
        private System.Windows.Forms.Panel pnlPlayersActions;
        private System.Windows.Forms.Button btnRemovePlayer;
        private System.Windows.Forms.Button btnEditPlayer;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Label lblPlayersCount;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerIdNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerAge;
        private System.Windows.Forms.Label lblDivider1;
        private System.Windows.Forms.Label lblContactPhoneError;
        private System.Windows.Forms.TextBox txtContactPhone;
        private System.Windows.Forms.Label lblContactPhone;
        private System.Windows.Forms.Label lblManagerError;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblOriginLocationError;
        private System.Windows.Forms.TextBox txtOriginLocation;
        private System.Windows.Forms.Label lblOriginLocation;
        private System.Windows.Forms.Label lblTeamNameError;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblBasicInformation;
        private System.Windows.Forms.Button btnGoBack;
    }
}