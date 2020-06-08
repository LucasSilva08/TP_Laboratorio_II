using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException: Exception
    {
        /// <summary>
        /// Error si No hay Profesor en la Clase
        /// </summary>
        public SinProfesorException():base("No Hay Profesor en Clase.")
        {

        }
        
    }
}
