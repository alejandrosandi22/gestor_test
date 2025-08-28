namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class StatisticsForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tbcStatistics = new System.Windows.Forms.TabControl();
            this.tabStandings = new System.Windows.Forms.TabPage();
            this.pnlStandings = new System.Windows.Forms.Panel();
            this.dgvStandings = new System.Windows.Forms.DataGridView();
            this.lblStandingsTitle = new System.Windows.Forms.Label();
            this.tabTopScorers = new System.Windows.Forms.TabPage();
            this.pnlTopScorers = new System.Windows.Forms.Panel();
            this.lblNoScorers = new System.Windows.Forms.Label();
            this.dgvTopScorers = new System.Windows.Forms.DataGridView();
            this.lblTopScorersTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.tbcStatistics.SuspendLayout();
            this.tabStandings.SuspendLayout();
            this.pnlStandings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).BeginInit();
            this.tabTopScorers.SuspendLayout();
            this.pnlTopScorers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopScorers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.tbcStatistics);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1151, 689);
            this.pnlContent.TabIndex = 0;
            // 
            // tbcStatistics
            // 
            this.tbcStatistics.Controls.Add(this.tabStandings);
            this.tbcStatistics.Controls.Add(this.tabTopScorers);
            this.tbcStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.tbcStatistics.Location = new System.Drawing.Point(0, 0);
            this.tbcStatistics.Name = "tbcStatistics";
            this.tbcStatistics.Padding = new System.Drawing.Point(20, 10);
            this.tbcStatistics.SelectedIndex = 0;
            this.tbcStatistics.Size = new System.Drawing.Size(1151, 689);
            this.tbcStatistics.TabIndex = 0;
            // 
            // tabStandings
            // 
            this.tabStandings.BackColor = System.Drawing.Color.White;
            this.tabStandings.Controls.Add(this.pnlStandings);
            this.tabStandings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabStandings.Location = new System.Drawing.Point(4, 43);
            this.tabStandings.Name = "tabStandings";
            this.tabStandings.Padding = new System.Windows.Forms.Padding(20);
            this.tabStandings.Size = new System.Drawing.Size(1143, 642);
            this.tabStandings.TabIndex = 0;
            this.tabStandings.Text = "Tabla de Posiciones";
            // 
            // pnlStandings
            // 
            this.pnlStandings.BackColor = System.Drawing.Color.White;
            this.pnlStandings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStandings.Controls.Add(this.dgvStandings);
            this.pnlStandings.Controls.Add(this.lblStandingsTitle);
            this.pnlStandings.Location = new System.Drawing.Point(20, 70);
            this.pnlStandings.Name = "pnlStandings";
            this.pnlStandings.Size = new System.Drawing.Size(1103, 553);
            this.pnlStandings.TabIndex = 0;
            // 
            // dgvStandings
            // 
            this.dgvStandings.AllowUserToAddRows = false;
            this.dgvStandings.AllowUserToDeleteRows = false;
            this.dgvStandings.AllowUserToResizeRows = false;
            this.dgvStandings.BackgroundColor = System.Drawing.Color.White;
            this.dgvStandings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStandings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStandings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStandings.ColumnHeadersHeight = 40;
            this.dgvStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStandings.EnableHeadersVisualStyles = false;
            this.dgvStandings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvStandings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvStandings.Location = new System.Drawing.Point(20, 60);
            this.dgvStandings.MultiSelect = false;
            this.dgvStandings.Name = "dgvStandings";
            this.dgvStandings.ReadOnly = true;
            this.dgvStandings.RowHeadersVisible = false;
            this.dgvStandings.RowHeadersWidth = 51;
            this.dgvStandings.RowTemplate.Height = 35;
            this.dgvStandings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStandings.Size = new System.Drawing.Size(1063, 473);
            this.dgvStandings.TabIndex = 1;
            // 
            // lblStandingsTitle
            // 
            this.lblStandingsTitle.AutoSize = true;
            this.lblStandingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblStandingsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblStandingsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStandingsTitle.Name = "lblStandingsTitle";
            this.lblStandingsTitle.Size = new System.Drawing.Size(208, 25);
            this.lblStandingsTitle.TabIndex = 0;
            this.lblStandingsTitle.Text = "Tabla de Posiciones";
            // 
            // tabTopScorers
            // 
            this.tabTopScorers.BackColor = System.Drawing.Color.White;
            this.tabTopScorers.Controls.Add(this.pnlTopScorers);
            this.tabTopScorers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tabTopScorers.Location = new System.Drawing.Point(4, 43);
            this.tabTopScorers.Name = "tabTopScorers";
            this.tabTopScorers.Padding = new System.Windows.Forms.Padding(20);
            this.tabTopScorers.Size = new System.Drawing.Size(1143, 642);
            this.tabTopScorers.TabIndex = 1;
            this.tabTopScorers.Text = "Máximos Goleadores";
            // 
            // pnlTopScorers
            // 
            this.pnlTopScorers.BackColor = System.Drawing.Color.White;
            this.pnlTopScorers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopScorers.Controls.Add(this.lblNoScorers);
            this.pnlTopScorers.Controls.Add(this.dgvTopScorers);
            this.pnlTopScorers.Controls.Add(this.lblTopScorersTitle);
            this.pnlTopScorers.Location = new System.Drawing.Point(20, 20);
            this.pnlTopScorers.Name = "pnlTopScorers";
            this.pnlTopScorers.Size = new System.Drawing.Size(1103, 603);
            this.pnlTopScorers.TabIndex = 0;
            // 
            // lblNoScorers
            // 
            this.lblNoScorers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNoScorers.ForeColor = System.Drawing.Color.Gray;
            this.lblNoScorers.Location = new System.Drawing.Point(20, 300);
            this.lblNoScorers.Name = "lblNoScorers";
            this.lblNoScorers.Size = new System.Drawing.Size(1063, 30);
            this.lblNoScorers.TabIndex = 2;
            this.lblNoScorers.Text = "No hay goleadores registrados en este torneo.";
            this.lblNoScorers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoScorers.Visible = false;
            // 
            // dgvTopScorers
            // 
            this.dgvTopScorers.AllowUserToAddRows = false;
            this.dgvTopScorers.AllowUserToDeleteRows = false;
            this.dgvTopScorers.AllowUserToResizeRows = false;
            this.dgvTopScorers.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopScorers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopScorers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopScorers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopScorers.ColumnHeadersHeight = 40;
            this.dgvTopScorers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTopScorers.EnableHeadersVisualStyles = false;
            this.dgvTopScorers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvTopScorers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.dgvTopScorers.Location = new System.Drawing.Point(20, 60);
            this.dgvTopScorers.MultiSelect = false;
            this.dgvTopScorers.Name = "dgvTopScorers";
            this.dgvTopScorers.ReadOnly = true;
            this.dgvTopScorers.RowHeadersVisible = false;
            this.dgvTopScorers.RowHeadersWidth = 51;
            this.dgvTopScorers.RowTemplate.Height = 35;
            this.dgvTopScorers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopScorers.Size = new System.Drawing.Size(1063, 523);
            this.dgvTopScorers.TabIndex = 1;
            // 
            // lblTopScorersTitle
            // 
            this.lblTopScorersTitle.AutoSize = true;
            this.lblTopScorersTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTopScorersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTopScorersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTopScorersTitle.Name = "lblTopScorersTitle";
            this.lblTopScorersTitle.Size = new System.Drawing.Size(215, 25);
            this.lblTopScorersTitle.TabIndex = 0;
            this.lblTopScorersTitle.Text = "Máximos Goleadores";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1151, 689);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsForm";
            this.Text = "Estadísticas";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.tbcStatistics.ResumeLayout(false);
            this.tabStandings.ResumeLayout(false);
            this.pnlStandings.ResumeLayout(false);
            this.pnlStandings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStandings)).EndInit();
            this.tabTopScorers.ResumeLayout(false);
            this.pnlTopScorers.ResumeLayout(false);
            this.pnlTopScorers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopScorers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TabControl tbcStatistics;
        private System.Windows.Forms.TabPage tabStandings;
        private System.Windows.Forms.TabPage tabTopScorers;
        private System.Windows.Forms.Panel pnlStandings;
        private System.Windows.Forms.DataGridView dgvStandings;
        private System.Windows.Forms.Label lblStandingsTitle;
        private System.Windows.Forms.Panel pnlTopScorers;
        private System.Windows.Forms.DataGridView dgvTopScorers;
        private System.Windows.Forms.Label lblTopScorersTitle;
        private System.Windows.Forms.Label lblNoScorers;
    }
}