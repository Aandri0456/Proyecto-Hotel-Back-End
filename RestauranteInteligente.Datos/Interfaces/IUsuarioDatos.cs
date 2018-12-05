using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Datos.Interfaces
{
    public interface IUsuarioDatos
    {

        void AgregarUsuario(Usuario usuario);

        Usuario Login(string correo, string password);
    }
}
