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
    public class HabitacionDatos : IHabitacionDatos
    {
        SqlConnection conexion;

        public HabitacionDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Habitacion> ListarHabitacion()
        {
            List<Habitacion> habitaciones = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarHabitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            SqlDataReader lector = cmd.ExecuteReader();
            
            if (lector.HasRows)
            {
                habitaciones = new List<Habitacion>();
                while (lector.Read())
                {
                    var habitacion = new Habitacion();
                    habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    habitacion.descripcion = lector["DESCRIPCION_HABITACION"].ToString();
                    habitacion.estado = lector["ESTADO_HABITACION"].ToString();
                    habitacion.precio = decimal.Parse(lector["PRECIO_HABITACION"].ToString());
                    habitaciones.Add(habitacion);
                }
            }

            conexion.Close();
            return habitaciones;
        }

        public void AgregarHabitacion(Habitacion habitacion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarHabitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@descripcion", habitacion.descripcion);
            cmd.Parameters.AddWithValue("@huespedes", habitacion.huespedes);
            cmd.Parameters.AddWithValue("@imagen", habitacion.imagen);
            cmd.Parameters.AddWithValue("@precio", habitacion.precio);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarHabitacion(Habitacion habitacion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarHabitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", habitacion.codigo);
            cmd.Parameters.AddWithValue("@descripcion", habitacion.descripcion);
            cmd.Parameters.AddWithValue("@huespedes", habitacion.huespedes);
            cmd.Parameters.AddWithValue("@imagen", habitacion.imagen);
            cmd.Parameters.AddWithValue("@precio", habitacion.precio);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarHabitacion(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarHabitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }



        public Habitacion ListarHabitacionXId(int id)
        {
            Habitacion habitacion = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarHabitacionXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                habitacion = new Habitacion();
                while (lector.Read())
                {
                    habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    habitacion.descripcion = lector["DESCRIPCION_HABITACION"].ToString();
                    habitacion.estado = lector["ESTADO_HABITACION"].ToString();
                    habitacion.huespedes = int.Parse(lector["HUESPEDES_HABITACION"].ToString());
                    habitacion.imagen = lector["IMAGEN_HABITACION"].ToString();
                    habitacion.precio = decimal.Parse(lector["PRECIO_HABITACION"].ToString());
                }
            }

            conexion.Close();
            return habitacion;
        }

        public void CheckIn(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_CheckIn";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void CheckOut(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_CheckOut";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
