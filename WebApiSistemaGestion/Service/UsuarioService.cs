using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;

namespace WebApiSistemaGestion.Service
{
    public class UsuarioService
    {
        private CoderContext context;

        public UsuarioService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public UsuarioDTO ObtenerUsuarioPorId(int id)
        {
            var usuario = context.Usuarios.Find(id);

            if (usuario == null)
            {
                return null;
            }
            return UsuarioMapper.MapearUsuarioADTO(usuario);
        }
    }
}
