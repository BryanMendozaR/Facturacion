using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Crear
{
    public class InsertarUsuario : IRequest<Unit>
    {
        public string? Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }

        public InsertarUsuario(CrearUsuarioDto usuario)
        {
            Nombre = usuario.Nombre;
            Usuario = usuario.Usuario;
            Clave = usuario.Clave;
            Correo = usuario.Correo;
        }
    }
}
