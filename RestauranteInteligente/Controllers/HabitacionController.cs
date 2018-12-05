using RestauranteInteligente.Modelos;
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
    public class HabitacionController : ApiController
    {
        private HabitacionNegocios habitacionNegocios;

        public HabitacionController()
        {
            habitacionNegocios = new HabitacionNegocios();
        }

        [HttpGet]
        public List<Habitacion> ListarHabitacion()
        {
            return habitacionNegocios.ListarHabitacion();

        }

        [HttpGet]
        public Habitacion ListarHabitacionXId(int id)
        {
            return habitacionNegocios.ListarHabitacionXId(id);

        }

        [HttpPost]
        public string AgregarHabitacion(Habitacion habitacion)
        {
            return habitacionNegocios.AgregarHabitacion(habitacion);

        }

        [HttpPut]
        public string ActualizarHabitacion(Habitacion habitacion)
        {
            return habitacionNegocios.ActualizarHabitacion(habitacion);

        }

        [HttpDelete]
        public string EliminarHabitacion(int id)
        {
            return habitacionNegocios.EliminarHabitacion(id);

        }

        [HttpPut]
        public string CheckIn(int id)
        {
            return habitacionNegocios.CheckIn(id);

        }


        [HttpPut]
        public string CheckOut(int id)
        {
            return habitacionNegocios.CheckOut(id);

        }
    }
}
