using System.Runtime.Intrinsics.X86;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Mapper
{
    public static class VentaMapper
    {
        public static VentaDTO MapearVentaADTO(Venta venta)
        {
            VentaDTO ventaDTO = new VentaDTO();
            ventaDTO.Id = venta.Id;
            ventaDTO.Comentarios = venta.Comentarios;
            ventaDTO.IdUsuario = venta.IdUsuario;
            

            return ventaDTO;
        }

        public static Venta MapearDTOAVenta(Venta dto)
        {
            Venta venta = new Venta();
            venta.Id = dto.Id;
            venta.Comentarios = dto.Comentarios;
            venta.IdUsuario = dto.IdUsuario;
            

            return venta;
        }
    }
}
