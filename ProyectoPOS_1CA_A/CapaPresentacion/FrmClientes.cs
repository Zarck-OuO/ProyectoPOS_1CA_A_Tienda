using ProyectoPOS_1CA_A.CapaEntidades;
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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }
        //creacion de una lista estatica que simulura la Db
        public static List<Clientes> listaClientes = new List<Clientes>();
        // desabilitar botones y habilitar
        private void DesabilitarBotones()
        {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnLimpiar.Enabled = false;
        }
        private void HabilitarBotones()
        {
            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VentaRapida_Load(object sender, EventArgs e)
        {
            // funcion desabilitar botones
            DesabilitarBotones();

            if (!listaClientes.Any())
                listaClientes.Add(new Clientes
                {
                    Id = 1,
                    Nombre = "Moises",
                    Correo = "moises@gmail.com",
                    Telefono = 73529702,
                    TipoCliente = "normal",
                    Estado = true,
                });
            RefrescarGrid();
        }
        private void RefrescarGrid()
        {
            dgvClientes.DataSource = null; //Limpiar el data sourcce
            dgvClientes.DataSource = listaClientes; //asignar lista de datos
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Evento para eliminar un proudcto 
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un cliente valido para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prod = listaClientes.FirstOrDefault(x => x.Id == id);
            if (prod == null)
            {
                MessageBox.Show("Cliente no encontrado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el cliente seleccionado", "Confirmar eliminacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaClientes.Remove(prod);//Con remove elimino el producto de la lista
                RefrescarGrid(); //Refrescar el data
                                 //gridview
                LimpiarCampos(); //Limpiar los controles
                DesabilitarBotones();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Valido que el id sea un entero
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto válido para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Busco el producto en la lista
            var prod = listaClientes.FirstOrDefault(x => x.Id == id);
            if (prod == null)

                //Validaciones identicas al del boton guardar

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {

                    MessageBox.Show("El nombre del cliente es obligatorio.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }
            //Valida que el precio sea ingresado
            if (!Validaciones.EsEnteroc(txtTelefono.Text))
            {
                MessageBox.Show("El numero de telefono debe ser en valor numerico", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            //Valida que el stock sea entero y no decimal.
            if (!Validaciones.EsCorreoValidoc(txtCorreo.Text))
            {
                MessageBox.Show("El numero ingresado debe ser entero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return;

            }
            //Actualizar los campos en memoria
            prod.Nombre = txtNombre.Text.Trim();
            prod.Correo = txtCorreo.Text.Trim();
            prod.Telefono = int.Parse(txtTelefono.Text.Trim());
            prod.Estado = chkEstado.Checked;
            prod.TipoCliente = cbxTipoCLiente.Text.Trim();
            MessageBox.Show("Producto actualizado correctamente.", "Exito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarGrid();
            LimpiarCampos();
            DesabilitarBotones();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validaciones basicas
           
           

            // OBligatorio el nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {

                MessageBox.Show("El nombre es obligatorio", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;

            }
            //Telefono obligatorio
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Telefono obligatorio", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            //Valida que el Telefono sea entero y no decimal.
            if (!Validaciones.EsEnteroc(txtTelefono.Text))
            {
                MessageBox.Show("El numero de telefono debe ser un numero, no letras", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return;
            }
            
            //Correo obligatorio
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Correo Obligatorio", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return;
            }
            //Validacion de correo
            if (!Validaciones.EsCorreoValidoc(txtCorreo.Text))
            {
                MessageBox.Show("el correo debe tener una @", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return;
            }
            // Tipo de cliente obligatorio
            if (String.IsNullOrWhiteSpace(cbxTipoCLiente.Text))
            {
                MessageBox.Show("Elegir tipo de cliente, Porfavor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxTipoCLiente.Focus();
                return;
            }

            int nuevoId = listaClientes.Any() ? listaClientes.Max(x => x.Id) + 1 : 1;
            var p = new Clientes
            {
                Id = nuevoId,
                Nombre = txtNombre.Text,
                Correo = txtCorreo.Text,
                Telefono = int.Parse(txtTelefono.Text),
                TipoCliente = cbxTipoCLiente.Text,
                Estado = chkEstado.Checked,
            };
            //agregar a la lista
            listaClientes.Add(p);
            RefrescarGrid(); //Refrescar el datagridiew
            LimpiarCampos();  // Limpair los controles

        }
        
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtTelefono.Focus();
            cbxTipoCLiente.SelectedIndex = -1;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return; 
            txtId.Text = dgvClientes.CurrentRow.Cells["Id"].Value.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCorreo.Text = dgvClientes.CurrentRow.Cells["Correo"].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells["Telefono"].Value.ToString();
            cbxTipoCLiente.Text = dgvClientes.CurrentRow.Cells["TipoCliente"].Value.ToString();
            chkEstado.Checked = (bool)dgvClientes.CurrentRow.Cells["Estado"].Value;
            HabilitarBotones();

        }

        private void cbxTipoCLiente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
