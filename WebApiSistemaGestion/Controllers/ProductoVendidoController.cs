using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.Models;
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
        public ActionResult<List<ProductoVendidoDTO>> ObtenerProductosVendidosPorUsuario(int idUsuario)
        {
            var productosVendidos = productoVendidoService.ObtenerProductosVendidosPorUsuario(idUsuario);

            if (productosVendidos == null)
            {
                return NotFound();
            }

            var productosVendidosDTO = new List<ProductoVendidoDTO>();

            foreach (var productoVendido in productosVendidos)
            {
                productosVendidosDTO.Add(ProductoVendidoMapper.MapearProductoVendidoADTO(productoVendido)); // Se utiliza el método MappearAProductoVendidoDTO
            }

            return Ok(productosVendidosDTO);
        }



    }
}
