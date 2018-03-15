using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dados
{
    public partial class Form1 : Form
    {
        public class Dado
        {
            private int _caraActual;
            public int CaraActual { get { return _caraActual; } }
            private static Random aleatorio;

            public Dado()
            {
                _caraActual = 1;
                aleatorio = new Random();
            }

            public void lanzar()
            {
                _caraActual = aleatorio.Next(1, 7);
            }
        }

        public Dado dado;
        public Dado dado2;

        public Form1()
        {
            InitializeComponent();
            dado2 = new Dado();
            dado = new Dado();
        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            dado.lanzar();
            txtLanzamientos.Text += dado.CaraActual + "\n";
        }

        private void btnLanzar100_Click(object sender, EventArgs e)
        {
            txtLanzamientos.Text = "";
            int[] apariciones = new int[6];

            for(int i = 0; i < 100; i++)
            {
                dado.lanzar();
                apariciones[dado.CaraActual - 1]++;
            }

            for(int i = 0; i < 6; i++)
            {
                txtLanzamientos.Text += "La cara " + (i + 1) + " apareció: " + apariciones[i] + " veces\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLanzamientos.Text = "";
            int[] apariciones = new int[11];

            for (int i = 0; i < 100; i++)
            {
                int suma = 0;
                dado2.lanzar();
                suma += dado2.CaraActual;

                dado.lanzar();
                suma += dado.CaraActual;

                apariciones[suma - 2]++;
            }

            for (int i = 0; i < 11; i++)
            {
                txtLanzamientos.Text += "La suma " + (i + 2) + " apareció: " + apariciones[i] + " veces\n";
            }
        }
    }
}
