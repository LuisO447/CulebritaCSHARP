using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake3
{
    public partial class Form1 : Form
    {
        Cola cabeza;
        Comida comida;
        int puntaje = 0;
        Graphics g;
        int xdir = 0, ydir = 0;
        int cuadro = 15;
        Boolean ejex = true, ejey = true;
        public Form1()
        {
            InitializeComponent();
            cabeza = new Cola(20, 20);
            comida = new Comida();
            g = canvas.CreateGraphics();
        }

        public void movimiento()
        {
            cabeza.setxy(cabeza.verX() + xdir, cabeza.verY() + ydir);
        }
        private void bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.DarkGreen);//color de fondo
            cabeza.dibujar(g);
            comida.dibujar(g);
            movimiento();
            choquePared();//coliciones con el borde
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();//subiendo el puntaje de 1 en 1
                Console.Beep();//emitir sonido cuando la culebra se coma la fruta
                puntaje++;
                //Console.Beep();
                puntos.Text = puntaje.ToString(); //el numero del puntaje se pasa a string
            }
        }

        public void choquePared() //paredes o coliciones
        {
            if(cabeza.verX() < 0 || cabeza.verX() > 990 || cabeza.verY() < 0 || cabeza.verY() > 480)
            {
                findejuego();
            }
        }

        private void puntos_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void findejuego()
        {
            puntaje = 0;
            puntos.Text = "0"; //se regresa la puntuacion a 0.0
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new Cola(15, 15);
            comida = new Comida();
            MessageBox.Show("Fin del Juego");
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {//para las teclas de direccion o flechas
                if(e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if(e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if(e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if(e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
            }
        }
    }
}
