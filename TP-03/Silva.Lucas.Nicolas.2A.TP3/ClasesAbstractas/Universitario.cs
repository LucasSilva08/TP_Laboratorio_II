using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario()
        {

        }
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los Datos 
        /// </summary>
        /// <returns>String de Datos</returns>
        protected virtual string MostrarDatos()
        {
            return String.Format("{0}\n\nLEGAJO NUMERO: {1}\n", base.ToString(), this.legajo);
        }
        protected abstract string ParticiparEnClases();
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica si dos Universitaros son iguales respecto a sus Legajos y DNI
        /// </summary>
        /// <param name="pg1">Primer Universitario</param>
        /// <param name="pg2">Segundo Universitario</param>
        /// <returns>True si Son iguales</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            bool retorno = false;
            if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                retorno = true;

            }
            return retorno;
        }
        /// <summary>
        /// Verifica si los universitarios son distintos
        /// </summary>
        /// <param name="pg1">Primer Universitario</param>
        /// <param name="pg2">Segundo Universitario</param>
        /// <returns>True si son Distintos</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// SobreCarga del Operador Equals para verificar si son iguales los Universitarios
        /// </summary>
        /// <param name="obj">Universitario</param>
        /// <returns>True si son Iguales</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == ((Universitario)obj))
                {
                    retorno = true;
                }
            }
            
            return retorno;
        }
        #endregion

    }
}
