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
    public class ReservaDatos : IReservaDatos
    {
        SqlConnection conexion;

        public ReservaDatos()
        {
            conexion = new SqlConnection(Conexion.cadenaConexion);
        }

        public List<Reserva> ListarReservaXUsuario(int usuario)
        {
            List<Reserva> reservas = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarReservaXUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@usuario", usuario);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                reservas = new List<Reserva>();
                Reserva reserva;
                Habitacion _habitacion;
                while (lector.Read())
                {
                    reserva = new Reserva();
                    _habitacion = new Habitacion();
                    reserva.codigo = int.Parse(lector["CODIGO_RESERVA"].ToString());
                    reserva.estado = int.Parse(lector["ESTADO"].ToString());
                    reserva.fechaInicio = DateTime.Parse(lector["FECHA_INICIO"].ToString());
                    reserva.total = decimal.Parse(lector["TOTAL"].ToString());
                    reserva.estado = int.Parse(lector["ESTADO"].ToString());
                    _habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    _habitacion.descripcion = lector["DESCRIPCION_HABITACION"].ToString();
                    reserva.habitacion = _habitacion;
                    reservas.Add(reserva);
                }
            }

            conexion.Close();
            return reservas;
        }


        public void AgregarReserva(Reserva reserva)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_AgregarReserva";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@habitacion", reserva.habitacion.codigo);
            cmd.Parameters.AddWithValue("@usuario", reserva.usuario.codigo);
            cmd.Parameters.AddWithValue("@dias", reserva.cantidadDias);
            cmd.Parameters.AddWithValue("@fecha1", reserva.fechaInicio);
            cmd.Parameters.AddWithValue("@total", reserva.total);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void CancelarReserva(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_CancelarReserva";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void PagarReserva(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_PagarReserva";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public List<Habitacion> ListarTopReserva()
        {
            List<Habitacion> habitaciones = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarTopReserva";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();
            

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                habitaciones = new List<Habitacion>();
                Habitacion habitacion;
                while (lector.Read())
                {
                    habitacion = new Habitacion();
                    habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    habitacion.descripcion = lector["DESCRIPCION_HABITACION"].ToString();
                    habitacion.precio = decimal.Parse(lector["PRECIO_HABITACION"].ToString());
                    habitaciones.Add(habitacion);
                }
            }

            conexion.Close();
            return habitaciones;
        }

        public TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta, string numeroTarjeta, string titularTarjeta, string mesExpiracion, string añoExpiracion, string codigoSeguridad)
        {
            TarjetaInfo tarjetaInfo = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_GetTarjetaByInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();
            //declarar los parametros del procedure
            cmd.Parameters.AddWithValue("@idTipoTarjeta", tipoTarjeta);
            cmd.Parameters.AddWithValue("@numeroTarjeta", numeroTarjeta);
            cmd.Parameters.AddWithValue("@nombreTarjeta", titularTarjeta);
            cmd.Parameters.AddWithValue("@securityCodeTarjeta", codigoSeguridad);
            cmd.Parameters.AddWithValue("@mesExpiracionTarjeta", mesExpiracion);
            cmd.Parameters.AddWithValue("@añoExpiracionTarjeta", añoExpiracion);

            SqlDataReader reader = cmd.ExecuteReader();
            //verificar que tenga filas
            if (reader.HasRows)
            {
                tarjetaInfo = new TarjetaInfo();
                //leer el registro
                while (reader.Read())
                {
                    tarjetaInfo.titularTarjeta = reader["NOMBRE_TARJETA"].ToString();
                    tarjetaInfo.numeroTarjeta = reader["NUMERO_TARJETA"].ToString();
                    tarjetaInfo.tarjetaHabilitada = bool.Parse(reader["TARJETA_HABILITADA"].ToString());
                    tarjetaInfo.creditoDisponible = double.Parse(reader["CREDITO_DISPONIBLE"].ToString());
                }
            }

            //cerrar conexion
            conexion.Close();

            return tarjetaInfo;
        }

        public List<Reserva> ListarReservaxestado(int estado)
        {
            List<Reserva> reservas = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarReservaxestado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();

            cmd.Parameters.AddWithValue("@estado", estado);

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                reservas = new List<Reserva>();
                Reserva reserva;
                var _habitacion = new Habitacion();
                while (lector.Read())
                {
                    reserva = new Reserva();
                    reserva.codigo = int.Parse(lector["CODIGO_RESERVA"].ToString());
                    reserva.estado = int.Parse(lector["ESTADO"].ToString());
                    reserva.fechaInicio = DateTime.Parse(lector["FECHA_INICIO"].ToString());
                    reserva.total = decimal.Parse(lector["TOTAL"].ToString());
                    reserva.estado = int.Parse(lector["ESTADO"].ToString());
                    _habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    _habitacion.descripcion = lector["DESCRIPCION_HABITACION"].ToString();
                    reserva.habitacion = _habitacion;
                    reservas.Add(reserva);
                }
            }

            conexion.Close();
            return reservas;
        }

        public bool ValidarFechas(Reserva reserva)
        {
            List<Reserva> reservas = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_ListarReservaxhabitacion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            conexion.Open();


            cmd.Parameters.AddWithValue("@habitacion", reserva.habitacion.codigo);
            

            SqlDataReader lector = cmd.ExecuteReader();
            reservas = new List<Reserva>();
            if (lector.HasRows)
            {
                
                Reserva reserv;
                var _habitacion = new Habitacion();
                while (lector.Read())
                {
                    reserv = new Reserva();
                    reserv.codigo = int.Parse(lector["CODIGO_RESERVA"].ToString());
                    reserv.fechaInicio = DateTime.Parse(lector["FECHA_INICIO"].ToString());
                    reserv.cantidadDias = int.Parse(lector["CANTIDAD_DIAS"].ToString());
                    _habitacion.codigo = int.Parse(lector["CODIGO_HABITACION"].ToString());
                    reserv.habitacion = _habitacion;
                    reservas.Add(reserv);
                }
            }

            DateTime date1 = reserva.fechaInicio;
            DateTime date2 = (reserva.fechaInicio).AddDays(reserva.cantidadDias);

            

            foreach (var res in reservas)
            {
                DateTime date3 = res.fechaInicio;
                DateTime date4 = res.fechaInicio.AddDays(res.cantidadDias);
                if (date3 <= date1&& date1 <= date4|| date3<= date2 && date2 <= date4)
                {
                    conexion.Close();
                    return false;
                }
            }

            conexion.Close();
            return true;
        }
    }
}
