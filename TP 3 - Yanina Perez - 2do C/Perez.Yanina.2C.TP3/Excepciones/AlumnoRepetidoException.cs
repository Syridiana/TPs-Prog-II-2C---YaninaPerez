using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje y una innerExcepcion
        /// </summary>
        public AlumnoRepetidoException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje
        /// </summary>
        public AlumnoRepetidoException(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje por defecto
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
