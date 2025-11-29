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

            // Crear instancia del velocímetro
            int centroX = panelCanvas.Width / 2;
            int centroY = panelCanvas.Height / 2;
            int radio = Math.Min(panelCanvas.Width, panelCanvas.Height) / 2 - 20;

            velocimetro = new cVelocimetro(centroX, centroY, radio);

            // Crear instancia del motor
            motor = new cMotorVelocidad();

            // Configurar timer para actualizar el motor
            timer = new Timer();
            timer.Interval = 50; // 50ms = 20 veces por segundo
            timer.Tick += Timer_Tick;
            timer.Start();

            // Actualizar label digital inicial
            ActualizarLabelDigital();

            // Habilitar eventos de teclado
            this.KeyDown += FormVelocimetro_KeyDown;
            this.KeyUp += FormVelocimetro_KeyUp;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar física del motor
            motor.Actualizar();

            // Actualizar label digital
            ActualizarLabelDigital();

            // Repintar el panel (esto llama a PanelCanvas_Paint)
            panelCanvas.Invalidate();
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar el velocímetro con la velocidad actual del motor
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
    }
}