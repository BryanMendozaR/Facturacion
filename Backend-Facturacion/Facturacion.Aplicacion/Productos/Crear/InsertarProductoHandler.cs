using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Crear
{
    internal class InsertarProductoHandler : IRequestHandler<InsertarProducto, Unit>
    {
        private readonly IProductoRepositorio _productoRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="productoRepositorio">Interfaz que implementa el servicio de usuario</param>
        public InsertarProductoHandler(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el producto
        /// </summary>
        /// <param name="request">Objeto con los datos del producto</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(InsertarProducto request, CancellationToken cancellationToken)
        {
           bool respuesta = await _productoRepositorio.InsertarAsync(new ProductoModelo { Nombre= request.Nombre, Codigo= request.Codigo, Precio= request.Precio });

            if (!respuesta)
                throw new Exception("Error al insertar el producto");

            return Unit.Value;
        }
    }
}
