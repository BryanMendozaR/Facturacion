using Facturacion.Dominio.Modelos;
using MediatR;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    public class FiltrarUsuario : IRequest<RespuestaPaginadaModelo<UsuarioModelo>>
    {
        public string Nombre { get; set; }
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }

        public FiltrarUsuario(string nombre, int pagina = 1, int tamanoPagina = 10) 
        {
            Nombre = nombre;
            Pagina = pagina;
            TamanoPagina = tamanoPagina;
        }
    }
}
