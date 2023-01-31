using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Objetos_3
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
            PruebaConstructorDestructor pcd1 = new PruebaConstructorDestructor();
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            pcd2 = new PruebaConstructorDestructor(Interaction.InputBox("Ingrese un código: "));
        }
        PruebaConstructorDestructor pcd2;
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pcd2.Codigo);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pcd2 = null;
            GC.Collect();
        }
    }
    public class PruebaConstructorDestructor
    {
        public PruebaConstructorDestructor()
        {
            MessageBox.Show("SE EJECUTÓ EL CONSTRUCTOR SIN PARÁMETROS !!!");
        }
        public PruebaConstructorDestructor(string pO)
        {
            MessageBox.Show("SE EJECUTÓ EL CONSTRUCTOR CON 1 PARÁMETRO DONDE SE LE PASA EL CÓDIGO !!!");
            Codigo = pO;
        }
        public string Codigo { get; set; }
       
        ~PruebaConstructorDestructor()
        {
            MessageBox.Show("SE EJECUTÓ EL DESTRUCTOR DEL OBJETO !!!");
        }
    }
}
