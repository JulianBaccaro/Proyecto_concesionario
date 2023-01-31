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

namespace Eventos_01
{
    public partial class Form1 : Form
    {
        Termometro t1,t2;
        public Form1()
        {
            InitializeComponent();
            t1 = new Termometro() {Id="Termómetro 01" };
            t2 = new Termometro() {Id="Termómetro 02" };

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            t1.TemperaturaIncorrecta += Alerta;
            t2.TemperaturaIncorrecta += Alerta;
        }
        private void Alerta(object sender,TemperaturaIncorrectaEventArgs e)
        {
            Termometro termometroAuxiliar = (sender as Termometro);
            MessageBox.Show($"Problemas con el termómetro id: {termometroAuxiliar.Id}" +
                            $"{Environment.NewLine}{Environment.NewLine}" +
                            $"Temperatura Mínima: {e.TemperaturaMinima}{Environment.NewLine}" +
                            $"Temperatura Maxima: {e.TemperaturaMaxima}{Environment.NewLine}" +
                            $"Temperatura Ingresada: {e.TemperaturaIngresada}{ Environment.NewLine}" +
                            $"Delta Mínimo: {e.DeltaMinimo}{Environment.NewLine}" +
                            $"Delta Máximo: {e.DeltaMaximo}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string tempMin = Interaction.InputBox("Ingrese la temperatura mínima: ");
                if (!Information.IsNumeric(tempMin)) throw new Exception("La temperatura mínima debe ser un valor numérico !!!");
                string tempMax = Interaction.InputBox("Ingrese la temperatura máxima: ");
                if (!Information.IsNumeric(tempMax)) throw new Exception("La temperatura máximandebe ser un valor numérico !!!");
                string temp = Interaction.InputBox("Ingrese la temperatura: ");
                if (!Information.IsNumeric(temp)) throw new Exception("La temperatura debe ser un valor numérico !!!");
                t2.TemperaturaMinima = decimal.Parse(tempMin);
                t2.TemperaturaMaxima = decimal.Parse(tempMax);
                t2.Temperatura = decimal.Parse(temp);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string tempMin = Interaction.InputBox("Ingrese la temperatura mínima: ");
                if (!Information.IsNumeric(tempMin)) throw new Exception("La temperatura mínima debe ser un valor numérico !!!");
                string tempMax = Interaction.InputBox("Ingrese la temperatura máxima: ");
                if (!Information.IsNumeric(tempMax)) throw new Exception("La temperatura máximandebe ser un valor numérico !!!");
                string temp = Interaction.InputBox("Ingrese la temperatura: ");
                if (!Information.IsNumeric(temp)) throw new Exception("La temperatura debe ser un valor numérico !!!");
                t1.TemperaturaMinima = decimal.Parse(tempMin);
                t1.TemperaturaMaxima = decimal.Parse(tempMax);
                t1.Temperatura = decimal.Parse(temp);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
    public class Termometro
    {
        //Declaración del evento
        public event EventHandler<TemperaturaIncorrectaEventArgs> TemperaturaIncorrecta;
        decimal temperatura;
        public string Id { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal Temperatura 
        { 
            get { return temperatura; }
            set
            { 
                temperatura = value;
                // Evaluamos el valor de temperatura ingresado en el parámetro value
                // y si este es superior a 100 desencadenamos el evento AltaTemperatura
                // Al evento le pasamos dos parámetros: el sender de tipo object que apunta
                // al objeto responsable que el evento se haya desencadenado. El e de tipo
                // EventArgs que en este caso como no deseamos mandar información personalizadaç
                // lo ponemos a null.
                if (value > TemperaturaMaxima || value < TemperaturaMinima) TemperaturaIncorrecta?.Invoke(this,new TemperaturaIncorrectaEventArgs(TemperaturaMinima,TemperaturaMaxima,value));
                
            }       
        }
    }
    public class TemperaturaIncorrectaEventArgs : EventArgs
    {
        decimal temperaturaMinima, temperaturaMaxima, temperaturaIngresada;
        public TemperaturaIncorrectaEventArgs(decimal pTemperaturaMinima,decimal pTemperaturaMaxima,decimal pTemperaturaIngresada)
        { temperaturaMinima = pTemperaturaMinima;temperaturaMaxima = pTemperaturaMaxima;temperaturaIngresada = pTemperaturaIngresada; }
        public decimal TemperaturaMinima { get { return temperaturaMinima; } }
        public decimal TemperaturaMaxima { get { return temperaturaMaxima; } }
        public decimal TemperaturaIngresada { get { return temperaturaIngresada; } }
        public string DeltaMinimo 
        { 
            get
            {
                string rdo = "--";
                if(temperaturaIngresada<TemperaturaMinima)
                { rdo = (temperaturaMinima - temperaturaIngresada).ToString(); }
                return rdo;
            } 
        }
        public string DeltaMaximo
        {
            get
            {
                string rdo = "--";
                if (temperaturaIngresada > TemperaturaMaxima)
                { rdo = (temperaturaIngresada - temperaturaMaxima).ToString(); }
                return rdo;
            }
        }

    }
}
