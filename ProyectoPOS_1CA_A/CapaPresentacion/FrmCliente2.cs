using ProyectoPOS_1CA_A.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A.CapaPresentacion
{
    public partial class FrmCliente2 : Form
    {
        public FrmCliente2()
        {
            InitializeComponent();
        }
        ClienteBLL ClienteBLL = new ClienteBLL();

        private void CargarLista()
        {
            dgvClientes2.DataSource = ClienteBLL.Listar();
        }

        private void FrmCliente2_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
