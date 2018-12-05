using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IReservaDatos
    {
        List<Reserva> ListarReservaXUsuario(int usuario);

        List<Reserva> ListarReservaxestado(int estado);


        void AgregarReserva(Reserva platillo);

        void CancelarReserva(int id);

        List<Habitacion> ListarTopReserva();

        void PagarReserva(int id);

        TarjetaInfo ObtenerInformacionTarjeta(int tipoTarjeta, string numeroTarjeta, string titularTarjeta, string mesExpiracion, string añoExpiracion, string codigoSeguridad);

        bool ValidarFechas(Reserva reserva);

    }

}
