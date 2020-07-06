using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace YaninaPerez_2doC_TP4
{
    public static class PaqueteDAO
    {
        /// <summary>
        /// Atributos para conexion Sql
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor estatico que establece los datos
        /// basicos para la conexion Sql
        /// </summary>
        static PaqueteDAO()
        {
            conexion =
                new SqlConnection(@"Server=.\SQLEXPRESS; Database=correo-sp-2017; Trusted_Connection=True;");
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }


        /// <summary>
        /// Metodo que agrega un paquete a la base de datos
        /// de paquetes
        /// </summary>
        /// <param name="p">Paquete a agregar</param>
        /// <returns>Retorna true en caso de que no haya ningun
        /// error en el proceso</returns>
        public static bool Insertar(Paquete p)
        {
            // Atributos del paquete
            string trackingId = p.TrackingID;
            string direccion = p.DireccionEntrega;

            try
            {
                // Query para la base de datos
                comando.CommandText =
                "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) " +
                "VALUES (@direccionEntrega, @trackingID, @alumno);";

                comando.Parameters.Clear();

                // Parametros a utilizar en la query
                comando.Parameters.Add(new SqlParameter("direccionEntrega", direccion));
                comando.Parameters.Add(new SqlParameter("trackingID", trackingId));
                comando.Parameters.Add(new SqlParameter("alumno", "Yanina Perez"));

                // Abro la conexion con la base
               conexion.Open();

                // Ejecuto la query
                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ingresar datos a la base de datos", ex);
            }
            finally
            {
                // Cierro la conexion si esta abierta
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
