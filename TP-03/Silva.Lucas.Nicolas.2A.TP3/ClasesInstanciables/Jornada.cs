using System;
using System.Collections.Generic;
using System.Text;
using Archivos;
using Excepciones;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #region Propiedades
        /// <summary>
        /// Propiedad de Lectura y Escritura de una lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos=value;
            }
        }
        /// <summary>
        /// Propiedad de Escritura y Lectura de la Clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase=value;
            }
        }
        /// <summary>
        /// Propiedad de Lectura y Escritura de Profesores
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor=value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Por defecto de Jornada e inicializa la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Cosntructor Parametrizado de Jornada
        /// </summary>
        /// <param name="clase">La Clase</param>
        /// <param name="instructor">Profesor</param>
        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga al Operador ==, Verifica si el Alumno pertenece a la Jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            bool retorno = false;
            foreach(Alumno item in j.alumnos)
            {
                if(item==a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si el ALumno no esta en la Jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un Alumno a la Jornada si es que este no Pertenece a la misma
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a Agregar</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j!=a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        /// <summary>
        /// Publica Los Datos de la Jornada
        /// </summary>
        /// <returns>String de Datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("CLASES DE {0} POR {1}\n", this.clase, ((Persona)this.instructor).ToString());
            
            sb.Append("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los Datos de la Jornada en un Archivo txt
        /// </summary>
        /// <param name="jornada">Datos a Guardar</param>
        /// <returns>si se Pudo Guardar retorna TRUE</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            return txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee los Datos de un Archivo txt
        /// </summary>
        /// <returns>Retorna un String con los Datos</returns>
        public static string Leer()
        {

            Texto txt = new Texto();
            string texto;
            txt.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Jornada.txt", out texto);
            return texto;
        }

        #endregion

    }
}
