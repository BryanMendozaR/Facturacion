using Facturacion.Dominio.Modelos;
using Facturacion.Infraestructura.Datos.IRepositorios;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    internal class FiltrarUsuarioHandler : IRequestHandler<FiltrarUsuario, RespuestaPaginadaModelo<UsuarioModelo>>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /// <summary>
        /// Constructor de la clase para inyectar la interfaz del servicio
        /// </summary>
        /// <param name="usuarioRepositorio">Interfaz que implementa el servicio de usuario</param>
        public FiltrarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
        /// <summary>
        /// Implementacion para consultar usuarios segun el nombre
        /// </summary>
        /// <param name="request">Objeto con los datos del usuario</param>
        /// <param name="cancellationToken">Token de cancelacion del proceso</param>
        /// <returns>Lista con los datos de los usuarios</returns>
        public async Task<RespuestaPaginadaModelo<UsuarioModelo>> Handle(FiltrarUsuario request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Nombre.Trim()))
                return await _usuarioRepositorio.ConsultarAsync(request.Pagina, request.TamanoPagina);

            return await _usuarioRepositorio.ConsultarPorNombreAsync(request.Nombre, request.Pagina, request.TamanoPagina);
        }
    }
}
