using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFiguras
{
    public class Pie : Figura
    {
        double radio;

        public Pie(double radio)
        {
            this.radio = radio;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2 + tx;
            int cy = alto / 2 + ty;

            double max = Math.Min(ancho, alto) * 0.4;

            double escalaPanel = 1.0;

            if (radio > max)
            {
                escalaPanel = max / radio;
            }

            int r = (int)(radio * escalaPanel);

            r = (int)(r * this.escala);

            g.FillPie(
                Brushes.Purple,
                cx - r / 2,
                cy - r / 2,
                r,
                r,
                (float)angulo,
                270
            );
        }

        public override double Area()
        {
            return Math.PI * radio * radio * (270.0 / 360.0);
        }

        public override double Perimetro()
        {
            return 2 * Math.PI * radio * (270.0 / 360.0);
        }
    }
}
