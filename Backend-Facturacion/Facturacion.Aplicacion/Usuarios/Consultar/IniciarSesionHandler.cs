using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    internal class IniciarSesionHandler : IRequestHandler<IniciarSesion, IniciarSesionModelo>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public IniciarSesionHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }

        /// <summary>
        /// Implementacion para iniciar sesion
        /// </summary>
        /// <param name="request">Objeto con los datos del usuario</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        /// <returns>Lista con los datos de los usuarios</returns>
        public Task<IniciarSesionModelo> Handle(IniciarSesion request, CancellationToken cancellationToken)
        {
            return _usuarioRepositorio.IniciarSesionAsync(request.Usuario, request.Clave);
        }
    }
}
