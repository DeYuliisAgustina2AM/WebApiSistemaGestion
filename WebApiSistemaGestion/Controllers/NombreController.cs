using Microsoft.AspNetCore.Mvc;

namespace WebApiSistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NombreController : Controller
    {
        [HttpGet]
        public string ObtenerNombre()
        {
            return "Agustina De Yuliis";
        }
    }
}
