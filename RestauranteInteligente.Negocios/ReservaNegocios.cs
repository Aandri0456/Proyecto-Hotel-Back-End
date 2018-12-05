using RestauranteInteligente.Datos;
using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class ReservaNegocios
    {
        private IReservaDatos Datos;

        public ReservaNegocios()
        {
            Datos = new ReservaDatos();
        }
        
        public List<Reserva> ListarReservaXUsuario(int usuario)
        {

            return Datos.ListarReservaXUsuario(usuario);
        }

        public List<Reserva> ListarReservaxestado(int estado)
        {

            return Datos.ListarReservaxestado(estado);
        }

        public string AgregarReserva(Reserva reserva)
        {
            string msj = "";
            try
            {
                reserva.Validar();
                Datos.AgregarReserva(reserva);
                msj = "Reserva agregada";

            }
            catch (Exception ex)
            {
                msj = "No se agrego la reserva : " + ex.Message;
            }
            return msj;
        }
        

        public string CancelarReserva(int id)
        {
            string msj = "";
            try
            {
                Datos.CancelarReserva(id);
                msj = "Reserva cancelada";

            }
            catch (Exception ex)
            {
                msj = "No se cancelo la reserva : " + ex.Message;
            }
            return msj;
        }

        public string PagarReserva(int id)
        {
            string msj = "";
            try
            {
                Datos.PagarReserva(id);
                msj = "Reserva pagada";

            }
            catch (Exception ex)
            {
                msj = "No se pago la reserva : " + ex.Message;
            }
            return msj;
        }

        public List<Habitacion> ListarTopReserva()
        {

            return Datos.ListarTopReserva();
        }


        public bool ValidarPago(out string mensaje,
                                int tipoTarjeta,
                                string numeroTarjeta,
                                string titularTarjeta,
                                double montoConsumir,
                                string mesExpiracion,
                                string añoExpiracion,
                                string codigoSeguridad
                                )
        {
            bool ValidacionCorrecta = false;
            mensaje = "";



            //verificar que la tarjeta exista

            //llamar a la capa de datos
            TarjetaInfo tarjetaInfo = Datos.ObtenerInformacionTarjeta(tipoTarjeta, numeroTarjeta, titularTarjeta,
                                                    mesExpiracion, añoExpiracion, codigoSeguridad);

            //validar que la tarjeta exista
            if (tarjetaInfo == null)
            {
                mensaje = "Tarjeta no Existe";
            }
            //la tarjeta existe
            else
            {
                //validar que la tarjeta este habilitada
                if (!tarjetaInfo.tarjetaHabilitada)
                {
                    mensaje = "Tarjeta No Habilitada";
                }
                //si la tarjeta no esta deshabilitada
                else
                {
                    // disponible : 99 , monto : 100
                    if (tarjetaInfo.creditoDisponible < montoConsumir)
                    {
                        mensaje = "Linea de credito insuficiente";
                    }
                    else
                    {
                        ValidacionCorrecta = true;
                    }
                }
            }

            return ValidacionCorrecta;
        }

        public string ValidarFechas(Reserva reserva)
        {
            string msj = "";
            bool validacion = Datos.ValidarFechas(reserva);
            if (validacion)
            {
                msj = "Fechas validadas";
            }
            else
            {
                msj = "La fecha ingresada es menor a la fecha actual o esta habitacion esta resevada durante la fecha escogida";
            }
            return msj;
        }
    }

    
}
