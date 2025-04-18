using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Actualizar
{
    internal class ActualizarClaveUsuarioHandler : IRequestHandler<ActualizarClaveUsuario, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public ActualizarClaveUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Implementacion del metodo para actualizar los datos del usuario
        /// </summary>
        public async Task<Unit> Handle(ActualizarClaveUsuario request, CancellationToken cancellationToken)
        {
            await _usuarioRepositorio.ActualizarClaveAsync(request.Codigo, request.Clave);
            return Unit.Value;
        }
    }
}
