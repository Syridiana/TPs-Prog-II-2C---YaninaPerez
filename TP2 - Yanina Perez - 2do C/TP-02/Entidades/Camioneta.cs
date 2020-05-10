using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo // Camioneta hereda de la clase Vehiculo
    {
        /// <summary>
        /// Constructor de la clase camioneta
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio // La propiedad deberia ser publica y llevar el modificador override para implementar el metodo
        {                                // abstracto de la clase base. El valor devuelto debe ser de tipo ETamanio.
            get
            {
                return ETamanio.Grande;  // El valor devuelto debe ser de ETamanio.Grande
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.Append(base.Mostrar()); // Llamo al metodo de la clase Mostrar base para mostrar los datos y agrego mas abajo los datos especificos
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio)); // Agrego String.Format para que se agreguen los datos correctamente
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Convierto el objeto de tipo StringBuilder a tipo string
        }
    }
}
