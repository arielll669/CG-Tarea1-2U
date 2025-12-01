using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace velocimetro
{
    public class cCarretera
    {
        private int ancho;
        private int alto;
        private float offsetLineas;
        private const float ESPACIADO_LINEAS = 40f;
        private const int NUM_CARRILES = 3;

        public cCarretera(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            this.offsetLineas = 0;
        }

        public void Actualizar(float velocidad)
        {

            float factorMovimiento = velocidad * 0.12f;
            offsetLineas += factorMovimiento;

            offsetLineas = offsetLineas % ESPACIADO_LINEAS;
        }

        public void Dibujar(Graphics g, float velocidad)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Actualizar(velocidad);

            using (SolidBrush brushPasto = new SolidBrush(Color.FromArgb(34, 139, 34)))
            {
                g.FillRectangle(brushPasto, 0, 0, ancho, alto);
            }

            // Calcular dimensiones de la carretera
            int anchoCarretera = (int)(ancho * 0.6f);
            int xCarretera = (ancho - anchoCarretera) / 2;

            // Dibujar asfalto
            using (SolidBrush brushAsfalto = new SolidBrush(Color.FromArgb(50, 50, 50)))
            {
                g.FillRectangle(brushAsfalto, xCarretera, 0, anchoCarretera, alto);
            }

            // Dibujar bordes de la carretera
            using (Pen penBorde = new Pen(Color.White, 4))
            {
                g.DrawLine(penBorde, xCarretera, 0, xCarretera, alto);
                g.DrawLine(penBorde, xCarretera + anchoCarretera, 0, xCarretera + anchoCarretera, alto);
            }

            // Dibujar líneas divisorias de carriles
            using (Pen penLinea = new Pen(Color.Yellow, 3))
            {
                int anchoCarril = anchoCarretera / NUM_CARRILES;

                for (int carril = 1; carril < NUM_CARRILES; carril++)
                {
                    int xLinea = xCarretera + (carril * anchoCarril);

                    for (float y = -ESPACIADO_LINEAS * 2 + offsetLineas; y < alto + ESPACIADO_LINEAS; y += ESPACIADO_LINEAS)
                    {
                        g.DrawLine(penLinea, xLinea, y, xLinea, y + 20);
                    }
                }
            }

            // Dibujar el auto en el centro-abajo
            DibujarAuto(g, ancho / 2, alto - 80);
        }

        private void DibujarAuto(Graphics g, int x, int y)
        {
            int anchoAuto = 40;
            int altoAuto = 60;

            // Sombra del auto
            using (SolidBrush brushSombra = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
            {
                g.FillEllipse(brushSombra, x - anchoAuto / 2 + 2, y + altoAuto - 5, anchoAuto - 4, 10);
            }

            // Cuerpo del auto
            using (SolidBrush brushAuto = new SolidBrush(Color.FromArgb(220, 20, 20)))
            {
                Rectangle rectAuto = new Rectangle(x - anchoAuto / 2, y, anchoAuto, altoAuto);
                g.FillRectangle(brushAuto, rectAuto);
            }

            // Parabrisas
            using (SolidBrush brushVidrio = new SolidBrush(Color.FromArgb(100, 150, 200)))
            {
                Point[] parabrisas = {
                    new Point(x - anchoAuto / 2 + 5, y + 10),
                    new Point(x + anchoAuto / 2 - 5, y + 10),
                    new Point(x + anchoAuto / 2 - 8, y + 25),
                    new Point(x - anchoAuto / 2 + 8, y + 25)
                };
                g.FillPolygon(brushVidrio, parabrisas);
            }

            // Ruedas
            using (SolidBrush brushRueda = new SolidBrush(Color.Black))
            {
                // Rueda izquierda delantera
                g.FillRectangle(brushRueda, x - anchoAuto / 2 - 3, y + 10, 6, 12);
                // Rueda derecha delantera
                g.FillRectangle(brushRueda, x + anchoAuto / 2 - 3, y + 10, 6, 12);
                // Rueda izquierda trasera
                g.FillRectangle(brushRueda, x - anchoAuto / 2 - 3, y + altoAuto - 22, 6, 12);
                // Rueda derecha trasera
                g.FillRectangle(brushRueda, x + anchoAuto / 2 - 3, y + altoAuto - 22, 6, 12);
            }

            // Detalles (faros)
            using (SolidBrush brushFaro = new SolidBrush(Color.Yellow))
            {
                g.FillEllipse(brushFaro, x - anchoAuto / 2 + 8, y + 3, 6, 6);
                g.FillEllipse(brushFaro, x + anchoAuto / 2 - 14, y + 3, 6, 6);
            }
        }
    }
}