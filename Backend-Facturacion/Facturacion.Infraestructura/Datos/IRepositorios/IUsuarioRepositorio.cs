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
        Task<bool> InsertarUsuarioAsync(UsuarioModelo datosUsuario);
    }
}
