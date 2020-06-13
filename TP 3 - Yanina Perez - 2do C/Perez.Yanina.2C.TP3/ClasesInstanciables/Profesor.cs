using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    /// <summary>
    /// La clase Profesor hereda de Universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        //Atributos
        private Queue<Universidad.EClases> claseDelDia;
        private static Random random;

        /// <summary>
        /// Constructor de clase. 
        /// Estatico, inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }


        /// <summary>
        /// Constructor por defecto.
        /// Llama al cosntructor de la clase base y carga dos clases random al Profesor.
        /// Inicializa la Queue de clases.
        /// No puedo reutilizar el constructor siguiente porque necesita utilizarlo el deserializador
        /// Repito esas dos lineas de codigo
        /// </summary>
        public Profesor() : base()
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }


        /// <summary>
        /// Constructor de la clase Profesor.
        /// Llama al cosntructor de la clase base y carga dos clases random al Profesor.
        /// Inicializa la Queue de clases.
        /// </summary>
        /// <param name="id">Numero de legajo</param>
        /// <param name="nombre">String, nombre</param>
        /// <param name="apellido">String, apellido</param>
        /// <param name="dni">Numero de dni, formato string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            claseDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }


        /// <summary>
        /// Metodo que asigna dos clases random a la Queue de clases
        /// </summary>
        private void _randomClases()
        {
            //Seteo del rango del random de acuerdo a la cantidad de elementos
            //del enumerado
            int maximo = Enum.GetNames(typeof(Universidad.EClases)).Length;
            claseDelDia.Enqueue((Universidad.EClases)random.Next(0, maximo));
            claseDelDia.Enqueue((Universidad.EClases)random.Next(0, maximo));
        }


        /// <summary>
        /// Sobreecribe el metodo MostrarDatos de la clase base.
        /// Muestra los datos del Profesor en forma de texto.
        /// </summary>
        /// <returns>Retorna un string con los datos del Profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder info = new StringBuilder();

            try
            {
                info.Append(base.MostrarDatos());
                info.AppendLine("CLASES DEL DIA:");

                foreach (Universidad.EClases clase in this.claseDelDia)
                {
                    info.AppendLine(Enum.GetName(typeof(Universidad.EClases), clase));
                }

                return info.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("No se pudieron cargar los datos correctamente", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron cargar los datos correctamente", e);
            }

        }


        /// <summary>
        /// Sobreescribe el metodo ParticiparEnClase de la clase base.
        /// Muestra la clase del dia correspondiente segun el orden establecido por la Queue y la saca de la lista
        /// en el orden establecido para las Queues.
        /// </summary>
        /// <returns>Retorna un string con la clase del dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder info = new StringBuilder();
            try
            {
                info.AppendLine(String.Format("Clase del día: {0}", this.claseDelDia.Dequeue()));

                return info.ToString();
            } 
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Error al acceder a la clase de la Queue", e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Error al cargar los datos del Profesor", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar metodo ParticiparEnClase", e);
            }

        }


        /// <summary>
        /// Sobreescribe el metodo ToString, muestra publicamente los datos del Profesor.
        /// </summary>
        /// <returns>Retorna un string con los datos, utiliza el metodo
        /// MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga del operador ==
        /// Compara un Profesor con una EClase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Universidad.EClases</param>
        /// <returns>Retorna true si la clase pertenece a las clases del dia del
        /// profesor y false si no pertenece. En caso de que la Queue de clases esta vacia
        /// retorna false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            try
            {
                if(i.claseDelDia.Count <= 0)
                {
                    return false;
                }

                foreach (Universidad.EClases cla in i.claseDelDia)
                {
                    if (cla == clase)
                    {
                        return true;
                    }
                }
            } catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia de instancia de Profesor o Queue de clases nula", e);
            }

            return false;
        }


        /// <summary>
        /// Sobrecarga del operador !=
        /// Compara un Profesor con una EClase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Universidad.EClases</param>
        /// <returns>Retorna true si la clase no pertenece a las clases del dia del
        /// profesor. En caso de que la Queue de clases esta vacia
        /// retorna true. Retorna false si la clase no pertenece a la Queue de clases del Profesor.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
