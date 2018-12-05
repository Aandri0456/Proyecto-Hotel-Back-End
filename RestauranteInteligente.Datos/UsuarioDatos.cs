using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos
{
    public class UsuarioDatos : IUsuarioDatos
    {
        SqlConnection conexion;

        public UsuarioDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public void AgregarUsuario(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
            cmd.Parameters.AddWithValue("@correo", usuario.correo);
            cmd.Parameters.AddWithValue("@password", usuario.password);
            cmd.Parameters.AddWithValue("@direccion", usuario.direccion);
            cmd.Parameters.AddWithValue("@telefono", usuario.telefono);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public Usuario Login(string correo, string password)
        {

            Usuario usuario = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                usuario = new Usuario();
                while (lector.Read())
                {

                    usuario.codigo = int.Parse(lector["CODIGO_USUARIO"].ToString());
                    usuario.nombre = lector["NOMBRE_USUARIO"].ToString();
                    usuario.correo = lector["CORREO_USUARIO"].ToString();
                    usuario.direccion = lector["DIRECCION_USUARIO"].ToString();
                    usuario.telefono = lector["TELEFONO_USUARIO"].ToString();
                }
            }

            conexion.Close();
            return usuario;
        }
    }
}
