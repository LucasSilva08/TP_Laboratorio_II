using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;


        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica si el Numero de DNi pertenece a la Nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>retorna el numero de Dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }
            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }

            }
            return retorno;


        }
        /// <summary>
        /// Verifica que el DNi no se pase de Rango
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI</param>
        /// <returns>DNI Valido</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int retorno = -1;
            if (dato.Length >= 1 && dato.Length <= 8 && (Int32.TryParse(dato, out dni)))
            {
                retorno = ValidarDni(nacionalidad, dni);

            }
            else
            {
                throw new DniInvalidoException();
            }
            return retorno;
            
        }
        /// <summary>
        /// Verifica que sea un Nombre y Apellido Valido
        /// </summary>
        /// <param name="dato">Dato</param>
        /// <returns>Dato valido</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            string retorno = "Nombre Invalido";
            foreach(char item in dato)
            {
                if(!(char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }
            if(flag==true)
            {
                retorno = dato;
            }
            return retorno;
        }
        /// <summary>
        /// Publica todos los datos de la Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}", this.Apellido, this.Nombre, this.nacionalidad);
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propieda de Lectura y Escritura del Apellido, Valida el Dato en el Set
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido=ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propieda de Lectura y Escritura del Nombre, Valida el Dato en el Set
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propieda de Lectura y Escritura de la Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad=value;
            }
        }

        /// <summary>
        /// Propieda de Lectura y Escritura del DNI, Valida el Dato en el Set
        /// </summary>
        public int DNI
        {
            get
            {
               return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad,value);
            }
        }
        /// <summary>
        /// Propiedad para q valida un DNI tipo String 
        /// </summary>
        public string StringToDNI
        {
            set
            {
               
               this.dni=ValidarDni(this.Nacionalidad,value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
    }
}
