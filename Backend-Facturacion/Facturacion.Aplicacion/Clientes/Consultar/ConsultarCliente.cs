using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    public class ConsultarCliente : IRequest<RespuestaPaginadaModelo<ClienteModelo>>
    {
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public ConsultarCliente(int pagina = 1, int tamanoPagina = 10)
        {
            Pagina = pagina;
            TamanoPagina = tamanoPagina;
        }
    }
}
