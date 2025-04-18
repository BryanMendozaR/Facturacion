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
        /// <returns>Lista con todos los productos</returns>
        Task<IList<ProductoModelo>> ConsultarAsync();

        /// <summary>
        /// Metodo para consultar productos segun el nombre
        /// </summary>
        /// <param name="filtro">Parametro de filtro</param>
        /// <returns>Lista filtrada de todos los productos</returns>
        Task<IList<ProductoModelo>> ConsultarFiltroAsync(string filtro);
    }
}
