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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            btnContervirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContervirABinario_Click(object sender, EventArgs e)
        {
            Numero miNumero = new Numero();
            lblResultado.Text = miNumero.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnContervirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero miNumero = new Numero();
            lblResultado.Text = miNumero.BinarioDecimal(lblResultado.Text);
            btnContervirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        /// <summary>
        /// Metodo para Limpiar los TexBox, el comboBox y el lebel
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNum1.Text = "";
            txtNum2.Text = "";
            cmbOperador.SelectedIndex = -1;
            btnContervirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;


        }
        /// <summary>
        /// Metodo para operar entre los dos Numeros
        /// </summary>
        /// <param name="numero1">Primer Numero</param>
        /// <param name="numero2">Segundo Numero</param>
        /// <param name="operador">Operador Seleccionado</param>
        /// <returns></returns>Retorna el resultado de la operacion
        private static double Operar(string numero1,string numero2,string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNum1.Text;
            string num2 = txtNum2.Text;
            string operador = cmbOperador.Text;
            lblResultado.Text = (Operar(num1, num2,operador)).ToString();
            btnConvertirADecimal.Enabled = false;
            btnContervirABinario.Enabled = true;
        }

        
    }
}
