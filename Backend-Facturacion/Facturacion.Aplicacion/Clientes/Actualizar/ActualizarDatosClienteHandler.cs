using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Actualizar
{
    internal class ActualizarDatosClienteHandler : IRequestHandler<ActualizarDatosCliente, Unit>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="clienteRepositorio">Interfaz que implementa el servicio de cliente</param>
        public ActualizarDatosClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Implementacion para actualizar los datos del cliente
        /// </summary>
        /// <param name="request">Objeto con los datos del cliente</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(ActualizarDatosCliente request, CancellationToken cancellationToken)
        {
           bool respuesta = await _clienteRepositorio.ActualizarDatosAsync(new ClienteModelo { Identificacion = request.Identificacion, Nombre = request.Nombre, Telefono = request.Telefono, Correo = request.Correo, Direccion = request.Direccion });

            if (!respuesta)
                throw new Exception("Error al actualizar los datos del cliente");

            return Unit.Value;

        }
    }
}
