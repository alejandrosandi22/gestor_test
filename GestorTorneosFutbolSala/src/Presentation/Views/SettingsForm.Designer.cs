using System.Windows.Forms;

namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlContent;
        private Panel pnlTournament;
        private Label lblTournamentTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblYear;
        private TextBox txtYear;
        private Label lblGender;
        private ComboBox cmbGender;
        private Label lblAgeCategory;
        private ComboBox cmbAgeCategory;
        private Button btnSaveTournament;
        private Panel pnlPenalties;
        private Label lblPenaltiesTitle;
        private Label lblYellowCardPrice;
        private TextBox txtYellowCardPrice;
        private Label lblRedCardPrice;
        private TextBox txtRedCardPrice;
        private Label lblBlueCardPrice;
        private TextBox txtBlueCardPrice;
        private Button btnSavePenalties;
        private Panel pnlIncidents;
        private Label lblIncidentsTitle;
        private DataGridView dgvIncidents;
        private Panel pnlFines;
        private Label lblFinesTitle;
        private DataGridView dgvFines;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
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
            this.pnlPenalties = new System.Windows.Forms.Panel();
            this.btnSavePenalties = new System.Windows.Forms.Button();
            this.txtBlueCardPrice = new System.Windows.Forms.TextBox();
            this.lblBlueCardPrice = new System.Windows.Forms.Label();
            this.txtRedCardPrice = new System.Windows.Forms.TextBox();
            this.lblRedCardPrice = new System.Windows.Forms.Label();
            this.txtYellowCardPrice = new System.Windows.Forms.TextBox();
            this.lblYellowCardPrice = new System.Windows.Forms.Label();
            this.lblPenaltiesTitle = new System.Windows.Forms.Label();
            this.pnlIncidents = new System.Windows.Forms.Panel();
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.lblIncidentsTitle = new System.Windows.Forms.Label();
            this.pnlFines = new System.Windows.Forms.Panel();
            this.dgvFines = new System.Windows.Forms.DataGridView();
            this.lblFinesTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTournament.SuspendLayout();
            this.pnlPenalties.SuspendLayout();
            this.pnlIncidents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.pnlFines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).BeginInit();
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
            this.pnlMain.Size = new System.Drawing.Size(957, 711);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContent.Controls.Add(this.pnlTournament);
            this.pnlContent.Controls.Add(this.pnlPenalties);
            this.pnlContent.Controls.Add(this.pnlIncidents);
            this.pnlContent.Controls.Add(this.pnlFines);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlContent.Size = new System.Drawing.Size(736, 1091);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlTournament
            // 
            this.pnlTournament.AutoSize = true;
            this.pnlTournament.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.pnlTournament.Location = new System.Drawing.Point(0, 0);
            this.pnlTournament.Name = "pnlTournament";
            this.pnlTournament.Size = new System.Drawing.Size(603, 223);
            this.pnlTournament.TabIndex = 0;
            // 
            // btnSaveTournament
            // 
            this.btnSaveTournament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSaveTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTournament.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveTournament.ForeColor = System.Drawing.Color.White;
            this.btnSaveTournament.Location = new System.Drawing.Point(0, 180);
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
            this.cmbAgeCategory.Size = new System.Drawing.Size(200, 31);
            this.cmbAgeCategory.TabIndex = 8;
            // 
            // lblAgeCategory
            // 
            this.lblAgeCategory.AutoSize = true;
            this.lblAgeCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAgeCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblAgeCategory.Location = new System.Drawing.Point(400, 125);
            this.lblAgeCategory.Name = "lblAgeCategory";
            this.lblAgeCategory.Size = new System.Drawing.Size(163, 23);
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
            this.cmbGender.Size = new System.Drawing.Size(200, 31);
            this.cmbGender.TabIndex = 6;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblGender.Location = new System.Drawing.Point(0, 125);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(72, 23);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Género:";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYear.Location = new System.Drawing.Point(400, 85);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(200, 30);
            this.txtYear.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblYear.Location = new System.Drawing.Point(400, 60);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(47, 23);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Año:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(0, 85);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 30);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblName.Location = new System.Drawing.Point(0, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(170, 23);
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
            this.lblTournamentTitle.Size = new System.Drawing.Size(173, 28);
            this.lblTournamentTitle.TabIndex = 0;
            this.lblTournamentTitle.Text = "Datos del Torneo";
            // 
            // pnlPenalties
            // 
            this.pnlPenalties.AutoSize = true;
            this.pnlPenalties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPenalties.Controls.Add(this.btnSavePenalties);
            this.pnlPenalties.Controls.Add(this.txtBlueCardPrice);
            this.pnlPenalties.Controls.Add(this.lblBlueCardPrice);
            this.pnlPenalties.Controls.Add(this.txtRedCardPrice);
            this.pnlPenalties.Controls.Add(this.lblRedCardPrice);
            this.pnlPenalties.Controls.Add(this.txtYellowCardPrice);
            this.pnlPenalties.Controls.Add(this.lblYellowCardPrice);
            this.pnlPenalties.Controls.Add(this.lblPenaltiesTitle);
            this.pnlPenalties.Location = new System.Drawing.Point(0, 200);
            this.pnlPenalties.Name = "pnlPenalties";
            this.pnlPenalties.Size = new System.Drawing.Size(324, 238);
            this.pnlPenalties.TabIndex = 1;
            // 
            // btnSavePenalties
            // 
            this.btnSavePenalties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSavePenalties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePenalties.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSavePenalties.ForeColor = System.Drawing.Color.White;
            this.btnSavePenalties.Location = new System.Drawing.Point(3, 195);
            this.btnSavePenalties.Name = "btnSavePenalties";
            this.btnSavePenalties.Size = new System.Drawing.Size(180, 40);
            this.btnSavePenalties.TabIndex = 7;
            this.btnSavePenalties.Text = "Guardar Cambios";
            this.btnSavePenalties.UseVisualStyleBackColor = false;
            this.btnSavePenalties.Click += new System.EventHandler(this.btnSavePenalties_Click);
            // 
            // txtBlueCardPrice
            // 
            this.txtBlueCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBlueCardPrice.Location = new System.Drawing.Point(140, 103);
            this.txtBlueCardPrice.Name = "txtBlueCardPrice";
            this.txtBlueCardPrice.Size = new System.Drawing.Size(150, 30);
            this.txtBlueCardPrice.TabIndex = 6;
            // 
            // lblBlueCardPrice
            // 
            this.lblBlueCardPrice.AutoSize = true;
            this.lblBlueCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBlueCardPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBlueCardPrice.Location = new System.Drawing.Point(20, 106);
            this.lblBlueCardPrice.Name = "lblBlueCardPrice";
            this.lblBlueCardPrice.Size = new System.Drawing.Size(110, 23);
            this.lblBlueCardPrice.TabIndex = 5;
            this.lblBlueCardPrice.Text = "Tarjeta Azul:";
            // 
            // txtRedCardPrice
            // 
            this.txtRedCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRedCardPrice.Location = new System.Drawing.Point(140, 148);
            this.txtRedCardPrice.Name = "txtRedCardPrice";
            this.txtRedCardPrice.Size = new System.Drawing.Size(150, 30);
            this.txtRedCardPrice.TabIndex = 4;
            // 
            // lblRedCardPrice
            // 
            this.lblRedCardPrice.AutoSize = true;
            this.lblRedCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRedCardPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblRedCardPrice.Location = new System.Drawing.Point(20, 151);
            this.lblRedCardPrice.Name = "lblRedCardPrice";
            this.lblRedCardPrice.Size = new System.Drawing.Size(110, 23);
            this.lblRedCardPrice.TabIndex = 3;
            this.lblRedCardPrice.Text = "Tarjeta Roja:";
            // 
            // txtYellowCardPrice
            // 
            this.txtYellowCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYellowCardPrice.Location = new System.Drawing.Point(140, 57);
            this.txtYellowCardPrice.Name = "txtYellowCardPrice";
            this.txtYellowCardPrice.Size = new System.Drawing.Size(150, 30);
            this.txtYellowCardPrice.TabIndex = 2;
            // 
            // lblYellowCardPrice
            // 
            this.lblYellowCardPrice.AutoSize = true;
            this.lblYellowCardPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYellowCardPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblYellowCardPrice.Location = new System.Drawing.Point(0, 60);
            this.lblYellowCardPrice.Name = "lblYellowCardPrice";
            this.lblYellowCardPrice.Size = new System.Drawing.Size(143, 23);
            this.lblYellowCardPrice.TabIndex = 1;
            this.lblYellowCardPrice.Text = "Tarjeta Amarilla:";
            // 
            // lblPenaltiesTitle
            // 
            this.lblPenaltiesTitle.AutoSize = true;
            this.lblPenaltiesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPenaltiesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblPenaltiesTitle.Location = new System.Drawing.Point(0, 20);
            this.lblPenaltiesTitle.Name = "lblPenaltiesTitle";
            this.lblPenaltiesTitle.Size = new System.Drawing.Size(321, 28);
            this.lblPenaltiesTitle.TabIndex = 0;
            this.lblPenaltiesTitle.Text = "Penalidades - Precios de Tarjetas";
            // 
            // pnlIncidents
            // 
            this.pnlIncidents.AutoSize = true;
            this.pnlIncidents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlIncidents.Controls.Add(this.dgvIncidents);
            this.pnlIncidents.Controls.Add(this.lblIncidentsTitle);
            this.pnlIncidents.Location = new System.Drawing.Point(4, 460);
            this.pnlIncidents.Name = "pnlIncidents";
            this.pnlIncidents.Size = new System.Drawing.Size(704, 283);
            this.pnlIncidents.TabIndex = 2;
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncidents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvIncidents.Location = new System.Drawing.Point(0, 55);
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.RowHeadersWidth = 51;
            this.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidents.Size = new System.Drawing.Size(701, 225);
            this.dgvIncidents.TabIndex = 1;
            // 
            // lblIncidentsTitle
            // 
            this.lblIncidentsTitle.AutoSize = true;
            this.lblIncidentsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblIncidentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblIncidentsTitle.Location = new System.Drawing.Point(0, 20);
            this.lblIncidentsTitle.Name = "lblIncidentsTitle";
            this.lblIncidentsTitle.Size = new System.Drawing.Size(233, 28);
            this.lblIncidentsTitle.TabIndex = 0;
            this.lblIncidentsTitle.Text = "Incidencias Registradas";
            // 
            // pnlFines
            // 
            this.pnlFines.AutoSize = true;
            this.pnlFines.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFines.Controls.Add(this.dgvFines);
            this.pnlFines.Controls.Add(this.lblFinesTitle);
            this.pnlFines.Location = new System.Drawing.Point(4, 770);
            this.pnlFines.Name = "pnlFines";
            this.pnlFines.Size = new System.Drawing.Size(709, 318);
            this.pnlFines.TabIndex = 3;
            // 
            // dgvFines
            // 
            this.dgvFines.BackgroundColor = System.Drawing.Color.White;
            this.dgvFines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dgvFines.Location = new System.Drawing.Point(0, 55);
            this.dgvFines.Name = "dgvFines";
            this.dgvFines.RowHeadersWidth = 51;
            this.dgvFines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFines.Size = new System.Drawing.Size(706, 260);
            this.dgvFines.TabIndex = 1;
            // 
            // lblFinesTitle
            // 
            this.lblFinesTitle.AutoSize = true;
            this.lblFinesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFinesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFinesTitle.Location = new System.Drawing.Point(0, 20);
            this.lblFinesTitle.Name = "lblFinesTitle";
            this.lblFinesTitle.Size = new System.Drawing.Size(271, 28);
            this.lblFinesTitle.TabIndex = 0;
            this.lblFinesTitle.Text = "Multas por Tarjetas - Pagos";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 711);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlTournament.ResumeLayout(false);
            this.pnlTournament.PerformLayout();
            this.pnlPenalties.ResumeLayout(false);
            this.pnlPenalties.PerformLayout();
            this.pnlIncidents.ResumeLayout(false);
            this.pnlIncidents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.pnlFines.ResumeLayout(false);
            this.pnlFines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFines)).EndInit();
            this.ResumeLayout(false);

        }
    }
}