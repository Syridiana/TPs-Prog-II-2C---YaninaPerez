using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace YaninaPerez_2doC_TP4
{
    public class Correo : IMostrar<List<Paquete>>
    {
        /// <summary>
        /// Lista de Paquete y de Thread
        /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Constructor sin parametros que instancia
        /// ambas listas
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }


        /// <summary>
        /// Propiedad que retorna la lista de paquetes
        /// y la setea en caso de no ser el value nulo
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                if(!(value is null))
                {
                    this.paquetes = value;
                }

            }
        }


        /// <summary>
        /// Metodo que aborta todos los hilos
        /// abiertos de la lista de hilos
        /// </summary>
        public void FinEntregas()
        {
            // Chequeo que la lista no sea nula
            if(!(this.mockPaquetes is null))
            {
                // Recorro la lista de hilos y en caso de estar
                // activos los aborto
                foreach (Thread hilo in this.mockPaquetes)
                {
                    if (hilo.IsAlive)
                    {
                        hilo.Abort();
                    }
                }
            }

        }


        /// <summary>
        /// Metodo que muestra los datos de todos los paquetes
        /// de la lista de paquetes del correo
        /// </summary>
        /// <param name="elementos">Recibe un objeto que
        /// implementa la interfaz IMostrar<T></param>
        /// <returns>Retorna un string con los datos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Si el parametro del tipo correo recorro su lista de paquetes
                if (elementos is Correo)
                {
                    // Casteo el parametro al tipo correo para poder
                    // recorrer su lista de paquetes
                    foreach (Paquete p in ((Correo)elementos).Paquetes)
                    {
                        sb.AppendLine(String.Format("{0} para {1} ({2})", p.TrackingID,
                            p.DireccionEntrega, p.Estado));
                    }

                }

                return sb.ToString();
            } 
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Error de referencia nula", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al mostrar los datos", ex);
            }

        }


        /// <summary>
        /// Sobrecarga del operador + para cargar un
        /// paquete a la lista de paquetes del correo
        /// </summary>
        /// <param name="c">Instancia de Correo donde cargar los paquetes</param>
        /// <param name="p">Paquete a cargar</param>
        /// <returns>Retorna un objeto Correo con el nuevo paquete
        /// en caso de haberlo podido cargar o sin el en caso contrario</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            // Chequeo que las instancias no sean nulas
            if(!(c is null) && !(p is null) && !(c.Paquetes is null))
            {
                // Recorro la lista de paquetes
                foreach (Paquete paquete in c.Paquetes)
                {
                    // Si el paquete es igual a uno existente no lo cargo y lanzo una excepcion
                    if(paquete == p)
                    {
                        throw new TrackingIdRepetidoException("Tracking Id ya esxiste");
                    }
                }

                // Si el paquete no existe en la lista de paquetes lo cargo a la lista
                c.Paquetes.Add(p);

                // Instancio el hilo que simula el ciclo de vida del paquete
                Thread hilo = new Thread(new ThreadStart(p.MockCicloDeVida));

                // Lo agrego a la lista de hilos
                c.mockPaquetes.Add(hilo);

                // Inicio el hilo
                hilo.Start();
            }

            // Retorno el correo
            return c;
        }
    }
}
