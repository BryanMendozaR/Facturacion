using Facturacion.Aplicacion.Usuarios.Crear;
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
        /// <param name="usuario">Objeto con los datos del usuario</param>
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearUsuario(UsuarioDto usuario)
        {
            respuestaDto = await RespuestaUtilitario.GenerarRespuestaDto(_logger, async () => await _mediator.Send(new InsertarUsuario(usuario)));
            return Ok(respuestaDto);

        }
    }
}
