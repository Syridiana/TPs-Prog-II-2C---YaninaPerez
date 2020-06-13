using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor que llama al constructor de la clase base y tiene un mensaje por defecto
        /// </summary>
        public NacionalidadInvalidaException() : base("Nacionalidad invalida")
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje
        /// </summary>
        public NacionalidadInvalidaException(string mensaje) : base(mensaje)
        {

        }



        /// <summary>
        /// Constructor que llama al constructor de la clase base y le pasa un mensaje y una innerExcepcion
        /// </summary>
        public NacionalidadInvalidaException(string mensaje, Exception innerExcepcion) : base(mensaje, innerExcepcion)
        {

        }
    }
}
