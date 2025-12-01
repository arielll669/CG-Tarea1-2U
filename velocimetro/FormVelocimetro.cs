using System;
using System.Drawing;
using System.Windows.Forms;

namespace velocimetro
{
    public partial class FormVelocimetro : Form
    {
        private cVelocimetro velocimetro;
        private cMotorVelocidad motor;
        private Timer timer;
        private cCarretera carretera;

        public FormVelocimetro()
        {
            InitializeComponent();


            // Configurar el panel
            panelCanvas.Paint += PanelCanvas_Paint;

            panelCanvas.GetType().InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null, panelCanvas, new object[] { true });

            // Configurar el panel de carretera
            panelCarretera.Paint += panelCarretera_Paint;
            panelCarretera.GetType().InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelCarretera, new object[] { true });

            carretera = new cCarretera(panelCarretera.Width, panelCarretera.Height);

            int centroX = panelCanvas.Width / 2;
            int centroY = panelCanvas.Height / 2;
            int radio = Math.Min(panelCanvas.Width, panelCanvas.Height) / 2 - 20;

            velocimetro = new cVelocimetro(centroX, centroY, radio);

            motor = new cMotorVelocidad();

            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();

            ActualizarLabelDigital();

            this.KeyDown += FormVelocimetro_KeyDown;
            this.KeyUp += FormVelocimetro_KeyUp;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            motor.Actualizar();

            ActualizarLabelDigital();

            panelCanvas.Invalidate();

            panelCarretera.Invalidate();
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            velocimetro.Dibujar(e.Graphics, motor.VelocidadActual);
        }

        private void FormVelocimetro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                motor.Acelerar();
            }
            else if (e.KeyCode == Keys.Down)
            {
                motor.Frenar();
            }
        }

        private void FormVelocimetro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                motor.DejarDeAcelerar();
            }
            else if (e.KeyCode == Keys.Down)
            {
                motor.DejarDeFrenar();
            }
        }

        private void ActualizarLabelDigital()
        {
            lblDigital.Text = motor.VelocidadActual.ToString("0") + " km/h";
        }

        private void panelCarretera_Paint(object sender, PaintEventArgs e)
        {
            carretera.Dibujar(e.Graphics, (float)motor.VelocidadActual);
        }
    }
}