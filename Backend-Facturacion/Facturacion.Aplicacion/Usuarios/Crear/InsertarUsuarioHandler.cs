using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Crear
{
    internal class InsertarUsuarioHandler : IRequestHandler<InsertarUsuario, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public InsertarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Implementacion para insertar el usuario
        /// </summary>
        /// <param name="request">Objeto con los datos del usuario</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        public  async Task<Unit> Handle(InsertarUsuario request, CancellationToken cancellationToken)
        {
           bool respuesta = await _usuarioRepositorio.InsertarUsuarioAsync(new UsuarioModelo
            {
                Nombre = request.Nombre,
                Usuario = request.Usuario,
                Clave = request.Clave,
                Correo = request.Correo
            });

             if (!respuesta)
                throw new Exception("Error al insertar el usuario");

            return Unit.Value;
        }
    }
}
