using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazPropia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuncionEjecutar(new Suma());
        }
        private void FuncionEjecutar(ICalculo pO)
        {

            try
            {

                textBox3.Text=pO.Ejecutar(decimal.Parse(textBox1.Text), decimal.Parse(textBox2.Text)).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); textBox3.Clear(); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FuncionEjecutar(new Resta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FuncionEjecutar(new Producto());
        }
    }

    public class Suma : ICalculo
    {
        public decimal Ejecutar(decimal x, decimal y)
        {
            return x + y;
        }
    }
    public class Resta : ICalculo
    {
        public decimal Ejecutar(decimal x, decimal y)
        {
            return x - y;
        }
    }
    public class Producto : ICalculo
    {
        public decimal Ejecutar(decimal x, decimal y)
        {
            return x * y;
        }
    }
    interface ICalculo 
    {
        decimal Ejecutar(decimal x, decimal y);

    }
}
