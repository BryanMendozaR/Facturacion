using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Crear
{
    public class InsertarCliente : IRequest<Unit>
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public InsertarCliente(ClienteDto datosCliente)
        {
            Identificacion= datosCliente.Identificacion;
            Nombre= datosCliente.Nombre;
            Telefono= datosCliente.Telefono;
            Correo= datosCliente.Correo;
            Direccion= datosCliente.Direccion;
        }
    }
}
