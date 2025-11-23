using ProyectoPOS_1CA_A.CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A.CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }
        //creacion de una lista estatica que simulura la Db
        public static List<Producto> listaProductos = new List<Producto>();
        private void DesabilidarBotones()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;    
            btnLimpiar.Enabled=false;
            btnNuevo.Enabled = true;
        }
        private void HabilitarBotones()
        {
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnLimpiar.Enabled = true;
            btnNuevo.Enabled = false;
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            //Dabilitar botonoces
            DesabilidarBotones(); //Al iniciar no esta activos
            //Cargar los datos iniciales
            if (!listaProductos.Any())
                listaProductos.Add(new Producto
                {
                    Id = 1,
                    Nombre = "CafeGourmet",
                    Descripcion = "Importado",
                    Precio = 10.5m,
                    Stock = 100,
                    Estado = true
                });

            listaProductos.Add(new Producto
            {
                Id = 2,
                Nombre = "Cafe Borbom",
                Descripcion = "Importado",
                Precio = 10.5m,
                Stock = 100,
                Estado = true
            });
            listaProductos.Add(new Producto
            {
                Id = 3,
                Nombre = "Cheescake",
                Descripcion = "Dulce Sabor",
                Precio = 15.75m,
                Stock = 75,
            });
            RefrescarGrid();
        }
        //asignar la lista como data soucer al datagridview
        private void RefrescarGrid()
        {
            dgvProductos.DataSource = null; //Limpiar el data sourcce
            dgvProductos.DataSource = listaProductos; //asignar lista de datos
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Validaciones basicas
            //Valida que el nombre no este vacio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {

                MessageBox.Show("El nombre del producto es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            //Valida que el precio sea ingresado
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El Precio del producto debe ser en valor numerico", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }
            //Valida que el stock sea entero y no decimal.
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("El numero ingresado debe ser entero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;

            }
            int nuevoId = listaProductos.Any() ? listaProductos.Max(x => x.Id) + 1 : 1;
            var p = new Producto
            {
                Id = nuevoId,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Estado = chkEstado.Checked,
            };
            //agregar a la lista
            listaProductos.Add(p);
            RefrescarGrid(); //Refrescar el datagridiew
            LimpiarCampos();  // Limpair los controles

        }
        //Metodo par limpiar los controles
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtStock.Focus();
        }



        //Evento click del datagridview
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;
            //obtener click del datagridview
            txtId.Text = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            chkEstado.Checked = (bool)dgvProductos.CurrentRow.Cells["Estado"].Value;
            // Habilitar botones editar y eliminar
            HabilitarBotones();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Evento para eliminar un proudcto 
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Seleccione un producto valido para eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var prod = listaProductos.FirstOrDefault(x => x.Id == id);
            if (prod == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el producto seleccionado", "Confirmar eliminacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaProductos.Remove(prod);//Con remove elimino el producto de la lista
                RefrescarGrid(); //Refrescar el datagridview
                LimpiarCampos(); //Limpiar los controles
                DesabilidarBotones();
            }
                
        

    }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
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
            var prod = listaProductos.FirstOrDefault(x => x.Id == id);
            if (prod == null)
            {
                MessageBox.Show("El precio del prodcuto debe ser un valor numérico.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }
            //Validaciones identicas al del boton guardar

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {

                MessageBox.Show("El nombre del producto es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            //Valida que el precio sea ingresado
            if (!Validaciones.EsDecimal(txtPrecio.Text))
            {
                MessageBox.Show("El Precio del producto debe ser en valor numerico", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecio.Focus();
                return;
            }
            //Valida que el stock sea entero y no decimal.
            if (!Validaciones.EsEntero(txtStock.Text))
            {
                MessageBox.Show("El numero ingresado debe ser entero", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return;

            }
            //Actualizar los campos en memoria
            prod.Nombre = txtNombre.Text.Trim();
            prod.Descripcion = txtDescripcion.Text.Trim();
            prod.Precio = decimal.Parse(txtPrecio.Text);
            prod.Estado = chkEstado.Checked;
            MessageBox.Show("Producto actualizado correctamente.", "Exito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarGrid();
            LimpiarCampos();
            DesabilidarBotones();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    
