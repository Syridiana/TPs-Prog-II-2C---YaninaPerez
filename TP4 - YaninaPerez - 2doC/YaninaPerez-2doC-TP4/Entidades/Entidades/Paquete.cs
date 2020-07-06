using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YaninaPerez_2doC_TP4
{
    public class Paquete : IMostrar<Paquete>
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }


        /// <summary>
        /// Delegados y eventos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public static event DelegadoEstado InformaEstado;


        public delegate void DelegadoErrorDAO();
        public static event DelegadoErrorDAO InformaErrorDAO;


        /// <summary>
        /// Constructor de la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {

            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.estado = EEstado.Ingresado;

        }


        /// <summary>
        /// Propiedad que retorna y setea el atributo de direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                // Chequeo que la direccion no sea un string vacio
                if(!String.IsNullOrEmpty(value))
                {
                    this.direccionEntrega = value;
                }
                else
                {
                    throw new Exception("Debe cargar alguna direccion");
                }
            }
        }


        /// <summary>
        /// Propiedad que retorna y setea el atributo de estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }


        /// <summary>
        /// Propiedad que retorna y setea el atributo de trackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                // Chequeo formato del ID
                if(value[3] == '-' && value[7] == '-' && value.Length == 12)
                {
                    this.trackingID = value;
                } else
                {
                    throw new Exception("Formato de Id no valido");
                }

            }
        }


        /// <summary>
        /// Metodo que se ejecutara al iniciar el hilo 
        /// correspondiente a cada paquete. Simulara el ciclo
        /// de vida del paquete actualizando su estado cada 4 segundos
        /// y finalmente guardando sus datos en la base de datos una vez
        /// entregado
        /// </summary>
        public void MockCicloDeVida()
        {
            try
            {
                // Mientras el estado no sea Entregado continuo
                // actualizando el estado cada 4 segundo e invocando
                // InformaEstado
                while (this.Estado != EEstado.Entregado)
                {
                    Thread.Sleep(4000);
                    this.Estado = (EEstado)(((int)this.Estado) + 1);
                    InformaEstado.Invoke(this, EventArgs.Empty);
                }

                // Una vez que el paquete fue entregado se guarda en la base de datos
                PaqueteDAO.Insertar(this);
            }
            catch (ThreadAbortException ex)
            {
                string excepcion = $"{ex.Message} // {ex.StackTrace}";
                excepcion.Guardar("Log de Excepciones");
            }
            // Si ocurrio un error guardando el paquete en la base de datos invoco
            // un evento que avisa de este error
            catch (Exception ex)
            {
                InformaErrorDAO.Invoke();
            }


        }


        /// <summary>
        /// Metodo para mostrar datos de Paquete implementando interfaz IMostrar
        /// </summary>
        /// <param name="elemento">Instancia de la cual mostrar los datos</param>
        /// <returns>Retorna un string con los datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string datos = "";

            // Chequeo que la instancia no sea nula
            if (!(elemento is null))
            {
                // Chequeo el tipo de dato
                if (elemento is Paquete)
                {
                    // Casteo y armo el string para mostrar los datos;
                    datos = String.Format("{0} para {1}",
                    ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
                }
            }

            return datos;
        }

        /// <summary>
        /// Sobreescribo el metodo ToString para mostrar correctamente los
        /// datos en la pantalla del formulario
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string datos = "";

            if(!(this is null))
            {
                datos = String.Format("{0} para {1}",
                    this.TrackingID, this.DireccionEntrega);
            }

            return datos;
        }


        /// <summary>
        /// Sobrecarga del operador ==. Compara dos paquetes
        /// por su trackingID
        /// </summary>
        /// <param name="p1">Paquete 1 a comparar</param>
        /// <param name="p2">Paquete 2 a comparar</param>
        /// <returns>Retorna true si las instancias no son nulas
        /// y tienen el mismo trackingID y false en caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(!(p1 is null) && !(p2 is null))
            {
                if(p1.TrackingID == p2.TrackingID)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=. Compara dos paquetes
        /// por su trackingID
        /// </summary>
        /// <param name="p1">Paquete 1 a comparar</param>
        /// <param name="p2">Paquete 2 a comparar</param>
        /// <returns>Retorna false si las instancias no son nulas
        /// y tienen el mismo trackingID y true en caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
