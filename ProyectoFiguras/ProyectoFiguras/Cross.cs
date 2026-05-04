using System;
using System.Drawing;

namespace ProyectoFiguras
{
    public class Cross : Figura
    {
        private double ladoCuadradoPequeno;

        public Cross(double ladoCuadradoPequeno)
        {
            this.ladoCuadradoPequeno = ladoCuadradoPequeno;
        }

        public override double Area()
        {
            // El área es 5 veces el área de un cuadrado pequeño.
            return 5 * ladoCuadradoPequeno * ladoCuadradoPequeno;
        }

        public override double Perimetro()
        {
            // El perímetro es 12 veces el lado de un cuadrado pequeño.
            return 12 * ladoCuadradoPequeno;
        }

        public override void Dibujar(Graphics g, int width, int height)
        {
            float centerX = width / 2;
            float centerY = height / 2;
            float smallSide = (float)this.ladoCuadradoPequeno;
            float totalSize = smallSide * 3;

            // La cruz se puede ver como un rectángulo vertical y uno horizontal.
            float rectWidth = smallSide;
            float rectLength = totalSize;

            // Rectángulo vertical
            g.FillRectangle(Brushes.DarkMagenta, centerX - rectWidth / 2, centerY - rectLength / 2, rectWidth, rectLength);

            // Rectángulo horizontal
            g.FillRectangle(Brushes.DarkMagenta, centerX - rectLength / 2, centerY - rectWidth / 2, rectLength, rectWidth);
        }
    }
}
