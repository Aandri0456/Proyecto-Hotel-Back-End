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
    public class HabitacionNegocios
    {
        private IHabitacionDatos Datos;

        public HabitacionNegocios()
        {
            Datos = new HabitacionDatos();
        }

        public List<Habitacion> ListarHabitacion()
        {

            return Datos.ListarHabitacion();
        }

        public Habitacion ListarHabitacionXId(int id)
        {

            return Datos.ListarHabitacionXId(id);
        }

        public string AgregarHabitacion(Habitacion habitacion)
        {
            string msj = "";
            try
            {
                habitacion.Validar();
                Datos.AgregarHabitacion(habitacion);
                msj = "Habitacion agregada";

            }
            catch (Exception ex)
            {
                msj = "No se agrego la habitacion : " + ex.Message;
            }
            return msj;
        }


        public string ActualizarHabitacion(Habitacion habitacion)
        {
            string msj = "";
            try
            {
                habitacion.Validar();
                Datos.ActualizarHabitacion(habitacion);
                msj = "Habitacion actualizada";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo la habitacion : " + ex.Message;
            }
            return msj;
        }


        public string EliminarHabitacion(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarHabitacion(id);
                msj = "Habitacion eliminada";

            }
            catch (Exception ex)
            {
                msj = "No se elimino la habitacion : " + ex.Message;
            }
            return msj;
        }


        public string CheckIn(int id)
        {
            string msj = "";
            try
            {
                Datos.CheckIn(id);
                msj = "Check in realizado";

            }
            catch (Exception ex)
            {
                msj = "No se realizo el check in : " + ex.Message;
            }
            return msj;
        }


        public string CheckOut(int id)
        {
            string msj = "";
            try
            {
                Datos.CheckOut(id);
                msj = "Check out realizado";

            }
            catch (Exception ex)
            {
                msj = "No se realizo el check out : " + ex.Message;
            }
            return msj;
        }

    }

}
