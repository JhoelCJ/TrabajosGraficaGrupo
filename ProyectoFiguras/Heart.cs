using System;
using System.Collections.Generic;
using System.Drawing;
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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;

            double realW = size;
            double realH = size * 1.5;

            double maxW = ancho * 0.8;
            double maxH = alto * 0.8;

            double escala = 1.0;

            if (realW > maxW || realH > maxH)
                escala = Math.Min(maxW / realW, maxH / realH);

            int s = (int)(size * escala);
            int r = s / 2;

            int totalH = s + r / 2;

            int cy = (alto - totalH) / 2;

            int offset = (int)(r * 0.5);

            g.FillEllipse(Brushes.Red, cx - offset - r / 2, cy, r, r);
            g.FillEllipse(Brushes.Red, cx + offset - r / 2, cy, r, r);

            Point[] puntos = {
                new Point(cx - r, cy + r/2),
                new Point(cx + r, cy + r/2),
                new Point(cx, cy + s)
            };

            g.FillPolygon(Brushes.Red, puntos);
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
