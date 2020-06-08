using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        
        /// <summary>
        /// Error si la Nacionalidad no coincide con el DNI
        /// </summary>
        public NacionalidadInvalidaException() : this("La Nacionalidad No se condice con El Numero de DNI.")
        {

        }
        /// <summary>
        /// Error si la Nacionalidad no coincide con el DNI
        /// </summary>
        /// <param name="message">Mensaje</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }

    }
}
