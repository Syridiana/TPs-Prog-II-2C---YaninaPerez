using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo //Hago a la clase Automovil como indica el diagrama, la clase sera publica
    {
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) // Debo agregar la implementacion para el tipo que no estaba
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) // Agrego constructor que permita pasar como 
            : base(chasis, marca, color)                                              // parametro el tipo.
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio //Cambio a public la propiedad para poder acceder a los datos desde otra clase.
        {                                //Cambio el tipo devuelto a ETamanio.
            get
            {
                return ETamanio.Mediano; // Devuelvo el tamanio que corresponde a los autos
            }
        }


        public ETipo Tipo //Defino una propiedad que me permite cambiar el valor por default del atributo tipo
        {                                
            set
            {
                this.tipo = value; 
            }
        }

        public override sealed string Mostrar() // Es necesario que el metodo sea de tipo public para que pueda ser utilizado por fuera de la clase
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.Append(base.Mostrar()); // Llamo al metodo de la clase base para mostrar los datos y agrego mas abajo los datos especificos
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio)); // Agrego String.Format para que se agreguen los datos correctamente
            sb.AppendLine(String.Format("TIPO : {0}", this.tipo)); // Agrego String.Format para que se agreguen los datos correctamente
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //Convierto el objeto de tipo StringBuilder a tipo string
        }
    }
}
