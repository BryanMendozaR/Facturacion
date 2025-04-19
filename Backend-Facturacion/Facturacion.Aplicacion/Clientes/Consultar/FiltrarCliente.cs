using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    public class FiltrarCliente : IRequest<RespuestaPaginadaModelo<ClienteModelo>>
    {
        public string Nombre { get; set; }
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public FiltrarCliente(string nombre, int pagina = 1, int tamanoPagina = 10) 
        { 
            this.Nombre = nombre;
            Pagina = pagina;
            TamanoPagina = tamanoPagina;
        }
    }
}
