using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    internal class ConsultarClienteHandler : IRequestHandler<ConsultarCliente, RespuestaPaginadaModelo<ClienteModelo>>
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
        /// <param name="request">Objeto con las configuraciones para la paginacion</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<RespuestaPaginadaModelo<ClienteModelo>> Handle(ConsultarCliente request, CancellationToken cancellationToken)
        {
            return await _clienteRepositorio.ConsultarAsync(request.Pagina, request.TamanoPagina);
        }
    }
}
