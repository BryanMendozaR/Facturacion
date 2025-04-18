using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    public class ConsultarUsuario : IRequest<IList<UsuarioModelo>>
    {
    }
}
