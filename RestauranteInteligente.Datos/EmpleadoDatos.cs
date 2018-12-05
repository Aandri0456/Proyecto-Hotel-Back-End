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
    public class EmpleadoDatos : IEmpleadoDatos
    {
        
        SqlConnection conexion;

        public EmpleadoDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Empleado> ListarEmpleadoXDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                dni = ""; 
            }
            List<Empleado> empleados = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarEmpleadoXDni";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataReader lector = cmd.ExecuteReader();
            
            if (lector.HasRows)
            {
                empleados = new List<Empleado>();
                while (lector.Read())
                {
                    var empleado = new Empleado();
                    empleado.codigo = int.Parse(lector["CODIGO_EMPLEADO"].ToString());
                    empleado.nombre = lector["NOMBRE_EMPLEADO"].ToString();
                    empleado.apellidos = lector["APELLIDOS_EMPLEADO"].ToString();
                    empleado.dni = lector["DNI_EMPLEADO"].ToString();
                    empleado.cargo = lector["CARGO_EMPLEADO"].ToString();
                    empleado.direccion = lector["DIRECCION_EMPLEADO"].ToString();
                    empleado.telefono = lector["TELEFONO_EMPLEADO"].ToString();
                    empleados.Add(empleado);
                }
            }

            conexion.Close();
            return empleados;
        }

        public Empleado ListarEmpleadoXId(int id)
        {
            Empleado empleado = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarEmpleadoXId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                empleado = new Empleado();
                while (lector.Read())
                {
                    empleado.codigo = int.Parse(lector["CODIGO_EMPLEADO"].ToString());
                    empleado.nombre = lector["NOMBRE_EMPLEADO"].ToString();
                    empleado.apellidos = lector["APELLIDOS_EMPLEADO"].ToString();
                    empleado.dni = lector["DNI_EMPLEADO"].ToString();
                    empleado.cargo = lector["CARGO_EMPLEADO"].ToString();
                    empleado.direccion = lector["DIRECCION_EMPLEADO"].ToString();
                    empleado.telefono = lector["TELEFONO_EMPLEADO"].ToString();
                }
            }

            conexion.Close();
            return empleado;
        }
        

        public void AgregarEmpleado(Empleado empleado)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@apellidos", empleado.apellidos);
            cmd.Parameters.AddWithValue("@dni", empleado.dni);
            cmd.Parameters.AddWithValue("@cargo", empleado.cargo);
            cmd.Parameters.AddWithValue("@direccion", empleado.direccion);
            cmd.Parameters.AddWithValue("@telefono", empleado.telefono);

            cmd.ExecuteNonQuery();
           
            conexion.Close();
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ActualizarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", empleado.codigo);
            cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
            cmd.Parameters.AddWithValue("@apellidos", empleado.apellidos);
            cmd.Parameters.AddWithValue("@dni", empleado.dni);
            cmd.Parameters.AddWithValue("@cargo", empleado.cargo);
            cmd.Parameters.AddWithValue("@direccion", empleado.direccion);
            cmd.Parameters.AddWithValue("@telefono", empleado.telefono);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarEmpleado(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_EliminarEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();
            
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }


        public Empleado Login(string nombre, string dni)
        {

            Empleado empleado = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LoginEmpleado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@dni", dni);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                empleado = new Empleado();
                while (lector.Read())
                {

                    empleado.codigo = int.Parse(lector["CODIGO_EMPLEADO"].ToString());
                    empleado.nombre = lector["NOMBRE_EMPLEADO"].ToString();
                    empleado.cargo = lector["CARGO_EMPLEADO"].ToString();
                }
            }

            conexion.Close();
            return empleado;
        }
    }
}
