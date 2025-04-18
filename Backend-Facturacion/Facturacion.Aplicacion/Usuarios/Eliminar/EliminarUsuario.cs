using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Eliminar
{
    public class EliminarUsuario : IRequest<Unit>
    {
        public int Codigo {  get; set; }

        public EliminarUsuario(int codigo)
        {
            Codigo = codigo;
        }
    }
}
