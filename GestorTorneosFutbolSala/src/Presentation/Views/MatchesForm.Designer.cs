namespace GestorTorneosFutbolSala.src.Presentation.Views
{
    partial class MatchesForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos manejados.
        /// </summary>
        /// <param name="disposing">true si se deben liberar recursos gestionados; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para el diseñador.
        /// No modifiques el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPhases = new System.Windows.Forms.TabControl();
            this.tabFirstPhase = new System.Windows.Forms.TabPage();
            this.pnlFirstPhase = new System.Windows.Forms.Panel();
            this.tabSemifinals = new System.Windows.Forms.TabPage();
            this.pnlSemifinals = new System.Windows.Forms.Panel();
            this.tabFinal = new System.Windows.Forms.TabPage();
            this.pnlFinal = new System.Windows.Forms.Panel();
            this.tabPhases.SuspendLayout();
            this.tabFirstPhase.SuspendLayout();
            this.tabSemifinals.SuspendLayout();
            this.tabFinal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPhases
            // 
            this.tabPhases.Controls.Add(this.tabFirstPhase);
            this.tabPhases.Controls.Add(this.tabSemifinals);
            this.tabPhases.Controls.Add(this.tabFinal);
            this.tabPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPhases.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabPhases.Location = new System.Drawing.Point(20, 20);
            this.tabPhases.Name = "tabPhases";
            this.tabPhases.SelectedIndex = 0;
            this.tabPhases.Size = new System.Drawing.Size(1111, 649);
            this.tabPhases.TabIndex = 0;
            // 
            // tabFirstPhase
            // 
            this.tabFirstPhase.Controls.Add(this.pnlFirstPhase);
            this.tabFirstPhase.Location = new System.Drawing.Point(4, 28);
            this.tabFirstPhase.Name = "tabFirstPhase";
            this.tabFirstPhase.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirstPhase.Size = new System.Drawing.Size(1103, 617);
            this.tabFirstPhase.TabIndex = 0;
            this.tabFirstPhase.Text = "Primera Fase - Todos contra Todos";
            this.tabFirstPhase.UseVisualStyleBackColor = true;
            // 
            // pnlFirstPhase
            // 
            this.pnlFirstPhase.AutoScroll = true;
            this.pnlFirstPhase.BackColor = System.Drawing.Color.White;
            this.pnlFirstPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirstPhase.Location = new System.Drawing.Point(3, 3);
            this.pnlFirstPhase.Name = "pnlFirstPhase";
            this.pnlFirstPhase.Size = new System.Drawing.Size(1097, 611);
            this.pnlFirstPhase.TabIndex = 0;
            // 
            // tabSemifinals
            // 
            this.tabSemifinals.Controls.Add(this.pnlSemifinals);
            this.tabSemifinals.Location = new System.Drawing.Point(4, 28);
            this.tabSemifinals.Name = "tabSemifinals";
            this.tabSemifinals.Padding = new System.Windows.Forms.Padding(3);
            this.tabSemifinals.Size = new System.Drawing.Size(1103, 617);
            this.tabSemifinals.TabIndex = 1;
            this.tabSemifinals.Text = "Segunda Fase - Semifinales";
            this.tabSemifinals.UseVisualStyleBackColor = true;
            // 
            // pnlSemifinals
            // 
            this.pnlSemifinals.AutoScroll = true;
            this.pnlSemifinals.BackColor = System.Drawing.Color.White;
            this.pnlSemifinals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSemifinals.Location = new System.Drawing.Point(3, 3);
            this.pnlSemifinals.Name = "pnlSemifinals";
            this.pnlSemifinals.Size = new System.Drawing.Size(1097, 611);
            this.pnlSemifinals.TabIndex = 0;
            // 
            // tabFinal
            // 
            this.tabFinal.Controls.Add(this.pnlFinal);
            this.tabFinal.Location = new System.Drawing.Point(4, 28);
            this.tabFinal.Name = "tabFinal";
            this.tabFinal.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinal.Size = new System.Drawing.Size(1103, 617);
            this.tabFinal.TabIndex = 2;
            this.tabFinal.Text = "Tercera Fase - Final";
            this.tabFinal.UseVisualStyleBackColor = true;
            // 
            // pnlFinal
            // 
            this.pnlFinal.AutoScroll = true;
            this.pnlFinal.BackColor = System.Drawing.Color.White;
            this.pnlFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFinal.Location = new System.Drawing.Point(3, 3);
            this.pnlFinal.Name = "pnlFinal";
            this.pnlFinal.Size = new System.Drawing.Size(1097, 611);
            this.pnlFinal.TabIndex = 0;
            // 
            // MatchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1167, 728);
            this.Controls.Add(this.tabPhases);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MatchesForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de Torneos - Partidos";
            this.tabPhases.ResumeLayout(false);
            this.tabFirstPhase.ResumeLayout(false);
            this.tabSemifinals.ResumeLayout(false);
            this.tabFinal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Declaraciones de los controles
        private System.Windows.Forms.TabControl tabPhases;
        private System.Windows.Forms.TabPage tabFirstPhase;
        private System.Windows.Forms.Panel pnlFirstPhase;
        private System.Windows.Forms.TabPage tabSemifinals;
        private System.Windows.Forms.Panel pnlSemifinals;
        private System.Windows.Forms.TabPage tabFinal;
        private System.Windows.Forms.Panel pnlFinal;
    }
}