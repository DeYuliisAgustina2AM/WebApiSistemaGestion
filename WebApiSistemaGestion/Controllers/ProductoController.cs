using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.Models;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductoController : Controller
    {
        private ProductoService productoService;

        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet("{IdUsuario}/producto")]
        public ActionResult<ProductoDTO> ObtenerProductoPorIdUsuario(int IdUsuario)
        {
            var producto = productoService.ObtenerProductoPorIdUsuario(IdUsuario);

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO productoDTO)
        {
            
            if (this.productoService.AgregarUnProducto(productoDTO))
            {

                return base.Ok(new { mensaje = "Prodcuto agregado", productoDTO });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego un producto" });
            }
        }

        [HttpDelete]
        public IActionResult BorrarProducto(ProductoDTO productoDTO)
        {
            int idUsuario = productoDTO.IdUsuario;

            if (idUsuario > 0)
            {
                if (this.productoService.BorrarProductoPorId(idUsuario, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }

                return base.Conflict(new { mensaje = "No se pudo borrar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }


        [HttpPut]
        public IActionResult ActualizarProductoPorId(ProductoDTO productoDTO)
        {
            int idUsuario = productoDTO.IdUsuario;

            if (idUsuario > 0)
            {
                if (this.productoService.ActualizarProductoPorId(idUsuario, productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto Actualizado", status = 200, productoDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo Actualizar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }

    }
}
