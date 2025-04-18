namespace Facturacion.Dominio.Dto
{
    public class ActualizarDatosProductoDto
    {
        public int Identificador { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Estado { get; set; }
    }
}
