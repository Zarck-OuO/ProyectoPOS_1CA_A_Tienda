using ProyectoPOS_1CA_A.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Crear instancia en el forlulario
            FrmCliente2 frn = new FrmCliente2();
            frn.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVentaRapida_Click(object sender, EventArgs e)
        {
            FrmVentaRapida frm = new FrmVentaRapida();
            frm.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //Creo una instacia del forulario
            FrmProducto frm = new FrmProducto();
            //Muestra el formulario
            frm.ShowDialog(); 

        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
