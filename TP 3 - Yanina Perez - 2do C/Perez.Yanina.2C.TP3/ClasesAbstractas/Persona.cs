using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;



namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Atributos privados de Persona
        /// </summary>
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// Enumerado de ENacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        
        /// <summary>
        /// Constructor por defecto que no recibe parametros.
        /// </summary>
        public Persona()
        {

        }


        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre =  nombre;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="dni">Atributo de tipo int</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : 
            this(nombre, apellido, nacionalidad)
            //Llama a otro constructor de la clase
        {
            this.DNI = dni;
        }


        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">Atributo de tipo string</param>
        /// <param name="apellido">Atributo de tipo string</param>
        /// <param name="dni">Atributo de tipo string</param>
        /// <param name="nacionalidad">Atributo de tipo ENacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : 
            this(nombre, apellido, nacionalidad)
        //Llama a otro constructor de la clase
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                //Validacion del nombre y que no sea una variable vacia
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                //Validacion del nombre y que no sea una variable vacia
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que setea y devuelve el atributo dni.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                //Valido el valor pasado con el metodo ValidarDni
                  this.dni = this.ValidarDni(this.Nacionalidad, value);
                
            }
        }


        /// <summary>
        /// Propiedad que setea el atributo dni en caso de ser de tipo string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                   //Valido el valor pasado con el metodo ValidarDni
                   int numero = this.ValidarDni(this.Nacionalidad, value);
                   this.dni = this.ValidarDni(this.Nacionalidad, numero);
                
            }
        }

        /// <summary>
        /// Sobreecribe el metodo ToString. 
        /// </summary>
        /// <returns>Devuelve un string con los datos de la persona.</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder info = new StringBuilder();
                info.AppendLine(String.Format("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre));
                info.AppendLine(String.Format("NACIONALIDAD: {0}", this.Nacionalidad));

                return info.ToString();
            } 
            catch(ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Error en el metodo ToString, no se pudieron interpretar" +
                    "los datos", e);
            }
            catch (Exception e)
            {
                throw new Exception("Error en el metodo ToString, no se pudieron interpretar los datos", e);
            }

        }

        /// <summary>
        /// Metodo que valida un dni. Valida que el numero este dentro del rango permitido
        /// y que se corresponda con la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Parametro de nacionalidad</param>
        /// <param name="dato">Parametro del dni a validar</param>
        /// <returns>Devuelve el numero pasado como dni en caso de que sea validado
        /// correctamente. En caso contrario lanza una excepcion del tipo NacionalidadInvalidaException
        /// o del tipo DniInvalidoExcepcion segun corresponda</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            /*if (dato <= 99999999)
            {*/
            if (dato > 0 && dato < 90000000)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else if (dato >= 90000000 && dato <= 99999999)
            {
                if (nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException("Formato de DNI incorrecto; no debe tener mas de 8 digitos ni ser" +
                    "un numero negativo");
            }
        }


        /// <summary>
        /// Sobrecarga del metodo que valida un dni. Valida que el valor sera numerico, que este dentro 
        /// del rango permitido y que se corresponda con la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">Dni a validar, de tipo string</param>
        /// <returns>Retorna el dato validado como un int, en caso de error lanza
        /// las Excepciones que correspondan</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int validar;

            if(int.TryParse(dato, out validar))
            {
                try
                {
                    //Este metodo reutiliza ValidarDni(ENacionalidad, int)
                    return this.ValidarDni(nacionalidad, validar);
                } 
                catch (NacionalidadInvalidaException e)
                {
                    throw e;
                } 
                catch (DniInvalidoException e)
                {
                    throw e;
                }
            } else
            {
                throw new DniInvalidoException("Error. Formato de dni no numerico.");
            }
        }


        /// <summary>
        /// Metodo que valida que los datos ingresados para nombre y apellido sean solo
        /// de tipo texto o espacios en blanco.
        /// </summary>
        /// <param name="dato">String a validar</param>
        /// <returns>En caso de ser del formato correcto retorna el dato pasado
        /// por parametro, en caso de ser incorrecto retorna una string vacio</returns>
        private string ValidarNombreApellido(string dato)
        {
            //Regex que valida que todos los caracteres sean letras o espacios en blanco
            if(Regex.IsMatch(dato, @"[a-zA-ZñÑ\s]"))                            
            {
                return dato;
            } else
            {
                return String.Empty;
            }
        }
            
    }
}
