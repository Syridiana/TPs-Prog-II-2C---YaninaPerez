using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YaninaPerez_2doC_TP4
{
    /// <summary>
    /// Interface para mostrar string de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMostrar<T>
    {
        string MostrarDatos(IMostrar<T> elemento);

    }
}
