using ProyectoPOS_1CA_A.CapaDato;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOS_1CA_A.CapaEntidades
{
    public class CategoriaDAL
    {
        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT Id, NombreCategoria, Descripcion FROM Categoria";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    new SqlDataAdapter(cmd).Fill(dt);
                    // SqlDataAdapter ejecuta el SELECT y guarda el resultado en dt
                }
            }
            return dt;
        }

    }
}
