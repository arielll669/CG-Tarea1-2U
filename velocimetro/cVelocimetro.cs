using System;
using System.Drawing;

namespace velocimetro
{
    public class cVelocimetro
    {
        private int centroX;
        private int centroY;
        private int radio;

        public cVelocimetro(int centroX, int centroY, int radio)
        {
            this.centroX = centroX;
            this.centroY = centroY;
            this.radio = radio;
        }

        public void Dibujar(Graphics g, double velocidad)
        {
            // Configurar calidad de gráficos
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // 1. Dibujar círculo principal
            DibujarCirculoPrincipal(g);
            // 2. Dibujar marcas secundarias (cada 10 km/h)
            DibujarMarcasSecundarias(g);
            // 3. Dibujar marcas principales (cada 20 km/h)
            DibujarMarcasPrincipales(g);
            // 4. Dibujar números
            DibujarNumeros(g);
            // 5. Dibujar aguja
            DibujarAguja(g, velocidad);
        }

        private void DibujarCirculoPrincipal(Graphics g)
        {
            Pen lapiz = new Pen(Color.Black, 3);

            g.DrawEllipse(lapiz,
                centroX - radio,
                centroY - radio,
                radio * 2,
                radio * 2);

            lapiz.Dispose();
        }

        private void DibujarMarcasSecundarias(Graphics g)
        {
            Pen lapizMarca = new Pen(Color.Gray, 1);
            int longitudMarca = 10;

            for (int velocidad = 0; velocidad <= 180; velocidad += 10)
            {
                if (velocidad % 20 == 0)
                    continue;

                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                int x1 = centroX + (int)(radio * Math.Cos(anguloRadianes));
                int y1 = centroY - (int)(radio * Math.Sin(anguloRadianes));

                int x2 = centroX + (int)((radio - longitudMarca) * Math.Cos(anguloRadianes));
                int y2 = centroY - (int)((radio - longitudMarca) * Math.Sin(anguloRadianes));

                g.DrawLine(lapizMarca, x1, y1, x2, y2);
            }

            lapizMarca.Dispose();
        }

        private void DibujarMarcasPrincipales(Graphics g)
        {
            Pen lapizMarca = new Pen(Color.Black, 3);
            int longitudMarca = 20;

            for (int velocidad = 0; velocidad <= 180; velocidad += 20)
            {
                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                int x1 = centroX + (int)(radio * Math.Cos(anguloRadianes));
                int y1 = centroY - (int)(radio * Math.Sin(anguloRadianes));

                int x2 = centroX + (int)((radio - longitudMarca) * Math.Cos(anguloRadianes));
                int y2 = centroY - (int)((radio - longitudMarca) * Math.Sin(anguloRadianes));

                g.DrawLine(lapizMarca, x1, y1, x2, y2);
            }

            lapizMarca.Dispose();
        }

        private void DibujarNumeros(Graphics g)
        {
            Font fuente = new Font("Arial", 12, FontStyle.Bold);
            SolidBrush brocha = new SolidBrush(Color.Black);

            int distanciaNumero = 35;

            for (int velocidad = 0; velocidad <= 180; velocidad += 20)
            {
                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                int xNumero = centroX + (int)((radio - distanciaNumero) * Math.Cos(anguloRadianes));
                int yNumero = centroY - (int)((radio - distanciaNumero) * Math.Sin(anguloRadianes));

                string texto = velocidad.ToString();

                SizeF tamañoTexto = g.MeasureString(texto, fuente);

                float xTexto = xNumero - (tamañoTexto.Width / 2);
                float yTexto = yNumero - (tamañoTexto.Height / 2);

                // Dibujar el número
                g.DrawString(texto, fuente, brocha, xTexto, yTexto);
            }

            fuente.Dispose();
            brocha.Dispose();
        }

        private void DibujarAguja(Graphics g, double velocidad)
        {

            double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
            double anguloRadianes = anguloGrados * Math.PI / 180.0;

            int longitudAguja = (int)(radio * 0.55); // 70% del radio
            int puntoFinalX = centroX + (int)(longitudAguja * Math.Cos(anguloRadianes));
            int puntoFinalY = centroY - (int)(longitudAguja * Math.Sin(anguloRadianes));

            // Dibujar la aguja
            Pen lapizAguja = new Pen(Color.Red, 3);
            g.DrawLine(lapizAguja, centroX, centroY, puntoFinalX, puntoFinalY);

            SolidBrush brocha = new SolidBrush(Color.DarkRed);
            int radioCirculoCentral = 8;
            g.FillEllipse(brocha,
                centroX - radioCirculoCentral,
                centroY - radioCirculoCentral,
                radioCirculoCentral * 2,
                radioCirculoCentral * 2);

            lapizAguja.Dispose();
            brocha.Dispose();
        }
    }
}