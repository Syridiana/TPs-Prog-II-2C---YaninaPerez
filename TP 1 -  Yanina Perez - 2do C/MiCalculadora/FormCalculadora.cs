using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperator.SelectedItem = null;
            lblResultado.Text = "0";
        }

        private static double Operar(string  numero1, string numero2, string operador)
        {
            double primerNumero;
            double SegundoNumero;
            Numero num1;
            Numero num2;

            if (double.TryParse(numero1, out primerNumero))
            {
                if (double.TryParse(numero2, out SegundoNumero))
                {
                    num1 = new Numero(primerNumero);
                    num2 = new Numero(SegundoNumero);

                    return Calculadora.Operar(num1, num2, operador);
                }
            }

            return 0;
        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder resultado = new StringBuilder();

            resultado.Append(FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperator.Text));

            lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double num1;

            if (double.TryParse(lblResultado.Text, out num1))
            {
                Numero numero1 = new Numero(num1);
                StringBuilder resultado = new StringBuilder();

                resultado.Append(numero1.DecimalBinario(num1));

                lblResultado.Text = resultado.ToString();
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string num1 = lblResultado.Text;

            Numero numero1 = new Numero();
            StringBuilder resultado = new StringBuilder();

            resultado.Append(numero1.BinarioDecimal(num1));

            lblResultado.Text = resultado.ToString();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
