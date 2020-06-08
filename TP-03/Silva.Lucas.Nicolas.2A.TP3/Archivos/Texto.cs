using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los Datos en un Archivo de Texto
        /// </summary>
        /// <param name="archivo">Ubicacion del Archivo</param>
        /// <param name="datos">Datos a Guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(datos);
                    retorno = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Lee los Datos de un Aarchivo de Texto
        /// </summary>
        /// <param name="archivo">Ubicacion del Archivo</param>
        /// <param name="datos">Parametro de salida donde se carga los datos del archvivo</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    retorno = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
            
        }
    }
}
