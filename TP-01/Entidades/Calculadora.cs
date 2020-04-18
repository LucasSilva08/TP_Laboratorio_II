using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Opera entre dos datos tipo Numero de acuerdo al operador pasado
        /// </summary>
        /// <param name="num1">Primer Numero</param>
        /// <param name="num2">Segundo Numero</param>
        /// <param name="operador">Operador selecionado</param>
        /// <returns></returns>Retorna el resultado de la operacion
        public static double Operar(Numero num1,Numero num2, string operador)
        {
            double operacion=0;
            switch(ValidarOperador(operador))
            {
                case "+":
                    operacion = (num1 + num2);
                    break;
                case "-":
                    operacion = (num1 - num2);
                    break;
                case "*":
                    operacion = (num1 * num2);
                    break;
                case "/":
                    operacion = (num1 / num2);
                    break;
                default:
                    break;
            }
            return operacion;   
        }
        /// <summary>
        /// Valida el Operador pasado como Parametro
        /// </summary>
        /// <param name="operador">Parametro string pasado</param>
        /// <returns></returns>retorna el operador Validado sino un +
        private static string ValidarOperador (string operador)
        {
            string retorno = "+";

            if(operador == "+"||operador=="-"||operador=="/"||operador=="*")
            {
                retorno = operador;
            }
            return retorno;
        }
    }
}
