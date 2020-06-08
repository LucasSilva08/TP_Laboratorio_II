using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        /// <summary>
        /// Error si el Dni es Invalido
        /// </summary>
        public DniInvalidoException ():this("Formato de DNI invalido")
        {

        }
        /// <summary>
        /// Error si el Dni es Invalido
        /// </summary>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(Exception e):base("Formato de DNI invalido",e)
        {

        }
        /// <summary>
        /// Error si el Dni es Invalido
        /// </summary>
        /// <param name="message">Mensaje</param>
        public DniInvalidoException(string message):base(message)
        {

        }
        /// <summary>
        /// Error si el Dni es Invalido
        /// </summary>
        /// <param name="messege">Mensaje</param>
        /// <param name="e">Excepcion</param>
        public DniInvalidoException(string messege, Exception e):base(messege,e)
        {
            this.mensajeBase = messege;
        }
    }
}
