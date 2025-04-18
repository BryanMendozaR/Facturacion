using Facturacion.Aplicacion.Usuarios.Actualizar;
using Facturacion.Aplicacion.Usuarios.Consultar;
using Facturacion.Aplicacion.Usuarios.Crear;
using Facturacion.Aplicacion.Usuarios.Eliminar;
using Facturacion.Dominio.Dto;
using Facturacion.Dominio.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;
        protected Respuesta respuestaDto;

        /// <summary>
        /// Constructor para inicializar la inyeccion de dependencia 
        /// </summary>
        /// <param name="logger">Interfaz para registro de logs</param>
        /// <param name="mediator">Interfaz para la inyeccion de la libreria</param>
        public UsuarioController(ILogger<UsuarioController> logger, IMediator mediator)
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
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto usuario)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new InsertarUsuario(usuario)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para consultar los usuarios
        /// </summary>
        /// <returns>Objeto con la lista de los usuarios</returns>
        [HttpGet]
        [Route("Consultar")]
        public async Task<IActionResult> ConsultarUsuarios()
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ConsultarUsuario()));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para actualizar los datos del usuario
        /// </summary>
        [HttpPut]
        [Route("Actualizar/Datos")]
        public async Task<IActionResult> ActualizarDatosUsuario([FromBody] ActualizarDatosUsuarioDto datosUsuario)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ActualizarDatosUsuario(datosUsuario)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para actualizar la clave del usuario
        /// </summary>
        [HttpPut]
        [Route("Actualizar/Clave")]
        public async Task<IActionResult> ActualizarClaveUsuario([FromBody] ActualizarClaveUsuarioDto datosUsuario)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new ActualizarClaveUsuario(datosUsuario)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para eliminar el usuario
        /// </summary>
        [HttpDelete]
        [Route("Eliminar/{codigo}")]
        public async Task<IActionResult> EliminarUsuario([FromRoute] int codigo)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new EliminarUsuario(codigo)));
            return Ok(respuestaDto);

        }

        /// <summary>
        /// Metodo para filtrar por el nombre los usuarios
        /// </summary>
        /// <returns>Objeto con la lista de los usuarios</returns>
        [HttpGet]
        [Route("Filtrar/{nombre}")]
        public async Task<IActionResult> FiltrarUsuarios([FromRoute] string nombre)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new FiltrarUsuario(nombre)));
            return Ok(respuestaDto);

        }
    }
}
