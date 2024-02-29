using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoService productoVendidoService;

        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }

        [HttpGet("{idUsuario}")]
        public IActionResult ObtenerProductoPorIdUsuario(int idUsuario)
        {
            var productos = productoVendidoService.ObtenerProductoPorIdUsuario(idUsuario);

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

    }
}
