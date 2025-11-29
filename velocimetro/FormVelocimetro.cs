using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace velocimetro
{
    public partial class FormVelocimetro : Form
    {
        private cVelocimetro velocimetro;
        private double velocidadActual = 60; // Velocidad de prueba

        public FormVelocimetro()
        {
            InitializeComponent();

            // Configurar el panel
            panelCanvas.Paint += PanelCanvas_Paint;

            // Crear instancia del velocímetro
            // Centro: mitad del panel, Radio: proporcional al tamaño
            int centroX = panelCanvas.Width / 2;
            int centroY = panelCanvas.Height / 2;
            int radio = Math.Min(panelCanvas.Width, panelCanvas.Height) / 2 - 20;
            
            velocimetro = new cVelocimetro(centroX, centroY, radio);

            // Actualizar label digital
            lblDigital.Text = velocidadActual.ToString("0") + " km/h";
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar el velocímetro
            velocimetro.Dibujar(e.Graphics, velocidadActual);
        }
    }
}