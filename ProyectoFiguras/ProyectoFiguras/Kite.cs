using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectoFiguras
{
    public class Kite : Figura
    {
        double d1, d2;

        public Kite(double d1, double d2)
        {
            this.d1 = d1;
            this.d2 = d2;
        }

        public override void Dibujar(Graphics g, int ancho, int alto)
        {
            g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int cx = ancho / 2;
            int cy = alto / 2;

            double realW = d2;
            double realH = d1 * 1.5;

            double maxW = ancho * 0.8;
            double maxH = alto * 0.8;

            double escalaPanel = 1.0;

            if (realW > maxW || realH > maxH)
            {
                escalaPanel = Math.Min(
                    maxW / realW,
                    maxH / realH
                );
            }

            int D1 = (int)(d1 * escalaPanel);
            int D2 = (int)(d2 * escalaPanel);

            int arriba = D1 / 3;
            int abajo = D1;

            Point[] puntos = new Point[]
            {
                new Point(0, -arriba),
                new Point(D2/2, 0),
                new Point(0, abajo),
                new Point(-D2/2, 0)
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

            g.FillPolygon(Brushes.Blue, puntos);
        }


        public override double Area()
        {
            return (d1 * d2) / 2;
        }

        public override double Perimetro()
        {
            double lado1 = Math.Sqrt(Math.Pow(d1, 2) + Math.Pow(d2 / 2, 2));
            double lado2 = Math.Sqrt(Math.Pow(d1 / 2, 2) + Math.Pow(d2 / 2, 2));
            return 2 * (lado1 + lado2);
        }
    }
}
