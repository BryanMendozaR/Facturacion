using Facturacion.Dominio.Dto;
using MediatR;

namespace Facturacion.Aplicacion.Clientes.Actualizar
{
    public class ActualizarDatosCliente : IRequest<Unit>
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public ActualizarDatosCliente(ClienteDto cliente)
        {
            Identificacion = cliente.Identificacion;
            Nombre = cliente.Nombre;
            Telefono = cliente.Telefono;
            Correo = cliente.Correo;
            Direccion = cliente.Direccion;

        }
    }
}
