using Dapper;
using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using System.Data;

namespace Facturacion.Infraestructura.Datos.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Constructor para inyectar las dependencias
        /// </summary>
        /// <param name="dbConnection">Interfaz para la conexion a la base de datos</param>
        public ProductoRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Metodo para insertar el producto
        /// </summary>
        /// <param name="datosProducto">Objeto con los datos del producto</param>
        /// <returns>Booleano para comprobar la insercion del producto</returns>
        public async Task<bool> InsertarAsync(ProductoModelo datosProducto)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_codigo", datosProducto.Codigo);
            parameters.Add("@i_nombre", datosProducto.Nombre);
            parameters.Add("@i_precio", datosProducto.Precio);

            return await _dbConnection.ExecuteAsync("spi_producto", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para actualizar los datos del producto
        /// </summary>
        /// <param name="datosProducto">Objeto con los datos del producto</param>
        /// <returns>Booleano para comprobar la modificacion de los datos del producto</returns>
        public async Task<bool> ActualizarDatosAsync(ProductoModelo datosProducto)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_id", datosProducto.Identificador);
            parameters.Add("@i_codigo", datosProducto.Codigo);
            parameters.Add("@i_nombre", datosProducto.Nombre);
            parameters.Add("@i_precio", datosProducto.Precio);
            parameters.Add("@i_estado", datosProducto.Estado);

            return await _dbConnection.ExecuteAsync("spu_producto", parameters, commandType: CommandType.StoredProcedure) > 0;
        }


        /// <summary>
        /// Metodo para eliminar el producto
        /// </summary>
        /// <param name="codigo">Identificacion del producto a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del producto</returns>
        public async Task<bool> EliminarAsync(int codigo)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_id", codigo);

            return await _dbConnection.ExecuteAsync("spd_producto", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para consultar todos los productos
        /// </summary>
        /// <returns>Lista con todos los productos</returns>
        public async Task<IList<ProductoModelo>> ConsultarAsync()
        {
            IEnumerable<ProductoModelo> productos = await _dbConnection.QueryAsync<ProductoModelo>("sps_producto", new DynamicParameters(), commandType: CommandType.StoredProcedure);
            return productos.ToList();
        }

        /// <summary>
        /// Metodo para consultar productos segun el nombre
        /// </summary>
        /// <param name="filtro">Parametro de filtro</param>
        /// <returns>Lista filtrada de todos los productos</returns>
        public async Task<IList<ProductoModelo>> ConsultarFiltroAsync(string filtro)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_nombre", filtro);

            IEnumerable<ProductoModelo> productos = await _dbConnection.QueryAsync<ProductoModelo>("sps_producto", parameters, commandType: CommandType.StoredProcedure);
            return productos.ToList();
        }
    }
}
