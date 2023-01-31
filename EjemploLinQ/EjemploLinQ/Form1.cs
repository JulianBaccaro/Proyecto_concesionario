using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploLinQ
{
    public partial class Form1 : Form
    {
        List<Persona> p;
        public Form1()
        {
            InitializeComponent();
            p = new List<Persona>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            p.AddRange(new Persona[] { new Persona() {DNI="20435678",Nombre="Ana", Apellido="Gomez" },
                                       new Persona() {DNI="33123543",Nombre="Juan", Apellido="Garcia" },
                                       new Persona() {DNI="40111231",Nombre="Sol", Apellido="Martinez" },
                                       new Persona() {DNI="18415838",Nombre="Pedro", Apellido="Fernandez"},
                                       new Persona() {DNI="28465888",Nombre="Cecilia", Apellido="Fernandez"},
                                      });
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = from per in p where int.Parse(per.DNI) > 35000000 select per;
            Mostrar(x);
        }
        private void Mostrar(IEnumerable<object> pO)
        {
            dataGridView1.DataSource = null;dataGridView1.DataSource = pO.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Mostrar(from per in p select per);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Mostrar(from per in p where per.Apellido.Substring(0,textBox1.Text.Length)==textBox1.Text select per);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar(from per in p 
                    where int.Parse(per.DNI) > 20000000 && int.Parse(per.DNI) < 40000000
                    select per);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mostrar(from per in p orderby per.DNI ascending select per);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mostrar(from per in p orderby per.DNI descending select per);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mostrar(from per in p orderby per.Apellido ascending,per.Nombre descending select per);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mostrar(from per in p select new { Apellido_y_Nombre = $"{per.Apellido}, {per.Nombre}", DNI =DNIPuntitos(per.DNI)});
        }
        private string DNIPuntitos(string pO)
        {
           
            var p1 = pO.Substring(5,3);
            var p2 = pO.Substring(2,3);
            var p3 = pO.Length == 8 ? pO.Substring(0, 2) : pO.Substring(0, 1);
            var rdo = $"{p3}.{p2}.{p1}";
            return rdo;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var z= dataGridView1.SelectedRows[0].DataBoundItem;
            var zz= p.Find(x => x.DNI == dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Replace(".", ""));
        }
    }
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
