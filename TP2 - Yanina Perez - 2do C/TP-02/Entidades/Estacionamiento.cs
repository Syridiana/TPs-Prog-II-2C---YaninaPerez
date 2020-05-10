using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento // Agrego el modificador sealed para que no pueda tener clases heredadas
    {
        private List<Vehiculo> vehiculos; // Agrego el modificar private de forma explicita
        private int espacioDisponible;
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Constructor de la clase Estacionamiento que inicializa la lista de vehiculos
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor de la clase Estacionamiento que carga el espacio disponible e inicializa la lista de vehiculos
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Estacionamiento(int espacioDisponible) : this() //Agrego llamada al constructor sin parámetros que inicializa la lista
        {                                                       // de vehiculos.
            this.espacioDisponible = espacioDisponible;
        }
        #endregion
        

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString() //Agrego el modificador override ya que se trata de una sobrecarga del metodo ToString
        {
            return Estacionamiento.Mostrar(this, ETipo.Todos);  //Reutilizo el metodo Mostrar
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve un string con los datos</returns>
        public static string Mostrar(Estacionamiento c, ETipo tipo) // El metodo sera estatico segun los requerido
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.vehiculos.Count, c.espacioDisponible);
            sb.AppendLine("");
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Camioneta:
                            if(v.GetType().Name == tipo.ToString()) // Agrego sentencia condicional para que solo muestre del tipo buscado
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                        break;
                    case ETipo.Moto:

                        if (v.GetType().Name == tipo.ToString())
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if (v.GetType().Name == tipo.ToString())
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar()); // Este es el caso de que el tipo seleccionado sea "Todos"
                        break;
                }
            }

            return sb.ToString(); // Debo devolver un tipo string
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Devuelve el estacionamiento con el elemento agregado si se agrego o sin el</returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
            if(c.espacioDisponible > c.vehiculos.Count()) // Verifico que haya espacio suficiente para el vehiculo nuevo
            {
                foreach (Vehiculo v in c.vehiculos) // Agrego la referencia a la lista de vehiculos del estacionamiento
                {
                    if (v == p) // Si el elemento ya se encuentra en la lista no lo agrego
                        return c;
                }

                c.vehiculos.Add(p); // Si no se encuentra lo agrego
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Devuelve el estacionamiento con el elemento retirado si se encontro la lista o tal como estaba</returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            foreach (Vehiculo v in c.vehiculos) // Agrego la referencia a la lista de vehiculos del estacionamiento
            {
                if (v == p)
                {
                    c.vehiculos.Remove(v); // Saco el elemento de la lista si lo encuentro
                    return c; // Retorno el estacionamiento sin el elemento
                }
            }

            return c; // Si el elemento no pertenecia a la lista retorno el estacionamiento como estaba
        }
        #endregion
    }
}
