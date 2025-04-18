using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Consultar
{
    public class FiltrarCliente : IRequest<IList<ClienteModelo>>
    {
        public string Nombre { get; set; }

        public FiltrarCliente(string nombre) 
        { 
            this.Nombre = nombre;
        }
    }
}
