using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Service
{
    public class VentaService
    {
        private CoderContext context;

        public VentaService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

    }
}
