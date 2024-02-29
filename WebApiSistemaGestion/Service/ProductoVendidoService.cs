using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Service
{
    public class ProductoVendidoService
    {
        private CoderContext context;

        public ProductoVendidoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public IEnumerable<Producto> ObtenerProductoPorIdUsuario(int idUsuario)
        {
            var productos = context.Productos.Where(p => p.IdUsuario == idUsuario).ToList();
            return productos;
        }


    }
}
