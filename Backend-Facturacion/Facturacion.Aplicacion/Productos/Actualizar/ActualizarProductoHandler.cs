using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Actualizar
{
    internal class ActualizarProductoHandler : IRequestHandler<ActualizarProducto, Unit>
    {
        private readonly IProductoRepositorio _productoRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="productoRepositorio">Interfaz que implementa el servicio de usuario</param>
        public ActualizarProductoHandler(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el producto
        /// </summary>
        /// <param name="request">Objeto con los datos del producto</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(ActualizarProducto request, CancellationToken cancellationToken)
        {
           bool respuesta = await _productoRepositorio.ActualizarDatosAsync(new ProductoModelo { Identificador = request.Identificador, Codigo = request.Codigo, Nombre = request.Nombre, Estado = request.Estado, Precio = request.Precio });

            if (!respuesta)
                throw new Exception("Error al actualizar los datos del producto");

            return Unit.Value;

        }
    }
}
