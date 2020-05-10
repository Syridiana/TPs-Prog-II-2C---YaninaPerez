using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        /// Atributo privado donde se guarda el valor numerico del Numero
        /// </summary>
        private double numero;

        /// <summary>
        /// Cosntructor de la clase que no recibe parametros, setea el atributo numero en 0 por default reutilizando otro 
        /// constructor
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor que recibe un parametro numerico de tipo double y lo setea en el atributo correspondiente
        /// </summary>
        /// <param name="numero">Parametro numerico recibido</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de Numero que recibe de parametro un valor de tipo string. Utiliza la propiedad SetNumero para setear 
        /// el valor del atributo numero a un valor de tipo double
        /// </summary>
        /// <param name="strNumero">Parametro recibido a convertir a double</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Metodo para validar un valor numerico recibido como tipo string. 
        /// </summary>
        /// <param name="strNumero">Parametro recibido a parsear</param>
        /// <returns>El metodo retorna el valor parseado, en caso de 
        /// ser un valor incorrecto retorna 0 por default</returns>
        static double ValidarNumero(string strNumero)
        {
            double numero = 0;
            double.TryParse(strNumero, out numero);

            return numero;
        }

        /// <summary>
        /// Metodo que transforma un valor string (que representa un valor numerico binario) a su correspondiente valor 
        /// numerico. 
        /// </summary>
        /// <param name="binario">Valor binario recibido a analizar</param>
        /// <returns>Retorna el valor en formato decimal en un tipo string. En caso de no poder convertirse devuelve
        /// "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            int contador = 0;
            string resultado;
            int j = 0;

            for (int i = binario.Length-1; i >=0 ; i--)
                {
                    if (binario[i] != '0' && binario[i] != '1')
                    {
                        return "Valor inválido";
                    }

                    int potenciasDeDos = (int)Math.Pow(2, j);
                    contador += (int)Char.GetNumericValue(binario, i) * potenciasDeDos;
                    j++;
                 } 

            resultado = contador.ToString();
            return resultado;
        }

        /// <summary>
        /// Recibe un valor double en formato decimal y lo transforma a su equivalente binario. 
        /// </summary>
        /// <param name="numero">Valor de tipo double recibido para transformar</param>
        /// <returns>Retorna un string con el
        /// valor binario. En caso de no poder convertirse devuelve "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            if(numero%1>0 || numero<0)
            {
                return "Valor inválido";
            }
            else
            {
                int num = (int) numero;
                StringBuilder binario = new StringBuilder();

                while (num > 0)
                {
                    binario.Insert(0, (num % 2));
                    num -= num % 2;
                    num /= 2;
                }

                return binario.ToString();
            }
            
        }

        /// <summary>
        /// Recibe un valor numerico en formato string. 
        /// </summary>
        /// <param name="numero">Parametro recibido a analizar</param>
        /// <returns>Retorna su equivalente en binario (tipo string). En caso de no ser
        /// posible la conversion devuelve "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            this.SetNumero = numero;

            if (this.numero % 1 > 0 || this.numero < 0)
            {
                return "Valor inválido";
            }
            else
            {
                int num = (int)this.numero;
                StringBuilder binario = new StringBuilder();

                while (num > 0)
                {
                    binario.Insert(0, (num % 2));
                    num -= num % 2;
                    num /= 2;
                }

                return binario.ToString();
            }

        }

        /// <summary>
        /// Sobrecarga de operador +. Suma los valores del atributo "numero" de cada Numero recibido.
        /// </summary>
        /// <param name="n1">Numero para operar</param>
        /// <param name="n2">Numero para operar</param>
        /// <returns>Retorna el resultado en formato double.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador -. Suma los valores del atributo "numero" de cada Numero recibido.
        /// </summary>
        /// <param name="n1">Numero para operar</param>
        /// <param name="n2">Numero para operar</param>
        /// <returns>Retorna el resultado en formato double.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador *. Suma los valores del atributo "numero" de cada Numero recibido.
        /// </summary>
        /// <param name="n1">Numero para operar</param>
        /// <param name="n2">Numero para operar</param>
        /// <returns>Retorna el resultado en formato double.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador /. Suma los valores del atributo "numero" de cada Numero recibido.
        /// </summary>
        /// <param name="n1">Numero para operar</param>
        /// <param name="n2">Numero para operar</param>
        /// <returns>Retorna el resultado en formato double. En caso de el segundo operando ser 0 retorna double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        /// <summary>
        /// Propiedad set. Carga el valor pasado al atributo privado "numero", previa validación con el método ValidarNumero.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
    }

}
