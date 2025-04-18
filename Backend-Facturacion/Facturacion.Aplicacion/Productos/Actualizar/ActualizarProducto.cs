using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Actualizar
{
    public class ActualizarProducto : IRequest<Unit>
    {
        public int Identificador { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Estado { get; set; }

        public ActualizarProducto(ActualizarDatosProductoDto datosProducto)
        {
            Identificador = datosProducto.Identificador;
            Codigo = datosProducto.Codigo;
            Nombre = datosProducto.Nombre;
            Precio = datosProducto.Precio;
            Estado = datosProducto.Estado;
        }
    }
}
