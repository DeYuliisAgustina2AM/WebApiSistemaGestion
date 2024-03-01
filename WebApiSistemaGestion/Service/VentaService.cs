using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
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

        public VentaDTO ObtenerVentaPorIdUsuario(int idUsuario)
        {
            Venta? v = context.Venta.Where(v => v.IdUsuario == idUsuario).FirstOrDefault();
            return VentaMapper.MapearVentaADTO(v);
        }


        //agregar una venta por idusuario
        public bool AgregarUnaVenta(VentaDTO ventaDTO)
        {
            Venta v = VentaMapper.MapearDTOAVenta(ventaDTO);

            this.context.Venta.Add(v);
            this.context.SaveChanges();
            return true;
        }
    }
}
