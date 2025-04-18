using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    internal class ConsultarClienteHandler : IRequestHandler<ConsultarCliente, IList<ClienteModelo>>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="clienteRepositorio">Interfaz que implementa el servicio de cliente</param>
        public ConsultarClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Implementacion para consultar los clientes
        /// </summary>
        /// <param name="request">Objeto con los datos del cliente</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<IList<ClienteModelo>> Handle(ConsultarCliente request, CancellationToken cancellationToken)
        {
            return await _clienteRepositorio.ConsultarAsync();
        }
    }
}
