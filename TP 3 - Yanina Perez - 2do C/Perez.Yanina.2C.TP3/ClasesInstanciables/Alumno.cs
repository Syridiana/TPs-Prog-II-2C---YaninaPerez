using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase que hereada de Universitario
    /// </summary>
    public sealed class Alumno : Universitario
    {
        //Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        //Enumerados
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
       

        /// <summary>
        /// Constructor por defecto que llama al constructor de la clase base
        /// </summary>
        public Alumno () : base()
        {

        }

        /// <summary>
        /// Constrcutor de clase. Llama al constructor de la clase base.
        /// Carga el atributo claseQueToma
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">Universidad.EClases</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        /// <summary>
        /// Constrcutor de clase. Llama a otro constructor de esta clase.
        /// Carga el atributo estadoCuenta
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">Universidad.EClases</param>
        /// <param name="estadoCuenta">EEstadoCuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, 
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : 
            this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Metodo que muestra los datos del Alumno
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder info = new StringBuilder();
            string estado;

            try
            {
                info.AppendLine(base.MostrarDatos());

                if (this.estadoCuenta == EEstadoCuenta.AlDia)
                {
                    estado = "Cuota al día";
                }
                else
                {
                    estado = Enum.GetName(typeof(EEstadoCuenta), this.estadoCuenta).ToString();
                }

                info.AppendLine(String.Format("ESTADO DE CUENTA: {0}", estado));
                info.AppendLine(String.Format("TOMA CLASES DE: {0}", this.claseQueToma));

                return info.ToString();
            } 
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", e);
            }
            
        }

        /// <summary>
        /// Metodo que muestra en formato de texto que clase toma el alumno
        /// </summary>
        /// <returns>Retorna un string con la informacion</returns>
        protected override string ParticiparEnClase()
        {
            try
            {
                StringBuilder info = new StringBuilder();
                info.AppendLine(String.Format("Toma clase de: {0}", this.claseQueToma));

                return info.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", e);
            }

        }

        /// <summary>
        /// Metodo que muestra los datos de acceso publico
        /// </summary>
        /// <returns>Retorna un string con los datos, utiliza el metodo
        /// MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga del operador ==
        /// Compara un Alumno con una EClase
        /// </summary>
        /// <param name="a">Instancia de ALumno</param>
        /// <param name="clase">EClase</param>
        /// <returns>Retorna true si el alumno toma la clase y no es deudor y false
        /// si no la toma o es deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            try
            {
                if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    return true;
                }

                return false;
            } 
            catch(NullReferenceException e)
            {
                throw new NullReferenceException("La referencia a la instancia de Alumno es nula", e);
            }
          }

        /// <summary>
        /// Sobrecarga del operador !=
        /// Compara un Alumno con una EClase
        /// </summary>
        /// <param name="a">Instancia de ALumno</param>
        /// <param name="clase">EClase</param>
        /// <returns>Retorna true si el alumno no toma la clase o es deudor y false
        /// si la toma y no es deudor</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
    }
}
