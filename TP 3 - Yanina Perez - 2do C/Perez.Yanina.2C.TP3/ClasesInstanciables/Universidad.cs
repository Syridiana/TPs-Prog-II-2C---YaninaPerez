using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;


namespace ClasesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]

    public class Universidad
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        /// <summary>
        /// Enumerados
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }


        /// <summary>
        /// Constructor por defecto que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }


        /// <summary>
        /// Propiedad que devuelve y setea la lista de Alumnos
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
                    //Controlo que no se intente asignar una referencia nula
                    this.alumnos = value;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException("Error de referencia nula", e);
                }
            }
        }

        /// <summary>
        /// Propiedad que devuelve y setea la lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                try
                {
                    //Controlo que no se intente asignar una referencia nula
                    this.profesores = value;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException("Error de referencia nula", e);
                }

            }
        }

        /// <summary>
        /// Propiedad que devuelve y setea la lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                try
                {
                    //Controlo que no se intente asignar una referencia nula
                    this.jornadas = value;
                }
                catch (NullReferenceException e)
                {
                    throw new NullReferenceException("Error de referencia nula", e);
                }
            }
        }

        /// <summary>
        /// Indexador de la lista de Jornadas. Devuelve la Jornada correspondiente 
        /// al lugar en la lista del indice pasado
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>Retorna la Jornada correspondiente</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                try
                {
                    this.jornadas[i] = value;
                }
                catch (NullReferenceException e)
                {
                    //Controlo que no se intente asignar una referencia nula
                    throw new NullReferenceException("Error de referencia nula", e);
                }
            }
        }


        /// <summary>
        /// Metodo que serializa en un archivo Xml una Univeridad
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>Retorna true en caso de haberlo serializado correctamente y lanza una 
        /// excepcion en caso de error</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                archivo.Guardar("Universidad.xml", uni);
                return true;
            }
            catch(InvalidOperationException e)
            {
                throw new ArchivosException("Error al guardar el archivo.", e);
            }
            catch(Exception ex)
            {
                throw new ArchivosException("Error al guardar el archivo.", ex);
            }

        }

        /// <summary>
        /// Metodo para deserializar un objeto universidad desde un archivo Xml.
        /// </summary>
        /// <returns>Retorna un objeto Universidad</returns>
        public static Universidad Leer()
        {
            Universidad uni;
            try
            {
                Xml<Universidad> archivo = new Xml<Universidad>();
                bool leyo = archivo.Leer("Universidad.xml", out uni);
                return uni;
            }
            catch (InvalidOperationException e)
            {
                throw new ArchivosException("Error al leer el archivo.", e);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al leer el archivo.", ex);
            }
            
        }

        /// <summary>
        /// Metodo que muestra en un string los datos de un objeto Universidad
        /// </summary>
        /// <param name="uni">Instancia a mostrar</param>
        /// <returns>Retorna un string con los datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                if (uni.Jornadas.Count > 0)
                {
                    sb.AppendLine("JORNADA:");
                    foreach (Jornada jor in uni.Jornadas)
                    {
                        sb.AppendLine(jor.ToString());
                    }
                }
                else
                {
                    sb.AppendLine("No hay jornadas en esta universidad");
                }

                 return sb.ToString();

            } catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad nula", e);
            }
            
        }

        /// <summary>
        /// Metodo publico de instancia que muestra los datos de la Universidad en forma de string.
        /// Sobreescribe el metodo ToString().
        /// </summary>
        /// <returns>Retorna un string con los datos de la Universidad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno está en la Universidad correspondiente
        /// y false sino lo esta</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            try
            {
                foreach (Alumno aux in g.Alumnos)
                {
                    if (aux == a)
                    {
                        return true;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad, Alumnos o Alumno nula", e);
            }


            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno no está en la Universidad correspondiente
        /// y false si esta</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Retorna true si el Profesor da clases en la Universidad correspondiente
        /// y false sino</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            try
            {
                foreach (Profesor aux in g.Instructores)
                {
                    if (aux == i)
                    {
                        return true;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad, Instructores o Profesor nula", e);
            }



            return false;
        }


        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Retorna true si el Profesor no da clases en la Universidad correspondiente
        /// y false si si</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">EClases</param>
        /// <returns>Retorna una instancia de Profesor de la Universidad que de esa clase
        /// y lanza una excepcion si no hay ningun Profesor que de esa clase</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            try
            {
                foreach (Profesor profe in u.Instructores)
                {
                    if (profe == clase)
                    {
                        return profe;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                throw new SinProfesorException("Referencia a instancia de Universidad o a Instructores nula", e);
            }

            throw new SinProfesorException();
        }


        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">EClases</param>
        /// <returns>Retorna una instancia de Profesor de la Universidad que no de esa clase
        /// y lanza una excepcion si no hay ningun Profesor que no de esa clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            try 
            { 
                foreach (Profesor profe in u.Instructores)
                {
                    if (profe != clase)
                    {
                        return profe;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                throw new SinProfesorException("Referencia a instancia de Universidad nula", e);
            }

            throw new SinProfesorException("Existen profesores para esa clase. Error en sobrecarga del operador !=" +
                "se buscaban profesores que no pudieran dar la clase");
        }


        /// <summary>
        /// Sobrecarga del operador +.
        /// Si el metodo encuenta a algun Profesor de la Universidad que de esa clase agrega una
        /// Jornada a la Universidad con esa clase, con su Profesor y Alumnos correspondientes.
        /// Si no hay nadie capaz de dar la clase lanza una excepcion del tipo SinProfesorException.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns>
        /// En caso de haber podido agregar la clase retorna la instancia de Universidad con la nueva Jornada,
        /// en caso contrario lanza una excepcion.
        /// </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada jor = new Jornada(clase, (g == clase));

                foreach (Alumno al in g.Alumnos)
                {
                    if(al == jor.Clase)
                    {
                        jor.Alumnos.Add(al);
                    }
                }
                g.Jornadas.Add(jor);
                return g;
            }
            catch (SinProfesorException e)
            {
                throw new SinProfesorException("No hay docentes que den esa clase", e);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad, Jornada o lista de Alumnos nula", e);
            }

        }


        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega a un Alumno a la lista de Alumnos de la Universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumnos</param>
        /// <returns>Retorna la Univesidad con el nuevo Alumno agregado. En caso
        /// de el Alumno ya estar en la lista lanza una excepcion del tipo
        /// AlumnoRepetidoExcepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            try
            {
                foreach (Alumno al in u.Alumnos)
                {
                    if(al == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }

                u.Alumnos.Add(a);
                return u;

            } catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad, lista de Alumnos o Alumno nula", e);
            }
        }


        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega a una Profesor a la lista de Instructores de la Universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>Retorna una instancia de Universidad con el Profesor agregado a su lista
        /// de instructores.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            try
            {
                foreach (Profesor pro in u.Instructores)
                {
                    if (pro == i)
                    {
                        return u;
                    }
                }

                u.Instructores.Add(i);
                return u;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Referencia a instancia de Universidad, lista de Instructores o Profesor nula", e);
            }

        }
    }
}
