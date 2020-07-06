using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YaninaPerez_2doC_TP4
{
    public static class GuardaString
    {

        /// <summary>
        /// Metodo de extension de la clase string para guardar en un archivo .txt
        /// en el escritorio 
        /// </summary>
        /// <param name="texto">Clase extendida</param>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <returns></returns>
       public static bool Guardar(this string texto, string archivo)
        {
            // Defino ruta segun parametro y segun ruta de la PC donde se guardara el archivo
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            rutaArchivo = $"{rutaArchivo}\\{archivo}.txt";

                try
                {
                    // Si la ruta existe agrego informacion al archivo
                    if (File.Exists(rutaArchivo))
                    {
                        using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                        {
                            writer.WriteLine(texto);
                            return true;
                        }
                    }
                    else
                    {
                        // Si la ruta no existe creo el archivo y guardo la informacion
                        using (StreamWriter writer = new StreamWriter(rutaArchivo))
                        {
                            writer.WriteLine(texto);
                            return true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar el archivo de texto", ex);
                }
            
        }
    }
}
