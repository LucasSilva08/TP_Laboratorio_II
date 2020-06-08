using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException: Exception
    {
        /// <summary>
        /// Error si el Alumno esta repetido
        /// </summary>
        public AlumnoRepetidoException():base("Alumno Repetido.")
        {

        }
    }
}
