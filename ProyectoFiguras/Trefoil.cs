using System;
using System.Drawing;

namespace ProyectoFiguras
{
    public class Trefoil : Figura
    {
        private readonly double size;

        public Trefoil(double size)
        {
            this.size = size;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            // Escala simple basándonos en el tamaño deseado.
            double real = Math.Max(1.0, size);
            double max = Math.Min(ancho, alto) * 0.8;
            double escala = real > max ? (max / real) : 1.0;

            int r = (int)(real * escala / 3.0);
            if (r < 5) r = 5;

            // Tres círculos: uno arriba y dos abajo, con solape tipo trébol.
            int offsetX = (int)(r * 0.95);
            int offsetY = (int)(r * 0.55);

            var brush = new SolidBrush(Color.YellowGreen);
            try
            {
                // Arriba
                g.FillEllipse(brush, cx - r, cy - r - offsetY, 2 * r, 2 * r);
                // Abajo izquierda
                g.FillEllipse(brush, cx - r - offsetX, cy - r + offsetY, 2 * r, 2 * r);
                // Abajo derecha
                g.FillEllipse(brush, cx - r + offsetX, cy - r + offsetY, 2 * r, 2 * r);
            }
            finally
            {
                brush.Dispose();
            }
        }

        public override double Area()
        {
            // Aproximación: área de 3 círculos (sin descontar solapes).
            double r = Math.Max(1.0, size) / 3.0;
            return 3.0 * Math.PI * r * r;
        }

        public override double Perimetro()
        {
            // Aproximación: perímetro de 3 circunferencias (sin descontar solapes).
            double r = Math.Max(1.0, size) / 3.0;
            return 3.0 * (2.0 * Math.PI * r);
        }
    }
}
