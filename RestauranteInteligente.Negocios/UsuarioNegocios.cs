using RestauranteInteligente.Datos;
using RestauranteInteligente.Datos.Interfaces;
using RestauranteInteligente.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteInteligente.Negocios
{
    public class UsuarioNegocios
    {
        private IUsuarioDatos Datos;

        public UsuarioNegocios()
        {
            Datos = new UsuarioDatos();
        }

        public string AgregarUsuario(Usuario usuario)
        {
            string msj = "";
            try
            {
                usuario.Validar();
                Datos.AgregarUsuario(usuario);
                msj = "Usuario agregado";

            }
            catch (Exception ex)
            {
                msj = "No se agrego el usuario : " + ex.Message;
            }
            return msj;
        }

        public Usuario Login(string correo,string password)
        {

            return Datos.Login(correo, password);
        }
    }
}
