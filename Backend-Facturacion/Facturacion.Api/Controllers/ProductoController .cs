using Facturacion.Aplicacion.Productos.Actualizar;
using Facturacion.Aplicacion.Productos.Consultar;
using Facturacion.Aplicacion.Productos.Crear;
using Facturacion.Aplicacion.Productos.Eliminar;
using Facturacion.Dominio.Dto;
using Facturacion.Dominio.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IMediator _mediator;
        protected Respuesta respuestaDto;

        /// <summary>
        /// Constructor para inicializar la inyeccion de dependencia 
        /// </summary>
        /// <param name="logger">Interfaz para registro de logs</param>
        /// <param name="mediator">Interfaz para la inyeccion de la libreria</param>
        public ProductoController(ILogger<ProductoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            respuestaDto = new Respuesta();
        }

        /// <summary>
        /// Metodo para insertar un usuario
        /// </summary>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearProducto([FromBody] ProductoDto producto)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new InsertarProducto(producto)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para consultar los usuarios
        /// </summary>
        /// <returns>Objeto con la lista de los usuarios</returns>
        [HttpGet]
        [Route("Consultar/{pagina}")]
        public async Task<IActionResult> ConsultarProducto([FromRoute] int pagina)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ConsultarProducto(pagina)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para actualizar los datos del usuario
        /// </summary>
        [HttpPut]
        [Route("Actualizar/Datos")]
        public async Task<IActionResult> ActualizarDatosProducto([FromBody] ActualizarDatosProductoDto datosProducto)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ActualizarProducto(datosProducto)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para eliminar el usuario
        /// </summary>
        [HttpDelete]
        [Route("Eliminar/{codigo}")]
        public async Task<IActionResult> EliminarUsuario([FromRoute] int codigo)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new EliminarProducto(codigo)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para filtrar por el nombre los usuarios
        /// </summary>
        /// <returns>Objeto con la lista de los usuarios</returns>
        [HttpGet]
        [Route("Filtrar/{filtro}/{pagina}")]
        public async Task<IActionResult> FiltrarUsuarios([FromRoute] string filtro, int pagina)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new FiltrarProducto(filtro, pagina)));
            return Ok(respuestaDto);

        }
    }
}
