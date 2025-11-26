using ProyectoPOS_1CA_A.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOS_1CA_A.CapaDato
{
    public class ClienteDAL
    {

        public DataTable Listar()
        {
            DataTable dt = new DataTable(); //Tabla en memeroia
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"Select Id,NombreCompleto,CorreoC,Telefono,Estado From Cliente";
                using (SqlCommand cmd = new SqlCommand(sql, cn))

                {
                    cn.Open();
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }
        public int Insertar(Cliente2 c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"INSERT INTO Cliente(NombreCompleto,CorreoC,Telefono,Estado) 
                Values(@NombreCompleto, @CorreoC, @Telefono, @Estado); SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", c.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool Actualizar (Cliente2 c)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"UPDATE CLIENTE SET 
                NombreCompleto=@NombreCompleto, 
                CorreoC=@CorreoC, 
                Telefono=@Telefono, 
                Id_TipoCliente, 
                Estado=@Estado 
                where Id=@Id;";
                
                using (SqlCommand cmd = new SqlCommand (sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@NombreCompleto", c.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoC", c.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", c.Estado);

                    cn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = "DELETE FROM cliente WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue ("@id", id);
                    cn.Open();
                    return cmd.ExecuteNonQuery () > 0;
                    //Elimina y devuleve true si se elimino almenos una fila
                }
            }
        }
        public DataTable Buscar(string filtro)
        {
            DataTable dt= new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                string sql = @"SELECT Id, NombreCompleto, CorreoC, Telefono, Estado 
                From cliente
                WHERE NombreCompleto LIKE @filtro OR Telefono Like @Filtro";

            using (SqlCommand cmd=new SqlCommand (sql, cn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    cn.Open ();
                    new SqlDataAdapter(cmd).Fill (dt);
                }
            }
            return dt;
        }

    }
}



