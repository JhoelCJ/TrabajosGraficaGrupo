using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFiguras
{
    public class Heart : Figura
    {
        double size;

        public Heart(double size)
        {
            this.size = size;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = ancho / 2 + tx;
            int cy = alto / 2 + ty;

            double max = Math.Min(ancho, alto) * 0.4;

            double escalaPanel = 1.0;

            if (size > max)
            {
                escalaPanel = max / size;
            }

            int s = (int)(size * escalaPanel);

            s = (int)(s * this.escala);

            int r = s / 2;

            g.TranslateTransform(cx, cy);

            g.RotateTransform((float)angulo);

            int offset = (int)(r * 0.5);

            g.FillEllipse(Brushes.Red, -offset - r / 2, -r / 2, r, r);

            g.FillEllipse(Brushes.Red, offset - r / 2, -r / 2, r, r);

            Point[] puntos =
            {
                new Point(-r, 0),
                new Point(r, 0),
                new Point(0, s)
            };

            g.FillPolygon(Brushes.Red, puntos);

            g.ResetTransform();
        }

        public override double Area()
        {
            return size * size * 0.8;
        }

        public override double Perimetro()
        {
            return size * 3;
        }
    }
}
