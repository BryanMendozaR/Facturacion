using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    internal class ConsultarUsuarioHandler : IRequestHandler<ConsultarUsuario, IList<UsuarioModelo>>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public ConsultarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Implementacion para consultar usuarios
        /// </summary>
        /// <param name="request">Objeto con los datos del usuario</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        /// <returns>Lista con los datos de los usuarios</returns>
        public async Task<IList<UsuarioModelo>> Handle(ConsultarUsuario request, CancellationToken cancellationToken)
        {
            return await _usuarioRepositorio.ConsultarAsync();
        }
    }
}
