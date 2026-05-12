using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProyectoFiguras
{
    public abstract class Figura
    {
        public int tx = 0;
        public int ty = 0;

        public double escala = 1;

        public double angulo = 0;

        public abstract void Dibujar(Graphics g, int ancho, int alto);
        public abstract double Area();
        public abstract double Perimetro();
    }
}
