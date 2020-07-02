using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedad
        /// <summary>
        /// Propiedad lectura y escritura de Paquete
        /// </summary>
        public List<Paquete> Paquetes { get {return this.paquetes; } set {this.paquetes=value; } }

        #endregion

        #region Constructor
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        #endregion

        #region Sobrecarga
        /// <summary>
        /// Controlar si el paquete ya está en la lista.En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        ///De no estar repetido, agregar el paquete a la lista de paquetes.
        ///Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
        ///Ejecuta  el hilo.
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete item in c.paquetes)
            {
                if(item==p)
                {
                    throw new TrackingIdRepetidoException(String.Format("El Tracking {0} ya figura en la lista de envios", p.TrackingID));
                }
            }
            c.paquetes.Add(p);
            Thread h = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(h);
            h.Start();
            return c;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los paquetes de un correo
        /// </summary>
        /// <param name="elemento"> Elemento</param>
        /// <returns> String con datos de los paquetes </returns>
        public string MostrarDatos(IMostrar <List<Paquete>> elementos)
        {
            string cadena = "";
            foreach (Paquete p in ((Correo)elementos).paquetes)
            {
                cadena += String.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return cadena;
        }
        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread h in this.mockPaquetes)
            {
                h.Abort();
            }
        }
        #endregion
    }
}
