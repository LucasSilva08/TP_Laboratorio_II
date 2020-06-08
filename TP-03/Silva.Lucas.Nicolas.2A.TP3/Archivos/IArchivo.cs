using System;
using System.Collections.Generic;
using System.Text;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Guarda los Datos en un Archivo
        /// </summary>
        /// <param name="archivo">Nombre de la ubicacion</param>
        /// <param name="datos">Datos a Guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Lee los Datos de un Archivo
        /// </summary>
        /// <param name="archivo">Nombre de la Ubicacion del Archivo</param>
        /// <param name="datos">Parametro de salida donde se carga los datos del archvivo</param>
        /// <returns></returns>
        bool Leer(string archivo,out T datos);

    }
}
