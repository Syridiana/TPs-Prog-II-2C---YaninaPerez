using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Recibe un operador para ser validado y lo retorna, en caso de no ser un operador valido retorna "+" por defecto
        /// </summary>
        /// <param name="operador">El parametro recibido es el operador para validar</param>
        /// <returns>Recibe un operador para ser validado y lo retorna, en caso de no ser un operador valido retorna "+" 
        /// por defecto</returns>
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

        /// <summary>
        /// Reliza las operaciones de la calculadora utilizando el metodo ValidarOperador.
        /// </summary>
        /// <param name="num1">Objeto Numero para calcular</param>
        /// <param name="num2">Objeto Numero para calcular</param>
        /// <param name="operador">Operador a validar y para realizar el calculo</param>
        /// <returns> Retorna el resultado como tipo double</returns>
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
