using ProyectoPOS_1CA_A.CapaDato;
using ProyectoPOS_1CA_A.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A.CapaNegocio
{
    public class ClienteBLL
    {
        
        ClienteDAL dal = new ClienteDAL();

        public DataTable Listar()
        {
            return dal.Listar();
        }

  

        public int Guardar(Cliente2 c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
                throw new Exception("El nombre del cliente es obligatorio.");

            if (c.Id == 0)
            {
                return dal.Insertar(c);
            }
            else
            {
                dal.Actualizar(c);
                return c.Id;
            }
        }

        public DataTable Buscar(string nombre)
        {
            return dal.Buscar(nombre);
        }

        public void Eliminar(int id)
        {
            if (dal.TieneVentasAsociadas(id))
            {
                MessageBox.Show("Este cliente tiene ventas registradas. No se puede eliminar.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            dal.Eliminar(id);
        }

        public bool ExisteNombre(string nombre)
        {
            return dal.ExisteNombre(nombre);
        }

        public bool ExisteNombreEnOtroCliente(string nombre, int id)
        {
            return dal.ExisteNombreEnOtroCliente(nombre, id);
        }

        public bool TieneVentasAsociadas(int id)
        {
            return dal.TieneVentasAsociadas(id);
        }
    }
}

