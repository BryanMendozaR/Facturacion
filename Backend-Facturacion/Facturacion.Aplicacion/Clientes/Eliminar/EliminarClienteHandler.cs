using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Eliminar
{
    internal class EliminarClienteHandler : IRequestHandler<EliminarCliente, Unit>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="clienteRepositorio">Interfaz que implementa el servicio de cliente</param>
        public EliminarClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el cliente
        /// </summary>
        /// <param name="request">Objeto con los datos del cliente</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(EliminarCliente request, CancellationToken cancellationToken)
        {
            bool respuesta = await _clienteRepositorio.EliminarAsync(request.Identificacion);

            if (!respuesta)
                throw new Exception("Error al eliminar el cliente");

            return Unit.Value;
        }
    }
}
