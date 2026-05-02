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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            double realW = radio;
            double realH = radio;

            double maxW = ancho * 0.8;
            double maxH = alto * 0.8;

            double escala = 1.0;

            if (realW > maxW || realH > maxH)
            {
                escala = Math.Min(maxW / realW, maxH / realH);
            }

            int d = (int)(radio * escala);

            g.FillPie(Brushes.Purple,
                cx - d / 2,
                cy - d / 2,
                d,
                d,
                0,
                270);
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
