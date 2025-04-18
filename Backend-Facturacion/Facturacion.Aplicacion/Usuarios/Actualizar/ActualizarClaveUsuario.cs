using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Actualizar
{
    public class ActualizarClaveUsuario : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string Clave { get; set; }
        public ActualizarClaveUsuario(ActualizarClaveUsuarioDto datosUsuario) 
        { 
            Codigo = datosUsuario.Codigo;
            Clave = datosUsuario.Clave;
        }
    }
}
