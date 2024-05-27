using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using COSTAS_DEMANDAS.Soluciones;
using COSTAS_DEMANDAS.Models;
using Newtonsoft.Json;

namespace COSTAS_DEMANDAS.Controllers
{
    public class UsuariosController : Controller
    {
        RepositorioUsuarios _RepositorioUsuario = new RepositorioUsuarios();

        [HttpPost]
        public IActionResult RegistrarUsuario([FromBody] UsuariosModel usuario)
        {
            var respuesta = _RepositorioUsuario.RegistrarUsuario(usuario.NombreUsuario, usuario.Contraseña);

            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult ValidarUsuario([FromBody] UsuariosModel usuario)
        {
            var respuesta = _RepositorioUsuario.ValidarUsuario(usuario.NombreUsuario, usuario.Contraseña);

            return Ok(respuesta);
        }

    }
}
