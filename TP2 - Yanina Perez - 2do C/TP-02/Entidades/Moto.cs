using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo // Moto hereda de la clase Vehiculo
    {
        /// <summary>
        /// Constructor de la clase moto
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Moto(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color) // Agrego llamada a constructor de la
        {                                                                                          // clase base.
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        public override ETamanio Tamanio // La propiedad deberia ser publica y llevar el modificador override para implementar el metodo
        {                             // abstracto de la clase base. El valor devuelto debe ser de tipo ETamanio.
            get
            {
                return ETamanio.Chico; // El valor devuelto debe ser de ETamanio.Chico
            }
        }

        public override sealed string Mostrar() // Es necesario que el metodo sea de tipo public para que pueda ser utilizado por fuera 
        {                                          // de la clase
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO"); 
            sb.Append(base.Mostrar()); // Llamo al metodo de la clase base para mostrar los datos y agrego mas abajo los datos especificos
            sb.Append(String.Format("TAMAÑO : {0}", this.Tamanio)); // Agrego String.Format para que se agreguen los datos correctamente
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Convierto el objeto de tipo StringBuilder a tipo string
        }
    }
}
