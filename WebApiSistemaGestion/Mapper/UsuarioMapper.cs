using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Mapper
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO MapearUsuarioADTO(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Id = usuario.Id;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Contraseña = usuario.Contraseña;
            dto.Mail = usuario.Mail;

            return dto;
        }

        public static Usuario MapearDTOAUsuario(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.NombreUsuario = dto.NombreUsuario;
            usuario.Contraseña = dto.Contraseña;
            usuario.Mail = dto.Mail;

            return usuario;
        }

    }
}
