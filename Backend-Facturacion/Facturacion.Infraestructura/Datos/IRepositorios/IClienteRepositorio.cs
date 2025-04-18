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
        /// <returns>Lista con todos los clientes</returns>
        Task<IList<ClienteModelo>> ConsultarAsync();

        /// <summary>
        /// Metodo para consultar clientes segun el nombre
        /// </summary>
        /// <returns>Lista filtrada de todos los clientes</returns>
        Task<IList<ClienteModelo>> ConsultarPorNombreAsync(string nombre);
    }
}
