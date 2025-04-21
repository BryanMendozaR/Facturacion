using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    public class IniciarSesion : IRequest<IniciarSesionModelo>
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public IniciarSesion(string usuario, string clave)
        {
            Usuario = usuario;
            Clave = clave;
        }
    }
}
