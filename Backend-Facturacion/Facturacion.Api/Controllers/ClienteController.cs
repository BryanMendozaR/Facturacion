using Facturacion.Aplicacion.Clientes.Actualizar;
using Facturacion.Aplicacion.Clientes.Consultar;
using Facturacion.Aplicacion.Clientes.Crear;
using Facturacion.Aplicacion.Clientes.Eliminar;
using Facturacion.Dominio.Dto;
using Facturacion.Dominio.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediator _mediator;
        protected Respuesta respuestaDto;

        /// <summary>
        /// Constructor para inicializar la inyeccion de dependencia 
        /// </summary>
        /// <param name="logger">Interfaz para registro de logs</param>
        /// <param name="mediator">Interfaz para la inyeccion de la libreria</param>
        public ClienteController(ILogger<ClienteController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            respuestaDto = new Respuesta();
        }

        /// <summary>
        /// Metodo para insertar un cliente
        /// </summary>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteDto datosCliente)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new InsertarCliente(datosCliente)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para consultar los clientes
        /// </summary>
        /// <returns>Objeto con la lista de los clientes</returns>
        [HttpGet]
        [Route("Consultar")]
        public async Task<IActionResult> ConsultarClientes()
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ConsultarCliente()));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para actualizar los datos del cliente
        /// </summary>
        [HttpPut]
        [Route("Actualizar/Datos")]
        public async Task<IActionResult> ActualizarDatos([FromBody] ClienteDto datosCliente)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ActualizarDatosCliente(datosCliente)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para eliminar el cliente
        /// </summary>
        [HttpDelete]
        [Route("Eliminar/{identificacion}")]
        public async Task<IActionResult> Eliminar([FromRoute] string identificacion)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new EliminarCliente(identificacion)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para filtrar por el nombre los clientes
        /// </summary>
        /// <returns>Objeto con la lista de los clientes</returns>
        [HttpGet]
        [Route("Filtrar/{nombre}")]
        public async Task<IActionResult> Filtrar([FromRoute] string nombre)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new FiltrarCliente(nombre)));
            return Ok(respuestaDto);
        }
    }
}
