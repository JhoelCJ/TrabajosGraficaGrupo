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
        public abstract void Dibujar(Graphics g, int ancho, int alto);
        public abstract double Area();
        public abstract double Perimetro();
    }
}
