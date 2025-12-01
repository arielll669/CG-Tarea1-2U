namespace velocimetro
{
    partial class FormVelocimetro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.lblDigital = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCarretera = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.panelCanvas.Location = new System.Drawing.Point(142, 232);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(711, 359);
            this.panelCanvas.TabIndex = 0;
            // 
            // lblDigital
            // 
            this.lblDigital.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDigital.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigital.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDigital.Location = new System.Drawing.Point(414, 604);
            this.lblDigital.Name = "lblDigital";
            this.lblDigital.Size = new System.Drawing.Size(174, 57);
            this.lblDigital.TabIndex = 1;
            this.lblDigital.Text = "label1";
            this.lblDigital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 93);
            this.label1.TabIndex = 2;
            this.label1.Text = "Velocímetro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCarretera
            // 
            this.panelCarretera.Location = new System.Drawing.Point(938, 189);
            this.panelCarretera.Name = "panelCarretera";
            this.panelCarretera.Size = new System.Drawing.Size(816, 505);
            this.panelCarretera.TabIndex = 3;
            this.panelCarretera.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCarretera_Paint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1135, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 93);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pista";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormVelocimetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1885, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelCarretera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDigital);
            this.Controls.Add(this.panelCanvas);
            this.Name = "FormVelocimetro";
            this.Text = "Simulación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblDigital;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCarretera;
        private System.Windows.Forms.Label label2;
    }
}

