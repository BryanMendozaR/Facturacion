using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Consultar
{
    internal class ConsultarProductoHandler : IRequestHandler<ConsultarProducto, RespuestaPaginadaModelo<ProductoModelo>>
    {
        private readonly IProductoRepositorio _productoRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="productoRepositorio">Interfaz que implementa el servicio de usuario</param>
        public ConsultarProductoHandler(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el producto
        /// </summary>
        /// <param name="request">Objeto con los datos del producto</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<RespuestaPaginadaModelo<ProductoModelo>> Handle(ConsultarProducto request, CancellationToken cancellationToken)
        {
            return await _productoRepositorio.ConsultarAsync(request.Pagina,request.TamanoPagina);
        }
    }
}
