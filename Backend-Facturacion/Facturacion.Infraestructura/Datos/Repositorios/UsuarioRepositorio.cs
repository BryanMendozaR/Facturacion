using Dapper;
using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using System.Data;

namespace Facturacion.Infraestructura.Datos.Repositorios
{
    /// <summary>
    /// Clase para la gestion de usuario
    /// </summary>
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Constructor para inyectar las dependencias
        /// </summary>
        /// <param name="dbConnection">Interfaz para la conexion a la base de datos</param>
        public UsuarioRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Metodo para insertar el usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la insercion del usuario</returns>
        public async Task<bool> InsertarUsuarioAsync(UsuarioModelo datosUsuario)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@i_nombre", datosUsuario.Nombre);
            parameters.Add("@i_usuario", datosUsuario.Usuario);
            parameters.Add("@i_correo", datosUsuario.Correo);
            parameters.Add("@i_clave", datosUsuario.Clave);

            int filasAfectadas = await _dbConnection.ExecuteAsync("spi_usuario", parameters, commandType: CommandType.StoredProcedure);
            return filasAfectadas > 0;
        }

    }
}
