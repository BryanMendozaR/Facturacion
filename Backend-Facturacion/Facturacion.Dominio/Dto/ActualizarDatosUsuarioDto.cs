namespace Facturacion.Dominio.Dto
{
    public class ActualizarDatosUsuarioDto
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
    }
}
