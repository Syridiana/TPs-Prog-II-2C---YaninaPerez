using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo. 
    /// Modifico el modificador de acceso por abstract
    /// ya que no se debe poder instanciar. Es una clase base, no deberia ser sealed.
    /// </summary>
    public abstract class Vehiculo 
    {
        public enum EMarca // Modifico los enumerados a public para que puedan ser accesibles desde las otras clases
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio // Modifico los enumerados a public para que puedan ser accesibles desde las otras clases
        {
            Chico, Mediano, Grande
        }

        private EMarca marca;
        private string chasis; // De acuerdo a las reglas de estilo agrego el modificador private (si bien por defecto ya lo era)
        private ConsoleColor color;

        /// <summary>
        /// Agrego constructor de la clase
        /// </summary>
        /// <param name="chasis">Parametro para cargar en el atributo chasis</param>
        /// <param name="marca">Parametro para cargar en el atributo marca</param>
        /// <param name="color">Parametro para cargar en el atributo color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; /*set;*/ } // Quito el "set" de la firma ya que la propiedad debe ser de solo lectura
        // Modifico el modificador de acceso de la propiedad a public para que sea accesible desde las otras clases

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Devuelve un string con los datos del vehiculo</returns>
        public virtual string Mostrar() // Cambio el modificador de acceso sealed por public y virtual ya que sus instancias 
        {                               // poseen un override para este metodo.
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("CHASIS: {0}", this.chasis)); //Es necesario agregar String.Format para componer el 
            sb.AppendLine(String.Format("MARCA : {0}", this.marca.ToString())); //texto de esa forma. Quito salto de linea (ya esta contemplado en el AppendLine)
            sb.AppendLine(String.Format("COLOR : {0}", this.color.ToString()));

            return sb.ToString(); //Agrego ToString para que retorne un string
                                 // Reutilizo la carga del operador que sigue para mostrar los datos de los vehiculos
        }

        public static explicit operator string(Vehiculo p) // La sobrecarga del operador debe ser publica
        { 
            return p.Mostrar(); //Reutilizo el metodo Mostrar
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehiculo a comparar 1</param>
        /// <param name="v2">Vehiculo a comparar 2</param>
        /// <returns>Retorna true si los dos chasis son iguales y false en caso contrario</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2) 
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehiculo a comparar 1</param>
        /// <param name="v2">Vehiculo a comparar 2</param>
        /// <returns>Retorna false si los dos chasis son iguales y true en caso contrario</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2); // Reutilizo el operador anterior
        }
    }
}
