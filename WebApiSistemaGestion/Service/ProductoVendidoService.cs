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

        public List<ProductoVendido> ObtenerProductosVendidosPorIdUsuario(int idUsuario)
        {
            // Obtén todos los productos que pertenecen al usuario con el idUsuario proporcionado
            var productos = context.Productos.Where(p => p.IdUsuario == idUsuario).ToList();

            if (productos == null || !productos.Any())
            {
                // Aquí puedes manejar el caso en que no se encuentren productos para el usuario
                // Por ejemplo, podrías lanzar una excepción o devolver una lista vacía
                return new List<ProductoVendido>();
            }

            // Obtén todos los productos vendidos
            var productosVendidos = context.ProductosVendidos.ToList();

            if (productosVendidos == null || !productosVendidos.Any())
            {
                // Aquí puedes manejar el caso en que no se encuentren productos vendidos
                // Por ejemplo, podrías lanzar una excepción o devolver una lista vacía
                return new List<ProductoVendido>();
            }

            // Filtra los productos vendidos para obtener solo aquellos que el usuario ha vendido
            var resultadoFinal = productosVendidos.Where(pv => productos.Any(p => p.Id == pv.IdProducto)).ToList();

            return resultadoFinal;
        }



    }
}
