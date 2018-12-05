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
    public class EmpleadoController : ApiController
    {
        private EmpleadoNegocios empleadoNegocios;

        public EmpleadoController()
        {
            empleadoNegocios = new EmpleadoNegocios();
        }

        [HttpGet]
        public List<Empleado> ListarEmpleadoXDni(string dni)
        {
            return empleadoNegocios.ListarEmpleadoXDni(dni);

        }

        [HttpGet]
        public Empleado ListarEmpleadoXId(int id)
        {
            return empleadoNegocios.ListarEmpleadoXId(id);

        }

        [HttpPost]
        public string AgregarEmpleado(Empleado empleado)
        {
            return empleadoNegocios.AgregarEmpleado(empleado);

        }

        [HttpPut]
        public string ActualizarEmpleado(Empleado empleado)
        {
            return empleadoNegocios.ActualizarEmpleado(empleado);

        }

        [HttpDelete]
        public string EliminarEmpleado(int id)
        {
            return empleadoNegocios.EliminarEmpleado(id);

        }

        [HttpPost]
        public Empleado Login(EmpleadoViewModel modelo)
        {
            return empleadoNegocios.Login(modelo.nombre, modelo.dni);

        }
    }
}
