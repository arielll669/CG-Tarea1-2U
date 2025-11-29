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
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.panelCanvas.Location = new System.Drawing.Point(136, 91);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(711, 359);
            this.panelCanvas.TabIndex = 0;
            // 
            // lblDigital
            // 
            this.lblDigital.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDigital.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDigital.Location = new System.Drawing.Point(384, 463);
            this.lblDigital.Name = "lblDigital";
            this.lblDigital.Size = new System.Drawing.Size(174, 57);
            this.lblDigital.TabIndex = 1;
            this.lblDigital.Text = "label1";
            this.lblDigital.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormVelocimetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1002, 670);
            this.Controls.Add(this.lblDigital);
            this.Controls.Add(this.panelCanvas);
            this.Name = "FormVelocimetro";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Label lblDigital;
    }
}

