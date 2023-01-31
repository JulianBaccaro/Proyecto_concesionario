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

namespace Objetos_2
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
            EjecutaOperacion(new Suma());
        }
        private void EjecutaOperacion(Operacion pO)
        {

            try
            {
                if (!Information.IsNumeric(textBox1.Text) || !Information.IsNumeric(textBox1.Text)) throw new Exception("Alguno de los valores no es numérico !!!");
                if (decimal.Parse(textBox1.Text) > 100 || decimal.Parse(textBox1.Text) < 0) throw new RangoInvalidoException();
                if (decimal.Parse(textBox2.Text) > 100 || decimal.Parse(textBox2.Text) < 0) throw new RangoInvalidoException();
                textBox3.Text = pO.Calcular(decimal.Parse(textBox1.Text), decimal.Parse(textBox2.Text)).ToString();
            }
            catch (RangoInvalidoException ex) when (decimal.Parse(textBox1.Text) > 100 || decimal.Parse(textBox1.Text) < 0) { MessageBox.Show($"RIE por textBox1 --> {ex.Message}"); }
            catch (RangoInvalidoException ex) when (decimal.Parse(textBox2.Text) > 100 || decimal.Parse(textBox2.Text) < 0) { MessageBox.Show($"RIE por textBox2 --> {ex.Message}"); }
            catch (FormatException ex) { MessageBox.Show($"FE --> {ex.Message}"); }
            catch (DivideByZeroException ex) { MessageBox.Show($"DBZE --> {ex.Message}"); }
            catch (InvalidCastException ex) { MessageBox.Show($"ICE --> {ex.Message}"); }
            catch (Exception ex) { MessageBox.Show($"E --> {ex.Message}"); }
            finally
            {
                MessageBox.Show("Siempre pasa por el Finally !!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EjecutaOperacion(new Resta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EjecutaOperacion(new Multiplicacion());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EjecutaOperacion(new Division());
        }
    }

    public abstract class Operacion
    {

        public abstract decimal Calcular(decimal pN1, decimal pN2);
       
    }

    public sealed class Suma : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 + pN2; ;
        }
    }
    public class Resta : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 - pN2; ;
        }
    }
    public class Multiplicacion : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 * pN2; ;
        }
    }
    public class Division : Operacion
    {
        public override decimal Calcular(decimal pN1, decimal pN2)
        {
            return pN1 / pN2; ;
        }
    }

    class RangoInvalidoException : Exception
    {
        public override string Message => "Uno o ambos valres ingresados supera 100 o es menor que 0 !!!";

    }
}
