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
    public class EmpleadoNegocios
    {
        private IEmpleadoDatos Datos;

        public EmpleadoNegocios()
        {
            Datos = new EmpleadoDatos();
        }

        public List<Empleado> ListarEmpleadoXDni(string dni)
        {

            return Datos.ListarEmpleadoXDni(dni);
        }

        public Empleado ListarEmpleadoXId(int id)
        {

            return Datos.ListarEmpleadoXId(id);
        }

        public string AgregarEmpleado(Empleado empleado)
        {
            string msj = "";
            try
            {
                empleado.Validar();
                Datos.AgregarEmpleado(empleado);
                msj = "Empleado agregado";

            }
            catch (Exception ex)
            {
                msj = "No se agrego el empleado : " + ex.Message;
            }
            return msj;
        }


        public string ActualizarEmpleado(Empleado empleado)
        {
            string msj = "";
            try
            {
                empleado.Validar();
                Datos.ActualizarEmpleado(empleado);
                msj = "Empleado actualizado";

            }
            catch (Exception ex)
            {
                msj = "No se actualizo el empleado : " + ex.Message;
            }
            return msj;
        }


        public string EliminarEmpleado(int id)
        {
            string msj = "";
            try
            {
                Datos.EliminarEmpleado(id);
                msj = "Empleado eliminado";

            }
            catch (Exception ex)
            {
                msj = "No se elimino el empleado : " + ex.Message;
            }
            return msj;
        }

        public Empleado Login(string nombre, string dni)
        {

            return Datos.Login(nombre, dni);
        }
    }
}
