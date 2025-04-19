using Dapper;
using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using System.Data;

namespace Facturacion.Infraestructura.Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IDbConnection _dbConnection;

        /// <summary>
        /// Constructor para inyectar las dependencias
        /// </summary>
        /// <param name="dbConnection">Interfaz para la conexion a la base de datos</param>
        public ClienteRepositorio(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Metodo para insertar el cliente
        /// </summary>
        /// <param name="datosCliente">Objeto con los datos del cliente</param>
        /// <returns>Booleano para comprobar la insercion del cliente</returns>
        public async Task<bool> InsertarAsync(ClienteModelo datosCliente)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_identificacion", datosCliente.Identificacion);
            parameters.Add("@i_nombre", datosCliente.Nombre);
            parameters.Add("@i_correo", datosCliente.Correo);
            parameters.Add("@i_telefono", datosCliente.Telefono);
            parameters.Add("@i_direccion", datosCliente.Direccion);

            return await _dbConnection.ExecuteAsync("spi_cliente", parameters, commandType: CommandType.StoredProcedure) > 0;
        }

        /// <summary>
        /// Metodo para actualizar los datos del cliente
        /// </summary>
        /// <param name="datosCliente">Objeto con los datos del cliente</param>
        /// <returns>Booleano para comprobar la modificacion de los datos del cliente</returns>
        public async Task<bool> ActualizarDatosAsync(ClienteModelo datosCliente)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_identificacion", datosCliente.Identificacion);
            parameters.Add("@i_nombre", datosCliente.Nombre);
            parameters.Add("@i_correo", datosCliente.Correo);
            parameters.Add("@i_telefono", datosCliente.Telefono);
            parameters.Add("@i_direccion", datosCliente.Direccion);

            return await _dbConnection.ExecuteAsync("spu_cliente", parameters, commandType: CommandType.StoredProcedure) > 0;
        }


        /// <summary>
        /// Metodo para eliminar el cliente
        /// </summary>
        /// <param name="identificacion">Identificacion del cliente a eliminar</param>
        /// <returns>Booleano para comprobar la eliminacion del cliente</returns>
        public async Task<bool> EliminarAsync(string identificacion)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_identificacion", identificacion);

            return await _dbConnection.ExecuteAsync("spd_cliente", parameters, commandType: CommandType.StoredProcedure) > 0;

        }

        /// <summary>
        /// Metodo para consultar todos los clientes
        /// </summary>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista con todos los clientes</returns>
        public async Task<RespuestaPaginadaModelo<ClienteModelo>> ConsultarAsync(int numeroRegistro, int tamanoPagina)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_numero_registros", numeroRegistro);
            parameters.Add("@i_tamanio_pagina", tamanoPagina);
            parameters.Add("@total_registros", dbType: DbType.Int32, direction: ParameterDirection.Output);

            IEnumerable<ClienteModelo> clientes = await _dbConnection.QueryAsync<ClienteModelo>("sps_cliente", new DynamicParameters(), commandType: CommandType.StoredProcedure);
            int totalRegistros = parameters.Get<int>("@total_registros");

            return new RespuestaPaginadaModelo<ClienteModelo>
            {
                Datos = clientes.ToList(),
                TotalRegistros = totalRegistros,
                PaginaActual = numeroRegistro,
                TamanoPagina = tamanoPagina
            };
        }

        /// <summary>
        /// Metodo para consultar clientes segun el nombre
        /// </summary>
        /// <param name="nombre">Parametro de filtro</param>
        /// <param name="numeroRegistro">Numero de registro en la pagina</param>
        /// <param name="tamanoPagina">Tamano de la pagina</param>
        /// <returns>Lista filtrada de todos los clientes</returns>
        public async Task<RespuestaPaginadaModelo<ClienteModelo>> ConsultarPorNombreAsync(string nombre, int numeroRegistro, int tamanoPagina)
        {
            DynamicParameters parameters = new();
            parameters.Add("@i_nombre", nombre);
            parameters.Add("@i_numero_registros", numeroRegistro);
            parameters.Add("@i_tamanio_pagina", tamanoPagina);
            parameters.Add("@total_registros", dbType: DbType.Int32, direction: ParameterDirection.Output);

            IEnumerable<ClienteModelo> clientes = await _dbConnection.QueryAsync<ClienteModelo>("sps_cliente", parameters, commandType: CommandType.StoredProcedure);
            int totalRegistros = parameters.Get<int>("@total_registros");

            return new RespuestaPaginadaModelo<ClienteModelo>
            {
                Datos = clientes.ToList(),
                TotalRegistros = totalRegistros,
                PaginaActual = numeroRegistro,
                TamanoPagina = tamanoPagina
            };
        }
    }
}
