using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<UsuarioDTO> ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = usuarioService.ObtenerUsuarioPorId(idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpGet]
        public IActionResult ObtenerUsuarioPorUsuarioYPassword(string nombreUsuario, string password)
        {
            var usuario = usuarioService.ObtenerUsuarioPorUsuarioYPassword(nombreUsuario, password);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoUsuario([FromBody] UsuarioDTO usuario)
        {
            if (this.usuarioService.AgregarUnUsuario(usuario))
            {
                return base.Ok(new { mensaje = "Usuario agregado", usuario });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agregó un usuario" });
            }
        }

        [HttpPut]
        public IActionResult ActualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            int idUsuario = usuarioDTO.Id;

            if (idUsuario > 0)
            {
                if (this.usuarioService.ActualizarUsuario(idUsuario, usuarioDTO))
                {
                    return base.Ok(new { mensaje = "Usuario actualizado", usuario = usuarioDTO });
                }
                else
                {
                    return base.NotFound(new { mensaje = "Usuario no encontrado" });
                }
            }
            else
            {
                return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
            }
        }

        [HttpDelete]
        public IActionResult BorrarProducto([FromBody] UsuarioDTO usuarioDTO)
        {
            int idUsuario = usuarioDTO.Id;

            if (idUsuario > 0)
            {
                if (this.usuarioService.BorrarUsuarioPorId(idUsuario, usuarioDTO))
                {
                    return base.Ok(new { mensaje = "Usuario borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el usuario" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }


    }
}
