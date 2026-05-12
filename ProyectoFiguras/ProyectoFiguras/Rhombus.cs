using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFiguras
{
    public class Rhombus : Figura
    {
        double D, d;

        public Rhombus(double D, double d)
        {
            this.D = D;
            this.d = d;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            double realW = d;
            double realH = D;

            double maxW = ancho * 0.8;
            double maxH = alto * 0.8;

            double escalaPanel = 1.0;

            if (realW > maxW || realH > maxH)
            {
                escalaPanel = Math.Min(maxW / realW, maxH / realH);
            }

            int DD = (int)(D * escalaPanel);
            int dd = (int)(d * escalaPanel);

            Point[] puntos = new Point[]
            {
                new Point(0, -DD/2),
                new Point(dd/2, 0),
                new Point(0, DD/2),
                new Point(-dd/2, 0)
            };

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i] = Transformaciones.Escalar(
                    puntos[i],
                    this.escala,
                    this.escala
                );

                puntos[i] = Transformaciones.Rotar(
                    puntos[i],
                    angulo
                );

                puntos[i] = Transformaciones.Trasladar(
                    puntos[i],
                    cx + tx,
                    cy + ty
                );
            }

            g.FillPolygon(Brushes.Green, puntos);
        }

        public override double Area()
        {
            return (D * d) / 2;
        }

        public override double Perimetro()
        {
            return 4 * Math.Sqrt(Math.Pow(D / 2, 2) + Math.Pow(d / 2, 2));
        }
    }
}
