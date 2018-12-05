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
    public class UsuarioController : ApiController
    {
        private UsuarioNegocios usuarioNegocios;

        public UsuarioController()
        {
            usuarioNegocios = new UsuarioNegocios();
        }

        [HttpPost]
        public string AgregarUsuario(Usuario usuario)
        {
            return usuarioNegocios.AgregarUsuario(usuario);

        }
        
        [HttpPost]
        public Usuario Login(UsuarioViewModel modelo)
        {
            return usuarioNegocios.Login(modelo.correo,modelo.password);

        }
    }
}
