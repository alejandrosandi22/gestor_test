namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class ReportsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbCtrlReport = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdTop10Players = new System.Windows.Forms.DataGridView();
            this.grdTableIncidents = new System.Windows.Forms.DataGridView();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnTeam = new System.Windows.Forms.Button();
            this.grdTeamPositions = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.tbCtrlReport.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTop10Players)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableIncidents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTeamPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCtrlReport
            // 
            this.tbCtrlReport.Controls.Add(this.tabPage1);
            this.tbCtrlReport.Controls.Add(this.tabPage2);
            this.tbCtrlReport.Controls.Add(this.tabPage3);
            this.tbCtrlReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCtrlReport.Location = new System.Drawing.Point(12, 52);
            this.tbCtrlReport.Name = "tbCtrlReport";
            this.tbCtrlReport.SelectedIndex = 0;
            this.tbCtrlReport.Size = new System.Drawing.Size(766, 401);
            this.tbCtrlReport.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTeam);
            this.tabPage1.Controls.Add(this.btnGeneral);
            this.tabPage1.Controls.Add(this.grdTableIncidents);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(758, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tabla Sanciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdTop10Players);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(730, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Top 10 Goleadores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdTeamPositions);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(730, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tabla de Posiciones";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdTop10Players
            // 
            this.grdTop10Players.AllowUserToAddRows = false;
            this.grdTop10Players.AllowUserToDeleteRows = false;
            this.grdTop10Players.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTop10Players.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTop10Players.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdTop10Players.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTop10Players.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdTop10Players.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTop10Players.Enabled = false;
            this.grdTop10Players.Location = new System.Drawing.Point(27, 44);
            this.grdTop10Players.MultiSelect = false;
            this.grdTop10Players.Name = "grdTop10Players";
            this.grdTop10Players.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTop10Players.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdTop10Players.RowHeadersVisible = false;
            this.grdTop10Players.RowTemplate.ReadOnly = true;
            this.grdTop10Players.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTop10Players.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTop10Players.Size = new System.Drawing.Size(671, 281);
            this.grdTop10Players.TabIndex = 0;
            // 
            // grdTableIncidents
            // 
            this.grdTableIncidents.AllowUserToAddRows = false;
            this.grdTableIncidents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdTableIncidents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTableIncidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTableIncidents.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTableIncidents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTableIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTableIncidents.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdTableIncidents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTableIncidents.Enabled = false;
            this.grdTableIncidents.Location = new System.Drawing.Point(19, 100);
            this.grdTableIncidents.MultiSelect = false;
            this.grdTableIncidents.Name = "grdTableIncidents";
            this.grdTableIncidents.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTableIncidents.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdTableIncidents.RowHeadersVisible = false;
            this.grdTableIncidents.RowTemplate.ReadOnly = true;
            this.grdTableIncidents.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTableIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTableIncidents.Size = new System.Drawing.Size(719, 224);
            this.grdTableIncidents.TabIndex = 1;
            // 
            // btnGeneral
            // 
            this.btnGeneral.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnGeneral.ForeColor = System.Drawing.Color.White;
            this.btnGeneral.Location = new System.Drawing.Point(19, 32);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(274, 36);
            this.btnGeneral.TabIndex = 2;
            this.btnGeneral.Text = "Sanciones en General";
            this.btnGeneral.UseVisualStyleBackColor = false;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnTeam
            // 
            this.btnTeam.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnTeam.ForeColor = System.Drawing.Color.White;
            this.btnTeam.Location = new System.Drawing.Point(466, 32);
            this.btnTeam.Name = "btnTeam";
            this.btnTeam.Size = new System.Drawing.Size(272, 36);
            this.btnTeam.TabIndex = 3;
            this.btnTeam.Text = "Sanciones por Equipo";
            this.btnTeam.UseVisualStyleBackColor = false;
            this.btnTeam.Click += new System.EventHandler(this.btnTeam_Click);
            // 
            // grdTeamPositions
            // 
            this.grdTeamPositions.AllowUserToAddRows = false;
            this.grdTeamPositions.AllowUserToDeleteRows = false;
            this.grdTeamPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTeamPositions.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTeamPositions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdTeamPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTeamPositions.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdTeamPositions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdTeamPositions.Enabled = false;
            this.grdTeamPositions.Location = new System.Drawing.Point(22, 46);
            this.grdTeamPositions.MultiSelect = false;
            this.grdTeamPositions.Name = "grdTeamPositions";
            this.grdTeamPositions.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTeamPositions.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdTeamPositions.RowHeadersVisible = false;
            this.grdTeamPositions.RowTemplate.ReadOnly = true;
            this.grdTeamPositions.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTeamPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTeamPositions.Size = new System.Drawing.Size(685, 281);
            this.grdTeamPositions.TabIndex = 1;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl.Location = new System.Drawing.Point(46, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(172, 31);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "REPORTES";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 470);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tbCtrlReport);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.tbCtrlReport.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTop10Players)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableIncidents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTeamPositions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbCtrlReport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdTableIncidents;
        private System.Windows.Forms.DataGridView grdTop10Players;
        private System.Windows.Forms.Button btnTeam;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.DataGridView grdTeamPositions;
        private System.Windows.Forms.Label lbl;
    }
}