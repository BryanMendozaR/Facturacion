using Facturacion.Dominio.Modelos;

namespace Facturacion.Infraestructura.Datos.IRepositorios
{
    public interface IProductoRepositorio
    {
        /// <summary>
        /// Metodo para insertar el producto
        /// </summary>
        /// <param name="datosProducto">Objeto con los datos del producto</param>
        /// <returns>Booleano para comprobar la insercion del producto</returns>
        Task<bool> InsertarAsync(ProductoModelo datosProducto);

        /// <summary>
        /// Metodo para actualizar los datos del producto
        /// </summary>
        /// <param name="datosProducto">Objeto con los datos del producto</param>
        /// <returns>Booleano para comprobar la modificacion de los datos del producto</returns>
        Task<bool> ActualizarDatosAsync(ProductoModelo datosProducto);

        /// <summary>
        /// Metodo para eliminar el producto
        /// </summary>
        /// <param name="codigo">Identificacion del producto a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del producto</returns>
        Task<bool> EliminarAsync(int codigo);

        /// <summary>
        /// Metodo para consultar todos los productos
        /// </summary>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista con todos los productos</returns>
        Task<RespuestaPaginadaModelo<ProductoModelo>> ConsultarAsync(int numeroRegistro, int tamanoPagina);

        /// <summary>
        /// Metodo para consultar productos segun el nombre
        /// </summary>
        /// <param name="filtro">Parametro de filtro</param>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista filtrada de todos los productos</returns>
        Task<RespuestaPaginadaModelo<ProductoModelo>> ConsultarFiltroAsync(string filtro, int numeroRegistro, int tamanoPagina);
    }
}
