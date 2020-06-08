using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Error si Hay un Error en el Guardado o Lectura de los Archivos
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException):base("Error en Archivos",innerException)
        {

        }
    }
}
