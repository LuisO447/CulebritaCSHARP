using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake3
{
    class Comida : objeto
    {
        public Comida()
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public void dibujar(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.ancho, this.ancho);//era yellow para la fruta
        }
        public void colocar() //generar fruta al azar en una posicion de los ejes x y y
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public int generar(int n) //se genera la fruta en si
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}
