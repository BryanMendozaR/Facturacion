using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Productos.Consultar
{
    public class FiltrarProducto : IRequest<RespuestaPaginadaModelo<ProductoModelo>>
    {
        public string Filtro {  get; set; }
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public FiltrarProducto(string filtro, int pagina = 1, int tamanoPagina = 10)
        {
            Filtro = filtro;
            Pagina = pagina;
            TamanoPagina= tamanoPagina;
        }
    }
}
