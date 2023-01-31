using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objetos_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AlumnoInternacional AI = new AlumnoInternacional();
            Clase1 C = new Clase1();
          
        }

        private void xx(Alumno pO)
        { pO.CalcularCuota(); }


    }

    public abstract class Alumno
    {
         private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public string Nombre { get; set; }
        public abstract int CalcularCuota();
       
     }

    public class AlumnoNacional : Alumno
    {
        public string  DNI { get; set; }
       
        public override int CalcularCuota()
        {
            return 0;
           
        }
      
    }
    public class AlumnoInternacional : Alumno
    {
        public string Pasaporte { get; set; }

        public override int CalcularCuota()
        {
           return 1;
        }
        public int CalcularCuota(decimal a)
        {
            return 1;
        }
    }

    public class Clase1
    {
        public void Metodo1() { }
        public void Metodo1(int a) { }
        public void Metodo1(double a) { }
        public void Metodo1(int a, string b ) { }

    }

}


