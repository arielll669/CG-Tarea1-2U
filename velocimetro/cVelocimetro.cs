using System;
using System.Drawing;

namespace velocimetro
{
    public class cVelocimetro
    {
        // Propiedades del velocímetro
        private int centroX;
        private int centroY;
        private int radio;

        // Constructor
        public cVelocimetro(int centroX, int centroY, int radio)
        {
            this.centroX = centroX;
            this.centroY = centroY;
            this.radio = radio;
        }

        // Método principal de dibujo
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

        // Dibuja el círculo exterior del velocímetro
        private void DibujarCirculoPrincipal(Graphics g)
        {
            Pen lapiz = new Pen(Color.Black, 3);

            // Dibujar círculo
            g.DrawEllipse(lapiz,
                centroX - radio,
                centroY - radio,
                radio * 2,
                radio * 2);

            lapiz.Dispose();
        }

        // Dibuja las marcas secundarias cada 10 km/h
        private void DibujarMarcasSecundarias(Graphics g)
        {
            Pen lapizMarca = new Pen(Color.Gray, 1);
            int longitudMarca = 10; // Más cortas que las principales

            // Recorrer desde 0 hasta 180 km/h cada 10
            for (int velocidad = 0; velocidad <= 180; velocidad += 10)
            {
                // Saltar las que son múltiplos de 20 (esas son principales)
                if (velocidad % 20 == 0)
                    continue;

                // Calcular ángulo para esta velocidad
                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                // Punto exterior (en el borde del círculo)
                int x1 = centroX + (int)(radio * Math.Cos(anguloRadianes));
                int y1 = centroY - (int)(radio * Math.Sin(anguloRadianes));

                // Punto interior (más hacia el centro)
                int x2 = centroX + (int)((radio - longitudMarca) * Math.Cos(anguloRadianes));
                int y2 = centroY - (int)((radio - longitudMarca) * Math.Sin(anguloRadianes));

                // Dibujar la línea de la marca
                g.DrawLine(lapizMarca, x1, y1, x2, y2);
            }

            lapizMarca.Dispose();
        }

        // Dibuja las marcas principales cada 20 km/h
        private void DibujarMarcasPrincipales(Graphics g)
        {
            Pen lapizMarca = new Pen(Color.Black, 3);
            int longitudMarca = 20; // Longitud de la marca hacia adentro

            // Recorrer desde 0 hasta 180 km/h cada 20
            for (int velocidad = 0; velocidad <= 180; velocidad += 20)
            {
                // Calcular ángulo para esta velocidad
                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                // Punto exterior (en el borde del círculo)
                int x1 = centroX + (int)(radio * Math.Cos(anguloRadianes));
                int y1 = centroY - (int)(radio * Math.Sin(anguloRadianes));

                // Punto interior (más hacia el centro)
                int x2 = centroX + (int)((radio - longitudMarca) * Math.Cos(anguloRadianes));
                int y2 = centroY - (int)((radio - longitudMarca) * Math.Sin(anguloRadianes));

                // Dibujar la línea de la marca
                g.DrawLine(lapizMarca, x1, y1, x2, y2);
            }

            lapizMarca.Dispose();
        }

        // Dibuja los números en las marcas principales
        private void DibujarNumeros(Graphics g)
        {
            Font fuente = new Font("Arial", 12, FontStyle.Bold);
            SolidBrush brocha = new SolidBrush(Color.Black);

            int distanciaNumero = 35; // Distancia desde el borde hacia adentro

            // Recorrer desde 0 hasta 180 km/h cada 20
            for (int velocidad = 0; velocidad <= 180; velocidad += 20)
            {
                // Calcular ángulo para esta velocidad
                double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
                double anguloRadianes = anguloGrados * Math.PI / 180.0;

                // Calcular posición del número (más hacia el centro que las marcas)
                int xNumero = centroX + (int)((radio - distanciaNumero) * Math.Cos(anguloRadianes));
                int yNumero = centroY - (int)((radio - distanciaNumero) * Math.Sin(anguloRadianes));

                // Convertir velocidad a string
                string texto = velocidad.ToString();

                // Medir el tamaño del texto para centrarlo
                SizeF tamañoTexto = g.MeasureString(texto, fuente);

                // Ajustar posición para centrar el texto
                float xTexto = xNumero - (tamañoTexto.Width / 2);
                float yTexto = yNumero - (tamañoTexto.Height / 2);

                // Dibujar el número
                g.DrawString(texto, fuente, brocha, xTexto, yTexto);
            }

            fuente.Dispose();
            brocha.Dispose();
        }

        // Dibuja la aguja según la velocidad
        private void DibujarAguja(Graphics g, double velocidad)
        {
            // Calcular ángulo de la aguja
            // 0 km/h = 180° (izquierda), 180 km/h = 0° (derecha)
            double anguloGrados = 180 - (velocidad * 180.0 / 180.0);
            double anguloRadianes = anguloGrados * Math.PI / 180.0;

            // Calcular punto final de la aguja
            int longitudAguja = (int)(radio * 0.55); // 70% del radio
            int puntoFinalX = centroX + (int)(longitudAguja * Math.Cos(anguloRadianes));
            int puntoFinalY = centroY - (int)(longitudAguja * Math.Sin(anguloRadianes));

            // Dibujar la aguja
            Pen lapizAguja = new Pen(Color.Red, 3);
            g.DrawLine(lapizAguja, centroX, centroY, puntoFinalX, puntoFinalY);

            // Dibujar círculo central (perno de la aguja)
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