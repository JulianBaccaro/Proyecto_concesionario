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

namespace Herencia_Polimorfismo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Empleado> le;
        private void Form1_Load(object sender, EventArgs e)
        {
            le = new List<Empleado>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Empleado auxE=null;
                if (radioButton1.Checked) // Significa que desean crear un Administrativo
                {
                    auxE = new EmpleadoAdministrativo(Interaction.InputBox("DNI: "),
                                                     Interaction.InputBox("Nombre: "),
                                                     Interaction.InputBox("Apellido: "),
                                                     decimal.Parse(Interaction.InputBox("Sueldo Bruto: ")),
                                                     decimal.Parse(Interaction.InputBox("Premio: ")));
                }
                else
                {
                    auxE = new EmpleadoGerente(Interaction.InputBox("DNI: "),
                                               Interaction.InputBox("Nombre: "),
                                               Interaction.InputBox("Apellido: "),
                                               decimal.Parse(Interaction.InputBox("Sueldo Bruto: ")),
                                               decimal.Parse(Interaction.InputBox("Bono porcentual: ")));
                }
                le.Add(auxE);
                Mostrar(dataGridView1, le);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void Mostrar(DataGridView pDGV, List<Empleado> pListaEmpleado)
        {
            EmpleadoVista ev = new EmpleadoVista();
            pDGV.DataSource = null;
            pDGV.DataSource = ev.RetornaListaEmpleadoVista(pListaEmpleado);
        }
    }
    public class EmpleadoVista
    {
        public EmpleadoVista(string pDNI, string pNombre, string pApellido, decimal pSueldoBruto,decimal pPremio,decimal pBono,decimal pDescuento,decimal pSueldoPagar)
        {
            DNI = pDNI; Nombre = pNombre; Apellido = pApellido; 
            SueldoBruto = pSueldoBruto;Bono = pBono;Descuento = pDescuento;
            Sueldo_a_Pagar = pSueldoPagar;
        }
        public EmpleadoVista() { }

        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal SueldoBruto { get; set; }
        public decimal Premio { get; set; }
        public decimal Bono { get; set; }
        public decimal Descuento { get; set;}
        public decimal Sueldo_a_Pagar { get; set; }

        public List<EmpleadoVista> RetornaListaEmpleadoVista(List<Empleado> pListaEmpleado)
        {
            List<EmpleadoVista> auxLEV = new List<EmpleadoVista>();
            foreach(Empleado emp in pListaEmpleado)
            {
                EmpleadoVista auxEV = new EmpleadoVista();
                auxEV.DNI = emp.DNI; auxEV.Nombre = emp.Nombre; auxEV.Apellido = emp.Apellido;
                auxEV.SueldoBruto = emp.SueldoBruto; 
                auxEV.Sueldo_a_Pagar = emp.CalcularSueldo();
                auxEV.Descuento = emp.Descuento;
                if (emp is EmpleadoAdministrativo)
                {
                    auxEV.Premio = (emp as EmpleadoAdministrativo).Premio;
                    auxEV.Bono = 0;
                }
                else
                {
                    auxEV.Premio = 0; 
                    auxEV.Bono = (emp as EmpleadoGerente).BonoPorciento ;
                }
                auxLEV.Add(auxEV);
            }
            return auxLEV;
        }
    }
    public abstract class Empleado
    {
        public Empleado(string pDNI, string pNombre, string pApellido, decimal pSueldoBruto)
        {
            DNI = pDNI;Nombre = pNombre; Apellido = pApellido;SueldoBruto = pSueldoBruto;
        }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal SueldoBruto { get; set; }
     
        public abstract decimal Descuento { get; }

        public abstract decimal CalcularSueldo();
    }
    public class EmpleadoAdministrativo : Empleado
    {
        public EmpleadoAdministrativo(string pDNI, string pNombre, string pApellido, decimal pSueldoBruto,decimal pPremio): base(pDNI,pNombre,pApellido,pSueldoBruto)
        {
            Premio = pPremio;
        }
        public decimal Premio { get; set; }
        decimal descuento;
        public override decimal Descuento => descuento;

        public override decimal CalcularSueldo()
        {
            descuento = (SueldoBruto + Premio) * .1m;
            return SueldoBruto + Premio - descuento;
        }
    }
    public class EmpleadoGerente : Empleado
    {
        public EmpleadoGerente(string pDNI, string pNombre, string pApellido, decimal pSueldoBruto, decimal pBonoPorciento) : base(pDNI, pNombre, pApellido, pSueldoBruto)
        {
            BonoPorciento = pBonoPorciento;
        }

        public decimal BonoPorciento { get; set; }
        decimal descuento;
        public override decimal Descuento => descuento;

        public override decimal CalcularSueldo()
        {
            descuento = (SueldoBruto * (1 + (BonoPorciento/100))) * .2m;
            return (SueldoBruto * (1+(BonoPorciento/100))) - descuento;
        }
    }

}
