using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Mapper
{
    public static class ProductoVendidoMapper
    {
        public static ProductoVendidoDTO MapearProductoVendidoADTO(ProductoVendido productoVendido)
        {
            ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
            
            productoVendidoDTO.IdProducto = productoVendido.IdProducto;
            productoVendidoDTO.IdVenta = productoVendido.IdVenta;
            productoVendidoDTO.Stock = productoVendido.Stock;
            productoVendidoDTO.Id = productoVendido.Id;

            return productoVendidoDTO;
        }

        public static ProductoVendido MapearDTOAProductoVendido(ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido productoVendido = new ProductoVendido();
            productoVendido.IdProducto = productoVendidoDTO.IdProducto;
            productoVendido.IdVenta = productoVendidoDTO.IdVenta;
            productoVendido.Stock = productoVendidoDTO.Stock;
            productoVendido.Id = productoVendidoDTO.Id;


            return productoVendido;
        }
    }
}
