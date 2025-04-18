using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Crear
{
    public class InsertarProducto : IRequest<Unit>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public InsertarProducto(ProductoDto datosProducto) 
        { 
            Codigo = datosProducto.Codigo;
            Nombre = datosProducto.Nombre;
            Precio = datosProducto.Precio;
        }
    }
}
