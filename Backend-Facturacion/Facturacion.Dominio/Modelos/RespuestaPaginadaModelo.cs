namespace Facturacion.Dominio.Modelos
{
    public class RespuestaPaginadaModelo<T>
    {
        public IList<T> Datos { get; set; } = [];
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas => (int)Math.Ceiling((double)TotalRegistros / TamanoPagina);
    }
}
