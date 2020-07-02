using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        private void paq_InformarEstado(object sender,EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            //p.InformarEstado += paq_InformarEstado;
            p.InformarEstado += new Paquete.DelegadoEstado(this.paq_InformarEstado);
            try
            {
                this.correo += p;
            }
            catch(TrackingIdRepetidoException exp)
            {
                MessageBox.Show(exp.Message);
            }
            this.ActualizarEstado();
        }
        /// <summary>
        /// método ActualizarEstados limpiará los 3 ListBox y luego recorrerá la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstado()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach(Paquete p in this.correo.Paquetes)
            {
                switch(p.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(p);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// llamar al método FinEntregas a fin de cerrar todos los hilos abiertos.
        /// </summary>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            try
            {
                if (!(Object.Equals(elemento, null)))
                {
                    
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    this.rtbMostrar.Text.Guardar("salida.txt");
                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
