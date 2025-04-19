using Facturacion.Dominio.Modelos;

namespace Facturacion.Infraestructura.Datos.IRepositorios
{
    /// <summary>
    /// Interfaz para gestion de usuarios
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Metodo para insertar el usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la insercion del usuario</returns>
        Task<bool> InsertarAsync(UsuarioModelo datosUsuario);

        /// <summary>
        /// Metodo para actualizar los datos del usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la modificacion del usuario</returns>
        Task<bool> ActualizarDatosAsync(UsuarioModelo datosUsuario);

        /// <summary>
        /// Metodo para actualizar la clave del usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la modificacion del usuario</returns>
        Task<bool> ActualizarClaveAsync(int codigo, string clave);

        /// <summary>
        /// Metodo para eliminar el usuario
        /// </summary>
        /// <param name="codigoUsuario">Codigo del usuario a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del usuario</returns>
        Task<bool> EliminarAsync(int codigoUsuario);

        /// <summary>
        /// Metodo para consultar todos los usuarios
        /// </summary>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista con todos los usuarios</returns>
        Task<RespuestaPaginadaModelo<UsuarioModelo>> ConsultarAsync(int numeroRegistro, int tamanoPagina);

        /// <summary>
        /// Metodo para consultar usuarios por nombre
        /// </summary>
        /// <param name="nombre">Parametro de filtro</param>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista de usuarios paginada</returns>
        Task<RespuestaPaginadaModelo<UsuarioModelo>> ConsultarPorNombreAsync(string nombre, int numeroRegistro, int tamanoPagina);
    }
}
