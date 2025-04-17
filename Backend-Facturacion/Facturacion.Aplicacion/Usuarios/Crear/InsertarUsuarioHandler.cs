using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Crear
{
    internal class InsertarUsuarioHandler : IRequestHandler<InsertarUsuario, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public InsertarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

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
