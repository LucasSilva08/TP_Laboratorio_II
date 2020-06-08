using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Por defecto de Alumno
        /// </summary>
        public Alumno ()
        {

        }
        /// <summary>
        /// Constructor Parametrizado de Alumos 
        /// </summary>
        /// <param name="id">Id del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad"> Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el ALumno</param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor Parametrizado de Alumos pero con el Atributo del DNI String mas el estado de cuenta
        /// </summary>
        /// <param name="id">Id del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno tipo String</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el ALumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra la Clase que Toma el Alumno
        /// </summary>
        /// <returns>String de la Clase que toma</returns>
        protected override string ParticiparEnClases()
        {
            return String.Format("\nTOMA CLASES DE {0}",this.claseQueToma);
        }
        /// <summary>
        /// Muestra los Datos del Alumno
        /// </summary>
        /// <returns>String de los Datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            string estado = estadoCuenta.ToString();
            if(this.estadoCuenta==EEstadoCuenta.AlDia)
            {
                estado = "Cuota al Dia";
            }
            return String.Format("\n{0}\nESTADO DE CUENTA: {1}{2}", base.MostrarDatos(), estado, this.ParticiparEnClases());
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// SobreCarga del Operador ==, El Alumno sera igual a la clase cuando este la tome y su estado no sea Deudor
        /// </summary>
        /// <param name="a">Alumno </param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma==clase && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Sobre Carga del !=, el Alumno sera disinto de la clase cuando este NO la tome
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
        /// <summary>
        /// Publica los datos del Alumno
        /// </summary>
        /// <returns>String de los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
