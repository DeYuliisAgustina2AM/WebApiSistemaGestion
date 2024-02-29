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

        public ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            return context.ProductoVendidos.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<ProductoVendido> ObtenerProductosVendidosPorUsuario(int idUsuario)
        {
            return context.ProductoVendidos.Where(pv => pv.IdProducto == idUsuario).ToList();
        }

    }
}
