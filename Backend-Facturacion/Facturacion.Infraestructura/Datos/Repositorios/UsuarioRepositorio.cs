using Dapper;
using Facturacion.Dominio.Dto;
using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using System.Data;

namespace Facturacion.Infraestructura.Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

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
