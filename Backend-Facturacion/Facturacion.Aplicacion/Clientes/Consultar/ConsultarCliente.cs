using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    public class ConsultarCliente : IRequest<IList<ClienteModelo>>
    {
    }
}
