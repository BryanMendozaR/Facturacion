using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Consultar
{
    public class ConsultarProducto : IRequest<RespuestaPaginadaModelo<ProductoModelo>>
    {
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public ConsultarProducto(int pagina = 1, int tamanoPagina = 10) 
        {
            Pagina = pagina;
            TamanoPagina = tamanoPagina;
        }
    }
}
