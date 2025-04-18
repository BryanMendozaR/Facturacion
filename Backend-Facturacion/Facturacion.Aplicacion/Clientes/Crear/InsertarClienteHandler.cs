using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Crear
{
    internal class InsertarClienteHandler : IRequestHandler<InsertarCliente, Unit>
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="clienteRepositorio">Interfaz que implementa el servicio de cliente</param>
        public InsertarClienteHandler(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el cliente
        /// </summary>
        /// <param name="request">Objeto con los datos del cliente</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(InsertarCliente request, CancellationToken cancellationToken)
        {
            bool respuesta = await _clienteRepositorio.InsertarAsync(new ClienteModelo { Identificacion = request.Identificacion, Nombre = request.Nombre, Telefono = request.Telefono, Correo = request.Correo, Direccion = request.Direccion });

            if (!respuesta)
                throw new Exception("Error al insertar el cliente");

            return Unit.Value;
        }
    }
}
