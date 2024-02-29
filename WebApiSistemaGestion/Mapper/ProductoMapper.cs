using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Mapper
{
    public static class ProductoMapper
    {
        public static ProductoDTO MapearProductoADTO(Producto producto)
        {
            ProductoDTO ProductoDTO = new ProductoDTO();
            ProductoDTO.PrecioVenta = producto.PrecioVenta;
            ProductoDTO.Costo = producto.Costo;
            ProductoDTO.Descripciones = producto.Descripciones;
            ProductoDTO.Stock = producto.Stock;
            ProductoDTO.Id = producto.Id;
            ProductoDTO.IdUsuario = producto.IdUsuario;

            return ProductoDTO;
        }

        public static Producto MapearDTOAProducto(ProductoDTO dto)
        {
            Producto producto = new Producto();
            producto.PrecioVenta = dto.PrecioVenta;
            producto.Costo = dto.Costo;
            producto.Descripciones = dto.Descripciones;
            producto.Stock = dto.Stock;
            producto.Id = dto.Id;
            producto.IdUsuario = dto.IdUsuario;

            return producto;
        }


    }
}
