using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor de Clase, inicializa el Atributo Random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor que inicializa la lista de la clase y adhiere clases
        /// </summary>
        public Profesor():base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id">Id del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">Dni del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que agrega a la lista clases aleatoriamente
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }
        /// <summary>
        /// Muestra Los Datos de la Clase en la que Participa
        /// </summary>
        /// <returns>String de Datos</returns>
        protected override string ParticiparEnClases()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DEL DIA: ");
            foreach(Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Muestra Los datos del Profesor
        /// </summary>
        /// <returns>String de Datos</returns>
        protected override string MostrarDatos()
        {
            return (base.MostrarDatos() + this.ParticiparEnClases());
        }

        #endregion

        #region SobreCargas
        /// <summary>
        /// Verifica Si un Profesor da una Clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a Corroborar</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            bool retorno = false;
            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if(item==clase)
                {
                    retorno = true;
                    
                }
            }
            return retorno;
        }
        /// <summary>
        /// Verifica si el Profesor No da la Clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Publica todos los Datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
