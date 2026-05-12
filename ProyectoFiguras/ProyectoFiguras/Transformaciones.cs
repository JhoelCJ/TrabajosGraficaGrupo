using System;
using System.Drawing;

namespace ProyectoFiguras
{
    public class Transformaciones
    {
        public static Point Trasladar(Point p, int tx, int ty)
        {
            int x = p.X + tx;
            int y = p.Y + ty;

            return new Point(x, y);
        }

        public static Point Escalar(Point p, double sx, double sy)
        {
            int x = (int)(p.X * sx);
            int y = (int)(p.Y * sy);

            return new Point(x, y);
        }

        public static Point Rotar(Point p, double angulo)
        {
            double rad = angulo * Math.PI / 180.0;

            int x = (int)(p.X * Math.Cos(rad) - p.Y * Math.Sin(rad));

            int y = (int)(p.X * Math.Sin(rad) + p.Y * Math.Cos(rad));

            return new Point(x, y);
        }
    }
}
