using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{

    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y tiene un mensaje por defecto
        /// </summary>
        public SinProfesorException() : base("No hay profesores para esa clase.")
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y acepta un mensaje y una innerExcepcion
        /// </summary>
        public SinProfesorException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y acepta un mensaje
        /// </summary>
        public SinProfesorException(string mensaje) : base(mensaje)
        {

        }
    }
}
