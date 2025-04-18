using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Actualizar
{
    public class ActualizarDatosUsuario : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }


        public ActualizarDatosUsuario(ActualizarDatosUsuarioDto usuario)
        {
            Nombre = usuario.Nombre;
            Usuario = usuario.Usuario;
            Correo = usuario.Correo;
            Codigo = usuario.Codigo;
        }
    }
}
