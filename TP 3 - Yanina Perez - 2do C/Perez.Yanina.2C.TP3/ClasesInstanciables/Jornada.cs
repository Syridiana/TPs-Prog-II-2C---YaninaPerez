using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase Jornada
    /// </summary>
    public class Jornada
    {
        //Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor por defecto de la clase. Inicializa la lista de Alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de la clase. Reutiliza el constructor por defecto.
        /// Carga el atribuo clase y el atributo instructor.
        /// </summary>
        /// <param name="clase">Universidad.EClases</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }


        /// <summary>
        /// Metodo de clase. Guarda los datos de la jornada pasada 
        /// por parametro en un archivo de tipo txt.
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>Retorn true si lo guardo correctamente, en caso de un error
        /// lanza una excepcion de tipo ArchivosException</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto archivo = new Texto();
                bool guardo = archivo.Guardar("Jornada.txt", jornada.ToString());
                return true;
            }
            catch (ArgumentNullException e)
            {
                throw new ArchivosException("Error al guardar el archivo. Error de referencia nula", e);
            }
            catch (IOException ej)
            {
                throw new ArchivosException("Error al guardar el archivo.", ej);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al guardar el archivo.", ex);
            }
            
        }

        /// <summary>
        /// Metodo de clase que lee los datos de un archivo de texto.
        /// </summary>
        /// <returns>Retorna un string con los datos.
        /// En caso de error lanza una excepcion de tipo ArchivosException</returns>
        public static string Leer()
        {
            try
            {
                string datos;
                Texto archivo = new Texto();
                bool leyo = archivo.Leer("Jornada.txt", out datos);
                return datos;
            }
            catch(ArgumentNullException e)
            {
                throw new ArchivosException("Error al leer el archivo. Error de referencia nula", e);
            }
            catch (IOException ej)
            {
                throw new ArchivosException("Error al leer el archivo.", ej);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al leer el archivo.", ex);
            }

        }


        /// <summary>
        /// Metodo que sobreescribe el metodo ToString.
        /// Muestra los datos de la Jornada en un string
        /// </summary>
        /// <returns>Retorna los datos en un string.</returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            try
            {
                info.Append(String.Format("CLASE DE {0} POR ", this.clase));
                info.AppendLine(this.Instructor.ToString());
                info.AppendLine("ALUMNOS:");

                if (this.Alumnos.Count > 0)
                {
                    foreach (Alumno a in this.Alumnos)
                    {
                        info.AppendLine(a.ToString());
                    }
                }
                else
                {
                    info.AppendLine("No hay alumnos en esta clase");
                }

                info.Append("<------------------------------------------------->");
                return info.ToString();
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("No se pudieron interpretar correctamente los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudieron interpretar correctamente los datos", e);
            }

        }


        /// <summary>
        /// Propiedad que setea o devuelve una lista de alumnos.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                try
                {
                    this.alumnos = value;
                }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la lista de alumnos", e);
                }

            }
        }


        /// <summary>
        /// Propiedad que setea o devuelve el atributo clase.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                try
                {
                    this.clase = value;
                }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la clase", e);
                }
            }
        }

        /// <summary>
        /// Propiedad que setea o devuelve el atributo instructor.
        /// Valida que los valores no sean null, sino lanza una excepcion.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                try
                {
                    this.instructor = value;
                }
                catch (ArgumentNullException e)
                {
                    throw new ArgumentNullException("El valor es nulo", e);
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Error al cargar la clase", e);
                }
            }
        }


        /// <summary>
        /// Sobrecarga del operador ==, compara una Jornada con un Alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno esta en la lista de alumnos de la jornada
        /// y false en caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            try
            {
                foreach (Alumno al in j.Alumnos)
                {
                    if (a == al)
                    {
                        return true;
                    }
                }

                return false;

            } catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia de Jornada o de Alumno nula", e);
            } 

        }


        /// <summary>
        /// Sobrecarga del operador !=, compara una Jornada con un Alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno no esta en la lista de alumnos de la jornada
        /// y false en caso contrario.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Sobrecarga del operador +.
        /// Agrega un Alumno a la lista de alumnos de una Jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la Jornada con el alumno agregado en caso de que no estuviera
        /// y la misma jornada en caso de que el alumno ya estuviera en a jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            try
            {
                if (j != a)
                {
                    j.Alumnos.Add(a);
                }

                return j;

            } catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia de instancia de Jornada o de Alumno nula", e);
            } 

        }
    }
}
