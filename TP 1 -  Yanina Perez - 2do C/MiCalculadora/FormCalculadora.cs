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
        /// <summary>
        /// Cosntructor que inicializa el formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méotodo Limpiar. Limpia todos los valores del formulario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperator.SelectedItem = null;
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Méotodo que realiza las operaciones con los números pasados como parametro. Los recibe como tipo string, los carga
        /// a variables de tipo Numero y realiza la operación. Utiliza el método Operar de la clase Calculadora.
        /// </summary>
        /// <param name="numero1">Primer operando recibido</param>
        /// <param name="numero2">Segundo operando recibido</param>
        /// <param name="operador">Tipo de operación a realizar</param>
        /// <returns>Devuelve un dato de tipo double con el resultado de la operación. En caso de no poder parsear
        /// los valores numéricos devuelve 0 por default</returns>
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


        /// <summary>
        /// Método que se activa al hacer click en el boton "Operar". Toma los datos de las casillas correspondientes y, utilizando
        /// el método Operar de esta clase, realiza la operación. Carga el resultado en el lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder resultado = new StringBuilder();

            resultado.Append(FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperator.Text));

            lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// Método que se activa al hacer click en el boton "Limpiar". Limpia todos los valores del formulario a su estado original.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Método que se activa al hacer click en el boton "Convertir a binario". Lee el valor cargado en el lblResultado
        /// y lo traduce, de ser posible, a binario. Utilixz el método "DecimalBinario" de la clase Numero. Muestra el resultado
        /// en el lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Método que se activa al hacer click en el boton "Convertir a decimal". Lee el valor cargado en el lblResultado
        /// y lo traduce, de ser posible, a decimal. Utiliza el método "BinarioDecimal" de la clase Numero. Muestra el resultado
        /// en el lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string num1 = lblResultado.Text;

            Numero numero1 = new Numero();
            StringBuilder resultado = new StringBuilder();

            resultado.Append(numero1.BinarioDecimal(num1));

            lblResultado.Text = resultado.ToString();
            
        }

        /// <summary>
        /// Método que se llama al hacer click en el botón "Cerrar". Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
