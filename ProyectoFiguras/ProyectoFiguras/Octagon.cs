using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFiguras
{
    public class Octagon : Figura
    {
        double lado;

        public Octagon(double lado)
        {
            this.lado = lado;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            double max = Math.Min(ancho, alto) * 0.4;

            double escalaPanel = 1.0;

            if (lado > max)
            {
                escalaPanel = max / lado;
            }

            int r = (int)(lado * escalaPanel);

            Point[] puntos = new Point[8];

            for (int i = 0; i < 8; i++)
            {
                double ang =
                    i * Math.PI / 4;

                int x = (int)(r * Math.Cos(ang));
                int y = (int)(r * Math.Sin(ang));

                Point p = new Point(x, y);

                p = Transformaciones.Escalar(
                    p,
                    this.escala,
                    this.escala
                );

                p = Transformaciones.Rotar(
                    p,
                    angulo
                );

                p = Transformaciones.Trasladar(
                    p,
                    cx + tx,
                    cy + ty
                );

                puntos[i] = p;
            }

            g.FillPolygon(Brushes.Orange, puntos);
        }

        public override double Area()
        {
            return 2 * (1 + Math.Sqrt(2)) * lado * lado;
        }

        public override double Perimetro()
        {
            return 8 * lado;
        }
    }
}
