using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Empleado
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; }
        public string cargo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre es requerido");
            else if(nombre.Length>25)
                throw new Exception("Nombre tiene un máximo de 25 caracteres"); 
            if (string.IsNullOrEmpty(dni))
                throw new Exception("DNI es requerido");
            else if (dni.Length != 8)
                throw new Exception("DNI debe tener 8 digitos");
            else if (!int.TryParse(dni,out int valor))
                throw new Exception("DNI solo acepta números");
            
            if (string.IsNullOrEmpty(cargo))
                throw new Exception("Cargo es requerido");
            else if (!(cargo.Equals("Administrador")|| cargo.Equals("Recepcionista")))
                throw new Exception("Cargo debe ser Administrador o Recepcionista");
            if (string.IsNullOrEmpty(direccion))
                throw new Exception("Direccion es requerido");
            if (string.IsNullOrEmpty(telefono))
                throw new Exception("Telefono es requerido");
            else if (telefono.Length != 9)
                throw new Exception("Telefono debe tener 9 digitos");
            else if (!int.TryParse(telefono, out int valor))
                throw new Exception("Telefono solo acepta números");
        }
    }
}
