using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Excepciones; 

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los Datos en un Archivo Xml
        /// </summary>
        /// <param name="archivo">Ubicacion del Archivo</param>
        /// <param name="datos">Datos a Guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    XmlSerializer miXml = new XmlSerializer(typeof(T));
                    miXml.Serialize(sw, datos);
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
        /// Lee los Datos de un Archivo Xml
        /// </summary>
        /// <param name="archivo">Ubicacion del Archivo</param>
        /// <param name="datos">Parametro de salida Donde se Guardan Los datos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    XmlSerializer miXml = new XmlSerializer(typeof(T));
                    datos=(T)miXml.Deserialize(sr);
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
