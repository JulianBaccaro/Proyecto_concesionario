using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz_Icomparer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Persona[] p;
        private void Form1_Load(object sender, EventArgs e)
        {
            p = new Persona[]{ new Persona() {Nombre="Sol",Apellido="Garcia",Edad=12},
                               new Persona() {Nombre="Ana",Apellido="Perez",Edad=45},
                               new Persona() {Nombre="Martín",Apellido = "Alonso",Edad = 33},
                               new Persona() {Nombre="Martín",Apellido = "Perez",Edad = 33}
                             };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var x in p) { listBox1.Items.Add(x.ToString());}
            Array.Sort(p, new Persona.NombreASC());
            listBox2.Items.Clear();
            foreach (var x in p) { listBox2.Items.Add(x.ToString()); }
            Array.Sort(p, new Persona.NombreDESC());
            listBox3.Items.Clear();
            foreach (var x in p) { listBox3.Items.Add(x.ToString()); }
            Array.Sort(p, new Persona.ApellidoASC());
            listBox4.Items.Clear();
            foreach (var x in p) { listBox4.Items.Add(x.ToString()); }
            Array.Sort(p, new Persona.ApellidoDESC());
            listBox5.Items.Clear();
            foreach (var x in p) { listBox5.Items.Add(x.ToString()); }
            Array.Sort(p, new Persona.EdadASC());
            listBox6.Items.Clear();
            foreach (var x in p) { listBox6.Items.Add(x.ToString()); }
            Array.Sort(p, new Persona.EdadDESC());
            listBox7.Items.Clear();
            foreach (var x in p) { listBox7.Items.Add(x.ToString()); }
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} {Edad}";
        }

        public class NombreASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = string.Compare(x.Nombre, y.Nombre);
                if (rdo == 0)
                {
                    if (string.Compare(x.Apellido, y.Apellido) < 0) rdo = -1;
                    if (string.Compare(x.Apellido, y.Apellido) > 0) rdo = 1;
                }
                return rdo;
            }
        }
        public class NombreDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = string.Compare(x.Nombre, y.Nombre);
                if (rdo == 0)
                {
                    if (string.Compare(x.Apellido, y.Apellido) < 0) rdo = -1;
                    if (string.Compare(x.Apellido, y.Apellido) > 0) rdo = 1;
                }
                return rdo * -1;
            }
        }
        public class ApellidoASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = string.Compare(x.Apellido, y.Apellido);
                //Si las personas poseen el mismo apellido
                if(rdo == 0)
                {
                    if (string.Compare(x.Nombre, y.Nombre) < 0) rdo = -1;
                    if (string.Compare(x.Nombre, y.Nombre) > 0) rdo = 1;
                }
                return rdo;
            }
        }
        public class ApellidoDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = string.Compare(x.Apellido, y.Apellido);
                //Si las personas poseen el mismo apellido
                if (rdo == 0)
                {
                    if (string.Compare(x.Nombre, y.Nombre) < 0) rdo = -1;
                    if (string.Compare(x.Nombre, y.Nombre) > 0) rdo = 1;
                }
                return rdo * -1;
            }
        }
        public class EdadASC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = 0;
                if (x.Edad > y.Edad) rdo = 1;
                if (y.Edad > x.Edad) rdo = -1;
                return rdo ;
            }
        }
        public class EdadDESC : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                int rdo = 0;
                if (x.Edad > y.Edad) rdo = -1;
                if (y.Edad > x.Edad) rdo = 1;
                return rdo;
            }
        }
    }
}
