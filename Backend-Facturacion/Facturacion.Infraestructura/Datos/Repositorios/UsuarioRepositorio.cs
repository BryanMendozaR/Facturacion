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
        public async Task<bool> InsertarAsync(UsuarioModelo datosUsuario)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_nombre", datosUsuario.Nombre);
            parameters.Add("@i_usuario", datosUsuario.Usuario);
            parameters.Add("@i_correo", datosUsuario.Correo);
            parameters.Add("@i_clave", datosUsuario.Clave);

            return await _dbConnection.ExecuteAsync("spi_usuario", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para actualizar los datos del usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la modificacion del usuario</returns>
        public async Task<bool> ActualizarDatosAsync(UsuarioModelo datosUsuario)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_codigo_usuario", datosUsuario.Codigo);
            parameters.Add("@i_nombre", datosUsuario.Nombre);
            parameters.Add("@i_usuario", datosUsuario.Usuario);
            parameters.Add("@i_correo", datosUsuario.Correo);
            parameters.Add("@i_accion", 1);

            return await _dbConnection.ExecuteAsync("spu_usuario", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para actualizar la clave del usuario
        /// </summary>
        /// <param name="datosUsuario">Objeto con los datos del usuario</param>
        /// <returns>Booleano para comprobar la modificacion del usuario</returns>
        public async Task<bool> ActualizarClaveAsync(int codigo, string clave)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_codigo_usuario", codigo);
            parameters.Add("@i_clave", clave);
            parameters.Add("@i_accion", 0);

            return await _dbConnection.ExecuteAsync("spu_usuario", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para eliminar el usuario
        /// </summary>
        /// <param name="codigoUsuario">Codigo del usuario a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del usuario</returns>
        public async Task<bool> EliminarAsync(int codigoUsuario)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_codigo_usuario", codigoUsuario);

            return await _dbConnection.ExecuteAsync("spd_usuario", parameters, commandType: CommandType.StoredProcedure) > 0;
             
        }

        /// <summary>
        /// Metodo para consultar todos los usuarios
        /// </summary>
        /// <returns>Lista con todos los usuarios</returns>
        public async Task<IList<UsuarioModelo>> ConsultarAsync()
        {
            IEnumerable<UsuarioModelo> usuarios =  await _dbConnection.QueryAsync<UsuarioModelo>("sps_usuario", new DynamicParameters(), commandType: CommandType.StoredProcedure);
            return usuarios.ToList();
        }
    }
}
