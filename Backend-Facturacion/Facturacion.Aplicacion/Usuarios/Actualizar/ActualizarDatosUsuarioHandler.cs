using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Actualizar
{
    internal class ActualizarDatosUsuarioHandler : IRequestHandler<ActualizarDatosUsuario, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public ActualizarDatosUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Implementacion del metodo para actualizar los datos del usuario
        /// </summary>
        public async Task<Unit> Handle(ActualizarDatosUsuario request, CancellationToken cancellationToken)
        {
            bool respuesta = await _usuarioRepositorio.ActualizarDatosAsync(new UsuarioModelo { Codigo = request.Codigo, Nombre = request.Nombre, Usuario= request.Usuario, Correo = request.Correo });

            if (!respuesta)
                throw new Exception("Error al actualizar los datos del usuario");

            return Unit.Value;
        }
    }
}
