using ProyectoPOS_1CA_A.CapaEntidades;
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
        int clienteId = 0;
        ClienteBLL bll = new ClienteBLL();

        public FrmCliente2()
        {
            InitializeComponent();
        }

        private void CargarLista()
        {
            dgvClientes2.DataSource = bll.Listar();

        }



        private void FrmCliente2_Load(object sender, EventArgs e)
        {
            CargarLista();
            Limpiar();
        }
        void Limpiar()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            chkEstado.Checked = true;
            txtBuscar.Clear();
            txtNombre.Focus();

            clienteId = 0; //Respeta el ID del cliente 0 = Nueve registro

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente2 c = new Cliente2()
                {
                    Id = clienteId, //Si es 0 es nuevo registro, ti siente valor es modificacion
                    Nombre = txtNombre.Text,
                    Telefono = int.Parse(txtTelefono.Text),
                    Correo = txtCorreo.Text,
                    Estado = chkEstado.Checked,
                };
                //LLamamos al metodo guardar de la BLL ( El decide si es insert o update
                int id = bll.Guardar(c);
                MessageBox.Show("Cliente guardado conn exito.", "Notificación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarLista();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvClientes2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                clienteId = Convert.ToInt32(dgvClientes2.Rows[e.RowIndex].Cells["Id"].Value);
                txtNombre.Text = dgvClientes2.CurrentRow.Cells["NombreCompleto"].Value.ToString();
                txtCorreo.Text = dgvClientes2.CurrentRow.Cells["CorreoC"].Value.ToString();
                txtTelefono.Text = dgvClientes2.CurrentRow.Cells["Telefono"].Value.ToString();
                chkEstado.Checked = (bool)dgvClientes2.CurrentRow.Cells["Estado"].Value;
            };

        }

        private void dgvClientes2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvClientes2.DataSource = bll.Buscar(txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteId == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (MessageBox.Show("¿Está seguro de eliminar el cliente seleccionado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bll.Eliminar(clienteId);
                    CargarLista();
                    Limpiar();
                }
        }
    }
}
