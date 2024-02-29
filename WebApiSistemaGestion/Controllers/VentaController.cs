using Microsoft.AspNetCore.Mvc;
using WebApiSistemaGestion.Models;
using WebApiSistemaGestion.Service;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VentaController : Controller
    {
        private VentaService VentaService;

        public VentaController(VentaService VentaService)
        {
            this.VentaService = VentaService;
        }

       

    }
}
