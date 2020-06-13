using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interface de archivos. Su implementación permite leer y guardar archivos
    /// </summary>
    /// <typeparam name="T">Parámetro genérico</typeparam>
    public interface IArchivo<T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
