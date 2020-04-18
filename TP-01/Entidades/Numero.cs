using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad que Settea el numero por un valor valido
        /// </summary>
        public string SetNumero
        { set
            {
                this.numero=ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor Por defecto inicializado en 0
        /// </summary>
        public Numero ():this(0)
        {

        }
        /// <summary>
        /// Constructor inicializado con un valor double
        /// </summary>
        /// <param name="numero">Parametro double </param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor inicializado con un valor string
        /// </summary>
        /// <param name="strnumero">Parametro String</param>
        public Numero(string strnumero)
        {
            SetNumero = strnumero;
               
        }
        /// <summary>
        /// Verifica que el valor sea numerico
        /// </summary>
        /// <param name="strNumero">Parametro tipo String</param>
        /// <returns></returns>retorna un Valor double si es numerico - retorno 0 si no lo es
        private double ValidarNumero(string strNumero)
        {
            double retorno;
            Double.TryParse(strNumero, out retorno); //Convierto la cadena en el valor numerico que corresponta, si tuvo exito devuelve el numero sino devuelve 0
            return retorno;

        }
        /// <summary>
        /// Convierte el numrero Binario a Decimal
        /// </summary>
        /// <param name="binario"> Parametro tipo String </param>
        /// <returns></returns> retorna valor numerico en String - sino Devuelve valor invalido
        public string BinarioDecimal(string binario)
        {
            int exponente = binario.Length - 1;
            int numero=0;
            string retorno = "Valor Invalido";
            int i;

            for (i = 0; i < binario.Length; i++)
            {
                if (int.Parse(binario.Substring(i, 1)) == 1)
                {
                    numero = numero + int.Parse(Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                    retorno = numero.ToString();
                }
                exponente--;
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un Numero decimal tipo Double a binario
        /// </summary>
        /// <param name="numero">Parametro tipo Double</param>
        /// <returns></returns> retorna el numero binario en string
        public string DecimalBinario(double numero)
        {
            
            return DecimalBinario(numero.ToString());
        }
        /// <summary>
        /// Convierte un Numero decimal tipo string a binario
        /// </summary>
        /// <param name="numero">parametro string</param>
        /// <returns></returns> retorna el numero binario en string
        public string DecimalBinario(string numero)
        {
            string cadena = "";
            
            int num = (int)(double.Parse(numero));
            if (num > 0)
            {
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        
                        cadena = "1" + cadena;
                    }
                    num = (int)(num / 2);
                }
            }
            else if (num == 0)
            {
                cadena = "0";
            }
            else
            {
                cadena = "Valor Invalido";
            }
            return cadena;
        }
        /// <summary>
        /// Sobrecarga al operador - para realizar la suma entre dos datos tipos Numero
        /// </summary>
        /// <param name="n1">Primer Numero</param>
        /// <param name="n2">Segundo Numero</param>
        /// <returns></returns> Retorna el resultado de la operacion
        public static double operator -(Numero n1,Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobregarga al operador * a realizar entre dos datos tipo Numero
        /// </summary>
        /// <param name="n1">Primer Numero</param>
        /// <param name="n2">Segundo Numero</param>
        /// <returns></returns>Retorna el resultado de la operacion
        public static double operator *(Numero n1,Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga al operador / a realizar entre dos datos tipo Numero
        /// </summary>
        /// <param name="n1">Priemer Numero</param>
        /// <param name="n2">Segundo Numero</param>
        /// <returns></returns>Retorna el resultado de la operacion si el segundo numero es !=0 sino devuelve double.MinValue
        public static double operator /(Numero n1,Numero n2)
        {
            double retorno = 0;
            if(n2.numero==0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga el operador + al realizar entre dos datos tipo Numero
        /// </summary>
        /// <param name="n1">Primer Numero</param>
        /// <param name="n2">Segundo Numero</param>
        /// <returns></returns>Retorna el resultado de la operacion
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
    
}
