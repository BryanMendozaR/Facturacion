namespace Facturacion.Dominio.Modelos
{
    public class IniciarSesionModelo
    {
        public int? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Usuario { get; set; }
        public string? Correo { get; set; }
        public bool? Inicio { get; set; } = false;
    }
}
