using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YaninaPerez_2doC_TP4
{
    public partial class FrmPpal : Form
    {

        /// <summary>
        /// Atributos
        /// </summary>
        private Correo correo;


        /// <summary>
        /// Constructor
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Al cargar el formulario instancio el atributo de correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {

            correo = new Correo();

            // Asigno manejador del evento de error al guardar datos en la base
            // de datos
            Paquete.InformaErrorDAO += MuestraMensajeErrorDAOPaquetes;

        }


        /// <summary>
        /// Metodo que actualiza datos del paquete en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            // Si es necesario un invoke se realiza
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                // Ejecuto el metodo de ActualizarEstados
                ActualizarEstados();
            }   
        }


        /// <summary>
        /// Actualiza en pantalla los datos de los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            if(!(correo.Paquetes is null))
            {
                foreach (Paquete paquete in correo.Paquetes)
                {
                    switch (paquete.Estado)
                    {
                        case Paquete.EEstado.Entregado:
                            lstEstadoEntregado.Items.Add(paquete);
                            break;

                        case Paquete.EEstado.EnViaje:
                            lstEstadoEnViaje.Items.Add(paquete);
                            break;

                        case Paquete.EEstado.Ingresado:
                            lstEstadoIngresado.Items.Add(paquete);
                            break;
                    }
                }
            }
        }


       
       
        /// <summary>
        /// Metodo que se ejecuta al hacer click en el boton agregar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                // Creo la instancia de Paquete con los datos
                Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

                // Agrego el paquete a la lista del correo
                correo += paquete;

                // Asigno manejador al evento InformaEstado
                Paquete.InformaEstado += paq_InformaEstado;

                // Actualizo datos del formulario
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show("Error Tracking Id repetido", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Al hacer click en el boton Mostrar Todos
        /// muestro en pantalla los datos de todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Metodo para mostrar informacion 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            try
            {
                // Chequeo que el elemento no sea nulo
                if (!(elemento is null))
                {
                    // Cargo los datos en pantalla
                    string datos = elemento.MostrarDatos((IMostrar<T>)elemento);
                    rtbMostrar.Text = datos;

                    // Guardo datos en archivo de texto
                    datos.Guardar("salida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Muestro datos del elemento de la lista Entregado
        /// que haya sido seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        /// <summary>
        /// Metodo que mostrara un mensaje de error.
        /// Es un manejador de un evento.
        /// </summary>
        private void MuestraMensajeErrorDAOPaquetes()
        {
            MessageBox.Show("Error al guardar los datos del Paquete en la base de datos", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Al cerrarse el formulario ejecuto el metodo FinEntregas
        /// para abortar todos los hilos abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

       

    }
}
