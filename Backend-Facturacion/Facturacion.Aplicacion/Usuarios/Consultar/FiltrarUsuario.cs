using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    public class FiltrarUsuario : IRequest<IList<UsuarioModelo>>
    {
        public string Nombre { get; set; }

        public FiltrarUsuario(string nombre) 
        {
            Nombre = nombre;
        }
    }
}
