using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Eliminar
{
    internal class EliminarProductoHandler : IRequestHandler<EliminarProducto, Unit>
    {
        private readonly IProductoRepositorio _productoRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="productoRepositorio">Interfaz que implementa el servicio de usuario</param>
        public EliminarProductoHandler(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el producto
        /// </summary>
        /// <param name="request">Objeto con los datos del producto</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(EliminarProducto request, CancellationToken cancellationToken)
        {
           bool respuesta = await _productoRepositorio.EliminarAsync(request.Codigo);

            if (!respuesta)
                throw new Exception("Error al eliminar el producto");

            return Unit.Value;
        }
    }
}
