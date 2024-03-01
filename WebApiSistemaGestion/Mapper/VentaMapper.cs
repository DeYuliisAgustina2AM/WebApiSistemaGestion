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

        public static Venta MapearDTOAVenta(VentaDTO VentaDTO)
        {
            Venta venta = new Venta();
            venta.Id = VentaDTO.Id;
            venta.Comentarios = VentaDTO.Comentarios;
            venta.IdUsuario = VentaDTO.IdUsuario;
            

            return venta;
        }
    }
}
