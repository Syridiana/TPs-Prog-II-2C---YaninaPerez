using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// La clase Texto implementa la interfaz IArchivos
    /// </summary>
    public class Texto : IArchivo<string> 
    {
        /// <summary>
        /// Constructor sin argumentos de Texto.
        /// </summary>
        public Texto()
        {

        }

        /// <summary>
        /// Metodo que guarda los datos pasados en formato de archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna true en caso de haberse guardado correctamente. En caso de error
        /// maneja diferentes tipos de excepciones y lanza una excepcion de tipo ArchivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                    return true;
                }
            }
            catch (IOException e)
            {
                throw new ArchivosException("Error al guardar el archivo de texto.", e);
            }
            catch (ObjectDisposedException ej)
            {
                throw new ArchivosException("Error al guardar el archivo de texto.", ej);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al guardar el archivo de texto.", ex);
            }
        }

        /// <summary>
        /// Metodo que lee un archivo de texto y lo carga en el la variable de tipo string pasada
        /// por parametro.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Variable donde almacenar el texto leido</param>
        /// <returns>Retorna true en caso de haberse leido correctamente. En caso de error
        /// maneja diferentes tipos de excepciones y lanza una excepcion de tipo ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = reader.ReadToEnd();
                    return true;
                }
            }
            catch (IOException e)
            {
                throw new ArchivosException("Error al leer el archivo de texto.", e);
            }
            catch (ObjectDisposedException ej)
            {
                throw new ArchivosException("Error al leer el archivo de texto.", ej);
            }
            catch (Exception ex)
            {
                throw new ArchivosException("Error al leer el archivo de texto.", ex);
            }

        }

    }
}
