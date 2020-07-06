using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaninaPerez_2doC_TP4
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructores de la excepcion TrackingIdRepetidoException
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : base (mensaje)
        {

        }

        public TrackingIdRepetidoException(string mensaje, Exception innerException) 
            : base(mensaje, innerException)
        {

        }
    }
}
