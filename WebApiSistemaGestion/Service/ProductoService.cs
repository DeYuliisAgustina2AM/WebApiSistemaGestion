using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Service
{
    public class ProductoService
    {
        private CoderContext context;

        public ProductoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public ProductoDTO ObtenerProductoPorIdUsuario(int IdUsuario)
        {
            var usuario = context.Usuarios.Find(IdUsuario);

            if (usuario == null)
            {
                return null;
            }

            var producto = context.Productos.FirstOrDefault(p => p.IdUsuario == IdUsuario);
            if (producto == null)
            {
                return null;
            }

            return ProductoMapper.MapearProductoADTO(producto);
        }

        public bool AgregarUnProducto(ProductoDTO productoDTO)
        {
            Producto p = ProductoMapper.MapearDTOAProducto(productoDTO);

            this.context.Productos.Add(p);
            this.context.SaveChanges();
            return true;
        }

        public bool BorrarProductoPorId(int idUsuario, ProductoDTO productoDTO)
        {
            Producto? producto = this.context.Productos.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

            if (producto is not null)
            {
                this.context.Remove(producto);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool ActualizarProductoPorId(int idUsuario, ProductoDTO productoDTO)
        {
            Producto? producto = this.context.Productos.Where(p => p.IdUsuario == idUsuario).FirstOrDefault();

            if (producto is not null)
            {
                producto.PrecioVenta = productoDTO.PrecioVenta;
                producto.Stock = productoDTO.Stock;
                producto.Descripciones = productoDTO.Descripciones;
                producto.IdUsuario = productoDTO.IdUsuario;
                producto.Costo = productoDTO.Costo;

                this.context.Productos.Update(producto);
                this.context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
