using RestauranteInteligente.Modelos;
using RestauranteInteligente.Models;
using RestauranteInteligente.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestauranteInteligente.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservaController : ApiController
    {
        private ReservaNegocios reservaNegocios;

        public ReservaController()
        {
            reservaNegocios = new ReservaNegocios();
        }
     
        [HttpGet]
        public List<Reserva> ListarReservaXUsuario(int usuario)
        {
            return reservaNegocios.ListarReservaXUsuario(usuario);

        }

        [HttpGet]
        public List<Reserva> ListarReservaxestado(int estado)
        {
            return reservaNegocios.ListarReservaxestado(estado);

        }

        [HttpPost]
        public string AgregarReserva(Reserva reserva)
        {
            return reservaNegocios.AgregarReserva(reserva);

        }

        [HttpPut]
        public string CancelarReserva(int id)
        {
            return reservaNegocios.CancelarReserva(id);

        }

        [HttpPut]
        public string PagarReserva(int id)
        {
            return reservaNegocios.PagarReserva(id);

        }

        [HttpGet]
        public List<Habitacion> ListarTopReserva()
        {
            return reservaNegocios.ListarTopReserva();

        }


        [HttpPost]
        public ValidarPagoResponse ValidarPago(ValidarPagoRequest request)
        {
            ValidarPagoResponse response = new ValidarPagoResponse();
            string mensaje = "";

            try
            {
                request.Validar();

                response.TransaccionCompleta = reservaNegocios.ValidarPago(out mensaje,
                                        request.TipoTarjeta, request.NumeroTarjeta,
                                        request.TitularTarjeta, request.MontoConsumir,
                                        request.MesExpiracionTarjeta, request.AñoExpiracionTarjeta,
                                        request.CodigoSeguridadTarjeta);
                response.TransaccionMensaje = mensaje;

                return response;

            }
            catch (Exception ex)
            {
                response.TransaccionCompleta = false;
                response.TransaccionMensaje = ex.Message;
                return response;
            }
        }

        [HttpPost]
        public string ValidarFechas(Reserva reserva)
        {
            return reservaNegocios.ValidarFechas(reserva);

        }

    }
}
