using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje
        /// </summary>
        public DniInvalidoException() : base("Error de Dni invalido")
        {
            
        }


        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje
        /// </summary>
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }


        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje y una innerException
        /// </summary>
        public DniInvalidoException(string mensaje, Exception innerExcepxion) : base(mensaje, innerExcepxion)
        {

        }
    }
}
