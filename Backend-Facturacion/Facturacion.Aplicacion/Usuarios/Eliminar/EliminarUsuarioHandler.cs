using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Eliminar
{
    internal class EliminarUsuarioHandler : IRequestHandler<EliminarUsuario, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public EliminarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el usuario
        /// </summary>
        /// <param name="request">Objeto con los datos del usuario</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public async Task<Unit> Handle(EliminarUsuario request, CancellationToken cancellationToken)
        {
            bool respuesta = await _usuarioRepositorio.EliminarAsync(request.Codigo);

            if (!respuesta)
                throw new Exception("Error al eliminar el usuario");

            return Unit.Value;
        }
    }
}
