using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.conexion);
            comando = new SqlCommand();

        }
        #endregion

        #region Metodo
        /// <summary>
        /// Guarda paquete en la base de datos
        /// </summary>
        /// <param name="p">Objeto a insertar</param>
        /// <returns>True si se pudo insertar, en caso contrario false</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
                PaqueteDAO.comando.CommandText = String.Format("INSERT INTO Paquetes values('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Silva, Lucas");
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }
            return retorno;
            
        }
        #endregion


    }
}
