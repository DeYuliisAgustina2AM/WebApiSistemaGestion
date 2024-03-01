using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VentaController : Controller
    {
        private VentaService ventaService;

        public VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("{IdUsuario}/producto")]
        public ActionResult<VentaDTO> ObtenerVentaPorIdUsuario(int IdUsuario)
        {
            VentaDTO venta = ventaService.ObtenerVentaPorIdUsuario(IdUsuario);

            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        [HttpPost]
        [Route("AgregarUnaVenta")]
        public IActionResult AgregarUnaVenta([FromBody] VentaDTO venta)
        {
            if (venta == null)
            {
                return BadRequest();
            }
            ventaService.AgregarUnaVenta(venta);

            return Ok();
        }

    }
}
