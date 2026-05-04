using System;
using System.Drawing;

namespace ProyectoFiguras
{
    public class Crescent : Figura
    {
        private readonly double diametro;

        public Crescent(double diametro)
        {
            this.diametro = diametro;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            double real = Math.Max(1.0, diametro);
            double max = Math.Min(ancho, alto) * 0.8;

            double escala = real > max ? (max / real) : 1.0;
            int d = (int)(real * escala);
            if (d < 10) d = 10;

            // Creciente: círculo grande menos círculo pequeño.
            // Se construye con dos figuras compuestas: región = outerEllipse - innerEllipse.
            var outerRect = new Rectangle(cx - d / 2, cy - d / 2, d, d);

            // El círculo interior se desplaza hacia arriba para lograr el recorte superior.
            // Para parecerse a la imagen, usamos un diámetro más pequeño y lo desplazamos.
            int innerD = (int)(d * 0.70); // Circunferencia más pequeña
            int dy = (int)(d * 0.20); // Desplazamiento hacia arriba ajustado
            var innerRect = new Rectangle(cx - innerD / 2, cy - innerD / 2 - dy, innerD, innerD);

            using (var outerPath = new System.Drawing.Drawing2D.GraphicsPath())
            using (var innerPath = new System.Drawing.Drawing2D.GraphicsPath())
            using (var region = new Region())
            using (var brush = new SolidBrush(Color.Orange))
            {
                outerPath.AddEllipse(outerRect);
                innerPath.AddEllipse(innerRect);

                // Importante: crear región desde la elipse (no desde el rectángulo), para evitar que “pinte el cuadrado”.
                region.MakeEmpty();
                region.Union(outerPath);
                region.Exclude(innerPath);

                g.FillRegion(brush, region);
            }
        }

        public override double Area()
        {
            // Aproximación: área círculo grande - área círculo pequeño.
            double d = Math.Max(1.0, diametro);
            double r = d / 2.0;
            double r2 = (d * 0.75) / 2.0;
            return Math.PI * r * r - Math.PI * r2 * r2;
        }

        public override double Perimetro()
        {
            // Aproximación: suma de circunferencias (no exacto por intersección).
            double d = Math.Max(1.0, diametro);
            double r = d / 2.0;
            double r2 = (d * 0.75) / 2.0;
            return 2.0 * Math.PI * r + 2.0 * Math.PI * r2;
        }
    }
}
