using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Guarda archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>True si se pudo guardar, false en caso contraio</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo,true))
                {
                    sw.WriteLine(texto);

                }

                retorno = true;
            }
            catch(Exception)
            {

            }
            return retorno;
        }
    }
}
