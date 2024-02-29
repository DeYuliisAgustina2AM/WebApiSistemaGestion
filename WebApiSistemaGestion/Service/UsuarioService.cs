using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.Database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.Models;

namespace WebApiSistemaGestion.Service
{
    public class UsuarioService
    {
        private CoderContext context;

        public UsuarioService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public UsuarioDTO ObtenerUsuarioPorId(int idUsuario)
        {
            var usuario = context.Usuarios.Find(idUsuario);

            if (usuario == null)
            {
                return null;
            }
            return UsuarioMapper.MapearUsuarioADTO(usuario);
        }

        public Usuario ObtenerUsuarioPorUsuarioYPassword(string nombreUsuario, string password)
        {
            Usuario usuario = context.Usuarios.SingleOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == password);
            return usuario;
        }

        public bool AgregarUnUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario u = UsuarioMapper.MapearDTOAUsuario(usuarioDTO);

            this.context.Usuarios.Add(u);
            this.context.SaveChanges();
            return true;
        }

        public bool ActualizarUsuario(int idUsuario, UsuarioDTO usuarioDTO)
        {
            Usuario? usuarioExistente = context.Usuarios.Find(idUsuario);

            if (usuarioExistente == null)
            {
                return false;
            }

            Usuario u = UsuarioMapper.MapearDTOAUsuario(usuarioDTO);
            usuarioExistente.NombreUsuario = u.NombreUsuario;
            usuarioExistente.Contraseña = u.Contraseña;
            usuarioExistente.Nombre = u.Nombre;
            usuarioExistente.Apellido = u.Apellido;
            usuarioExistente.Mail = u.Mail;
            usuarioExistente.Id = u.Id;

            context.Usuarios.Update(usuarioExistente);
            context.SaveChanges();
            return true;
        }

        public bool BorrarUsuarioPorId(int idUsuario, UsuarioDTO usuarioDTO)
        {
            Usuario? usuario = this.context.Usuarios.Where(p => p.Id == idUsuario).FirstOrDefault();

            if (usuario is not null)
            {
                this.context.Remove(usuario);
                this.context.SaveChanges();
                return true;
            }

            return false;
        }



    }
}
