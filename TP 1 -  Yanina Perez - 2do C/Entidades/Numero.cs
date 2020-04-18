using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        public Numero() : this(0)
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        static double ValidarNumero(string strNumero)
        {
            double numero = 0;
            double.TryParse(strNumero, out numero);

            return numero;
        }

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

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

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

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
    }

}
