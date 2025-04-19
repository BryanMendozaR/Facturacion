using Facturacion.Dominio.Modelos;

namespace Facturacion.Infraestructura.Datos.IRepositorios
{
    /// <summary>
    /// Interfaz para gestion de clientes
    /// </summary>
    public interface IClienteRepositorio
    {
        /// <summary>
        /// Metodo para insertar el cliente
        /// </summary>
        /// <param name="datosCliente">Objeto con los datos del cliente</param>
        /// <returns>Booleano para comprobar la insercion del cliente</returns>
        Task<bool> InsertarAsync(ClienteModelo datosCliente);

        /// <summary>
        /// Metodo para actualizar los datos del cliente
        /// </summary>
        /// <param name="datosCliente">Objeto con los datos del cliente</param>
        /// <returns>Booleano para comprobar la modificacion de los datos del cliente</returns>
        Task<bool> ActualizarDatosAsync(ClienteModelo datosCliente);

        /// <summary>
        /// Metodo para eliminar el cliente
        /// </summary>
        /// <param name="identificacion">Identificacion del cliente a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del cliente</returns>
        Task<bool> EliminarAsync(string identificacion);

        /// <summary>
        /// Metodo para consultar todos los clientes
        /// </summary>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista con todos los clientes</returns>
        Task<RespuestaPaginadaModelo<ClienteModelo>> ConsultarAsync(int numeroRegistro, int tamanoPagina);

        /// <summary>
        /// Metodo para consultar clientes segun el nombre
        /// </summary>
        /// <param name="nombre">Parametro de filtro</param>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista filtrada de todos los clientes</returns>
        Task<RespuestaPaginadaModelo<ClienteModelo>> ConsultarPorNombreAsync(string nombre, int numeroRegistro, int tamanoPagina);
    }
}
