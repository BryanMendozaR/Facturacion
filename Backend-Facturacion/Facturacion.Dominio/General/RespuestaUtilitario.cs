using Microsoft.Extensions.Logging;

namespace Facturacion.Dominio.General
{
    public class RespuestaUtilitario
    {
        /// <summary>
        /// Utilitario para mapear la respuesta del servicio
        /// </summary>
        /// <typeparam name="TResult">Modelo con los datos de entrada</typeparam>
        /// <param name="logger">Objeto para registrar errores</param>
        /// <param name="metodo">Funcion a ejecutar</param>
        /// <returns>Modelo con un formato definido para la respuesta</returns>
        public static async Task<Respuesta> GenerarRespuestaDto<TResult>(ILogger logger, Func<Task<TResult>> metodo)
        {
            Respuesta respuestaDto = new();
            try
            {
                respuestaDto.Data = await metodo();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                respuestaDto.Codigo = ex.HResult;
                respuestaDto.Exito = false;
                respuestaDto.Mensaje = ex.ToString();
                respuestaDto.Errors = new List<string> { ex.Message };
            }
            return respuestaDto;
        }
    }
}
