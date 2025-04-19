using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Consultar
{
    internal class FiltrarProductoHandler : IRequestHandler<FiltrarProducto, RespuestaPaginadaModelo<ProductoModelo>>
    {
        private readonly IProductoRepositorio _productoRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="productoRepositorio">Interfaz que implementa el servicio de usuario</param>
        public FiltrarProductoHandler(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Implementacion para consultar filtrado
        /// </summary>
        /// <param name="request">Objeto con los datos del producto</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<RespuestaPaginadaModelo<ProductoModelo>> Handle(FiltrarProducto request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Filtro.Trim()))
                return await _productoRepositorio.ConsultarAsync(request.Pagina, request.TamanoPagina);

            return await _productoRepositorio.ConsultarFiltroAsync(request.Filtro, request.Pagina, request.TamanoPagina);
        }
    }
}
