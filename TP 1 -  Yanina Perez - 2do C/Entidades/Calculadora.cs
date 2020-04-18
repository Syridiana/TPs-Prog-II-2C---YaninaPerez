using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if (operador == "*" || operador == "-" || operador == "+" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {

            string op = Calculadora.ValidarOperador(operador);

            if (op == "+")
            {
                return num1 + num2;
            }
            else if (op == "-")
            {
                return num1 - num2;

            }
            else if (op == "*")
            {
                return num1 * num2;
            }
            else
            {
                return num1 / num2;
            }
            
        }


    }
}
