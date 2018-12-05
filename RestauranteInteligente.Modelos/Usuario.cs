using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestauranteInteligente.Modelos
{
    public class Usuario
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre es requerido");
            else if (nombre.Length > 25)
                throw new Exception("Nombre tiene un máximo de 25 caracteres");
            if (string.IsNullOrEmpty(password))
                throw new Exception("Contraseña es requerida");
            else if (password.Length !=8 )
                throw new Exception("Contraseña debe tener 8 caracteres");
            if(string.IsNullOrEmpty(correo))
                throw new Exception("Correo es requerida");
            else if (Regex.IsMatch(correo, "\\w + ([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
                throw new Exception("Correo incorrecto");
            if (string.IsNullOrEmpty(direccion))
                throw new Exception("Direccion es requerido");
            if (string.IsNullOrEmpty(telefono))
                throw new Exception("Telefono es requerido");
            else if (!int.TryParse(telefono, out int valor))
                throw new Exception("Telefono solo acepta números");


        }
    }
}
