namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class TournamentForm
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
            if (disposing)
            {
                searchTimer?.Dispose();

                if (fontCache != null)
                {
                    foreach (var font in fontCache.Values)
                    {
                        font?.Dispose();
                    }
                    fontCache.Clear();
                }
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
            this.flpGridPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblResultsFound = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYears = new System.Windows.Forms.ComboBox();
            this.cmbGenders = new System.Windows.Forms.ComboBox();
            this.lblAges = new System.Windows.Forms.Label();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.btnCleanFilters = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.flpGridPanel);
            this.pnlContent.Controls.Add(this.lblResultsFound);
            this.pnlContent.Controls.Add(this.pnlSearch);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1440, 689);
            this.pnlContent.TabIndex = 0;
            // 
            // flpGridPanel
            // 
            this.flpGridPanel.Location = new System.Drawing.Point(12, 120);
            this.flpGridPanel.Name = "flpGridPanel";
            this.flpGridPanel.Size = new System.Drawing.Size(1416, 557);
            this.flpGridPanel.TabIndex = 2;
            // 
            // lblResultsFound
            // 
            this.lblResultsFound.AutoSize = true;
            this.lblResultsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultsFound.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblResultsFound.Location = new System.Drawing.Point(34, 82);
            this.lblResultsFound.Name = "lblResultsFound";
            this.lblResultsFound.Size = new System.Drawing.Size(189, 22);
            this.lblResultsFound.TabIndex = 1;
            this.lblResultsFound.Text = "0 torneos encontrados";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblYear);
            this.pnlSearch.Controls.Add(this.cmbYears);
            this.pnlSearch.Controls.Add(this.cmbGenders);
            this.pnlSearch.Controls.Add(this.lblAges);
            this.pnlSearch.Controls.Add(this.cmbAge);
            this.pnlSearch.Controls.Add(this.lblGender);
            this.pnlSearch.Controls.Add(this.btnCleanFilters);
            this.pnlSearch.Location = new System.Drawing.Point(12, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1416, 66);
            this.pnlSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(21, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(303, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(342, 21);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(54, 25);
            this.lblYear.TabIndex = 6;
            this.lblYear.Text = "Año:";
            // 
            // cmbYears
            // 
            this.cmbYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYears.FormattingEnabled = true;
            this.cmbYears.Items.AddRange(new object[] {
            "Todas las edades"});
            this.cmbYears.Location = new System.Drawing.Point(402, 17);
            this.cmbYears.Name = "cmbYears";
            this.cmbYears.Size = new System.Drawing.Size(214, 33);
            this.cmbYears.TabIndex = 2;
            // 
            // cmbGenders
            // 
            this.cmbGenders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGenders.FormattingEnabled = true;
            this.cmbGenders.Items.AddRange(new object[] {
            "Todas las edades"});
            this.cmbGenders.Location = new System.Drawing.Point(724, 17);
            this.cmbGenders.Name = "cmbGenders";
            this.cmbGenders.Size = new System.Drawing.Size(221, 33);
            this.cmbGenders.TabIndex = 3;
            // 
            // lblAges
            // 
            this.lblAges.AutoSize = true;
            this.lblAges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAges.Location = new System.Drawing.Point(962, 23);
            this.lblAges.Name = "lblAges";
            this.lblAges.Size = new System.Drawing.Size(85, 25);
            this.lblAges.TabIndex = 3;
            this.lblAges.Text = "Edades:";
            // 
            // cmbAge
            // 
            this.cmbAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAge.FormattingEnabled = true;
            this.cmbAge.Items.AddRange(new object[] {
            "Todas las edades"});
            this.cmbAge.Location = new System.Drawing.Point(1053, 17);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(196, 33);
            this.cmbAge.TabIndex = 24;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(635, 20);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(83, 25);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "Género:";
            // 
            // btnCleanFilters
            // 
            this.btnCleanFilters.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnCleanFilters.FlatAppearance.BorderSize = 0;
            this.btnCleanFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCleanFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanFilters.ForeColor = System.Drawing.Color.White;
            this.btnCleanFilters.Location = new System.Drawing.Point(1272, 17);
            this.btnCleanFilters.Name = "btnCleanFilters";
            this.btnCleanFilters.Size = new System.Drawing.Size(127, 32);
            this.btnCleanFilters.TabIndex = 5;
            this.btnCleanFilters.Text = "Limpiar";
            this.btnCleanFilters.UseVisualStyleBackColor = false;
            // 
            // TournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1440, 689);
            this.Controls.Add(this.pnlContent);
            this.Name = "TournamentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tournament Manager";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnCleanFilters;
        private System.Windows.Forms.Label lblAges;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYears;
        private System.Windows.Forms.ComboBox cmbGenders;
        private System.Windows.Forms.Label lblResultsFound;
        private System.Windows.Forms.FlowLayoutPanel flpGridPanel;
    }
}