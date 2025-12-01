using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace velocimetro
{
    public class cMotorVelocidad
    {
        // Propiedades
        private double velocidadActual;
        private bool acelerando;
        private bool frenando;

        // Constantes de física del motor
        private const double ACELERACION = 2.0;
        private const double DESACELERACION = 3.0;
        private const double FRICCION = 0.5;
        private const double VELOCIDAD_MINIMA = 0;
        private const double VELOCIDAD_MAXIMA = 180;

        // Constructor
        public cMotorVelocidad()
        {
            velocidadActual = 0;
            acelerando = false;
            frenando = false;
        }

        // Propiedades públicas
        public double VelocidadActual
        {
            get { return velocidadActual; }
        }

        // Métodos para controlar el motor
        public void Acelerar()
        {
            acelerando = true;
        }

        public void DejarDeAcelerar()
        {
            acelerando = false;
        }

        public void Frenar()
        {
            frenando = true;
        }

        public void DejarDeFrenar()
        {
            frenando = false;
        }

        // Actualizar el estado del motor (llamar en cada tick del timer)
        public void Actualizar()
        {
            if (acelerando)
            {
                // Acelerar
                velocidadActual += ACELERACION;
            }
            else if (frenando)
            {
                // Frenar activamente
                velocidadActual -= DESACELERACION;
            }
            else
            {
                // Fricción natural (desaceleración pasiva)
                if (velocidadActual > 0)
                {
                    velocidadActual -= FRICCION;
                }
            }

            // Aplicar límites
            if (velocidadActual < VELOCIDAD_MINIMA)
                velocidadActual = VELOCIDAD_MINIMA;

            if (velocidadActual > VELOCIDAD_MAXIMA)
                velocidadActual = VELOCIDAD_MAXIMA;
        }

        // Reiniciar el motor
        public void Reiniciar()
        {
            velocidadActual = 0;
            acelerando = false;
            frenando = false;
        }
    }
}