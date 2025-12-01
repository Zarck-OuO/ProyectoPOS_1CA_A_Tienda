using ProyectoPOS_1CA_A.CapaDato;
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
    public partial class FrmPruebas : Form
    {
        public FrmPruebas()
        {
            InitializeComponent();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            int stock = ProductoDAL.ObtenerStock(1); // prueba con un id real
            MessageBox.Show("Stock del producto 1: " + stock);

        }

        private void btnClientesActivos_Click(object sender, EventArgs e)
        {
            var clientes = ClienteDAL.ListarActivos();
            MessageBox.Show("Clientes activos: " + clientes.Count);

        }

        private void btnProbarPagos_Click(object sender, EventArgs e)
        {
            var pagos = MetodoPagoDAL.Listar();
            MessageBox.Show("Tipos de pago: " + pagos.Count);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnValidarVentas_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta()
            {
                FechaVenta = DateTime.Now,
                MontoTotal = 5.00m,
                Id_Cliente = 1,
                Id_MetodoPago = 1
            };

            var detalles = new List<DetalleVenta>()
    {
        new DetalleVenta()
        {
            Id_Producto = 1,
            Cantidad = 1,
            PrecioUnitario = 5.00m,
            SubTotal = 5.00m
        }
    };

            var r = VentaBLL.ValidarVenta(venta, detalles);

            MessageBox.Show(r.Mensaje);

        }

        private void btnPruebaVentaRapida_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta()
            {
                FechaVenta = DateTime.Now,
                MontoTotal = 10.00m,
                Id_Cliente = 1, // usa tu Cliente por defecto
                Id_MetodoPago = 1 // efectivo (o el que tengas)
            };

            var detalles = new List<DetalleVenta>()
    {
        new DetalleVenta()
        {
            Id_Producto = 1,  // debe existir
            Cantidad = 1,
            PrecioUnitario = 10.00m,
            SubTotal = 10.00m
        }
    };

            var r = VentaDAL.RegistrarVentaTransaccional(venta, detalles);

            MessageBox.Show(r.Mensaje);



        }
    }
}
