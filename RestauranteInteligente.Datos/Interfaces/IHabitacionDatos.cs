using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IHabitacionDatos
    {
        void AgregarHabitacion(Habitacion habitacion);

        void ActualizarHabitacion(Habitacion habitacion);

        void EliminarHabitacion(int id);

        void CheckIn(int id);

        void CheckOut(int id);

        List<Habitacion> ListarHabitacion();

        Habitacion ListarHabitacionXId(int id);
    }
}
