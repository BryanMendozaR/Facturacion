using MediatR;

namespace Facturacion.Aplicacion.Clientes.Eliminar
{
    public class EliminarCliente : IRequest<Unit>
    {
        public string Identificacion { get; set; }

        public EliminarCliente(string identificacion)
        {
            Identificacion = identificacion;
        }
    }
}
