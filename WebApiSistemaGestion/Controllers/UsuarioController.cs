using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
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

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> ObtenerUsuarioPorId(int id)
        {
            var usuario = usuarioService.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }
    }
}
