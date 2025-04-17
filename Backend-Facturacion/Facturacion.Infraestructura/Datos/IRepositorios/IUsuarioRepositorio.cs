using Facturacion.Dominio.Modelos;

namespace Facturacion.Infraestructura.Datos.IRepositorios
{
    public interface IUsuarioRepositorio
    {
        Task<bool> InsertarUsuarioAsync(UsuarioModelo datosUsuario);
    }
}
