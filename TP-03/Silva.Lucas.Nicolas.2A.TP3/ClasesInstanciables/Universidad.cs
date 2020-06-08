using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerado
        public enum EClases
        { 
            Programacion,
            Laboratorio,
            Legislacion,
            SPD

        }

        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Porpiedades
        /// <summary>
        /// Propiedad de Escritura y Lectura de la Lista de Alumnos
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
        /// Propiedad de Escritura y Lectura de la Lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores=value;
            }
        }
        /// <summary>
        /// Propiedad de Escritura y Lectura de la Lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada=value;
            }
        }
        /// <summary>
        /// Indexador para poder Manipular la lista de jornadas
        /// </summary>
        /// <param name="i">Posicion</param>
        /// <returns>Ratorna una Jornada</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i>=0 && i<this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
                    
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto, Inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region SobreCarga Operadores
        /// <summary>
        /// Verifica si un Alumno Esta en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si esta el Alumno</returns>
        public static bool operator==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach(Alumno item in g.alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un Alumno No esta en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si No esta</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Verifica si un Profesor esta en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si esta</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach(Profesor item in g.profesores)
            {
                if(item==i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si un Profesor No esta en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True si No esta</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Verifica Si  un Profesor Puede Dar una Clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que puede dar la clase</returns>
        public static Profesor operator == (Universidad g,EClases clase)
        {

            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica que un Profesor NO puede dar la clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Primera Ocurrencia que no Pueda dar la Clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor prof = null;
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    prof = item;
                    
                }
            }
            return prof;
        }
        /// <summary>
        /// Agrega una Jornada a la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna Jornada Generada</returns>
        public  static Universidad operator +(Universidad g,EClases clase)
        { 
            Jornada jornada;
            Profesor profesor = (g == clase);
            jornada = new Jornada(clase, profesor);
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase )
                {
                    jornada += item;
                }
            }
            if(jornada.Alumnos.Count>0)
            {
                g.Jornadas.Add(jornada);
            }
            
            return g;

        }
        /// <summary>
        /// Agrega un Alumno a la universidad si es que este no se encuentra
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna Una universidad con el Alumno Agregado</returns>
        public static Universidad operator +(Universidad u,Alumno a)
        {
            if(u!=a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Agrega un Profesor a la Universidad si es que este no se encuentra en el
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Retorna Universidad con profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;



        }
        #endregion

        #region Sobre Escritura
        /// <summary>
        /// Publica Todos Los Datos de la Univeridad
        /// </summary>
        /// <returns>String de Datos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos en un archivo Xml
        /// </summary>
        /// <param name="uni">Datos a Guardar</param>
        /// <returns>True si Guardo correctamente</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", uni);
        }
        /// <summary>
        /// Lee los datos de un Archivo Xml
        /// </summary>
        /// <returns>Retorna en una Variable tipo Universidad Todos los datos</returns>
        public static Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + @"\Universidad.xml", out uni);
            return uni;

        }
        /// <summary>
        /// Muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni">Datos a Mostrar</param>
        /// <returns>String de Datos</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach(Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<-------------------------------------------------->\n");
            }
            return sb.ToString();
        }
        #endregion
    }
}
