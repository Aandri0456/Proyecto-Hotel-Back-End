using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IEmpleadoDatos
    {
        List<Empleado> ListarEmpleadoXDni(string dni);

        Empleado ListarEmpleadoXId(int id);

        void AgregarEmpleado(Empleado empleado);

        void ActualizarEmpleado(Empleado empleado);

        void EliminarEmpleado(int id);

        Empleado Login(string nombre, string dni);
    }
}
