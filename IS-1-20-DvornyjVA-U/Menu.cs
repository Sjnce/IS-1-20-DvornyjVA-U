using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3;
using Task4;
using Task5;

namespace IS_1_20_DvornyjVA_U
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // открытие 1 задания
        {
            Task1 T1 = new Task1();
            T1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // открытие 2 задания
        {
            Task2 T2 = new Task2();
            T2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) // открытие 3 задания
        {
            Task3x T3 = new Task3x();
            T3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task4z T4 = new Task4z();
            T4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task5c T5 = new Task5c();
            T5.ShowDialog();
        }
    }
}
