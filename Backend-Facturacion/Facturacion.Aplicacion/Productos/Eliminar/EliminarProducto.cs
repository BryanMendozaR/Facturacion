using MediatR;

namespace Facturacion.Aplicacion.Productos.Eliminar
{
    public class EliminarProducto : IRequest<Unit>
    {
        public int Codigo { get; set; }

        public EliminarProducto(int codigo)
        {
            Codigo = codigo;
        }
    }
}
