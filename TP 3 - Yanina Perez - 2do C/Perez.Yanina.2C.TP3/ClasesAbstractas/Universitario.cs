using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// La clase Universitario hereda de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        //Atributos
        private int legajo;

        /// <summary>
        /// Constructor por defecto que llama al constructor de la clase base
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        /// <param name="legajo">Parametro de tipo int</param>
        /// <param name="nombre">Parametro de tipo string</param>
        /// <param name="apellido">Parametro de tipo string</param>
        /// <param name="dni">Parametro de tipo string</param>
        /// <param name="nacionalidad">Parametro de tipo ENacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Sobrecarga del metodo Equals. Utiliza la sobrecarga del operador ==
        /// </summary>
        /// <param name="obj">Parametro a comparar</param>
        /// <returns>Retorna true si la instancia que llamo al metodo
        /// y el objeto pasado por parametro son iguales.</returns>
        public override bool Equals(object obj)
        {
            return this == (Universitario)obj;
        }

        /// <summary>
        /// Metodo que genera un string con los datos del Universitario
        /// </summary>
        /// <returns>Retorna un string</returns>
        protected virtual string MostrarDatos()
        {
            try
            {
                StringBuilder info = new StringBuilder();
            info.AppendLine(base.ToString());
            info.AppendLine(String.Format("LEGAJO NÚMERO: {0}", this.legajo));

            return info.ToString();

            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Error en el metodo MostrarDatos, no se pudieron interpretar" +
                    "los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en el metodo MostrarDatos, no se pudieron interpretar los datos", e);
            }
        }

        //Metodo abstracto ParticiparEnClase
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga del operador == que compara dos instancias de Universitario.
        /// Dos Universitarios seran iguales si sus dnis, sus legajos y sus tipos son iguales.
        /// </summary>
        /// <param name="pg1">Instancia 1 a comparar</param>
        /// <param name="pg2">Instancia 2 a comparar</param>
        /// <returns>Retorna true si los dni y lo legajos son iguales y false
        /// en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            try
            {
                //Chequeo que los Universitarios sean del mismo tipo
                if (pg1.GetType() == pg2.GetType())
                {
                    //Chequeo que los Universitarios tengan el mismo legajo y el mismo dni
                    if ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("La referencia a alguna de las instancias de Universidad es nula", e);
            }
        
        }


        /// <summary>
        /// Sobrecarga del operador != que compara dos instancias de Universitario.
        /// Dos Universitarios seran diferentes si sus dnis, sus legajos
        /// o sus tipos son diferentes.
        /// </summary>
        /// <param name="pg1">Instancia 1 a comparar</param>
        /// <param name="pg2">Instancia 2 a comparar</param>
        /// <returns>Retorna true si los dni y lo legajos son iguales y false
        /// en caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        /// <summary>
        /// Propiedad que setea y retorna el legajo.
        /// Utilizada para poder serializar y deserializar el atributo privado de legajo
        /// en Xml.
        /// </summary>
        public int Legajo
        {
            set
            {
                this.legajo = value;
            }
            get
            {
                return this.legajo;
            }
        }
    }
}
