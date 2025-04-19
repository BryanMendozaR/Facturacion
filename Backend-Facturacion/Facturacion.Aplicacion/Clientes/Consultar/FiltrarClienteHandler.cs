using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    internal class FiltrarClienteHandler : IRequestHandler<FiltrarCliente, RespuestaPaginadaModelo<ClienteModelo>>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="clienteRepositorio">Interfaz que implementa el servicio de cliente</param>
        public FiltrarClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Implementacion para consultar los clientes
        /// </summary>
        /// <param name="request">Objeto con los datos del cliente</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<RespuestaPaginadaModelo<ClienteModelo>> Handle(FiltrarCliente request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Nombre.Trim()))
                return await _clienteRepositorio.ConsultarAsync(request.Pagina, request.TamanoPagina);

            return await _clienteRepositorio.ConsultarPorNombreAsync(request.Nombre, request.Pagina, request.TamanoPagina);
        }
    }
}
