namespace Facturacion.Dominio.General
{
    public class Respuesta
    {
        public bool Exito { get; set; } = true;
        public object? Data { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public int Codigo { get; set; } = 10000;
        public IList<string>? Errors { get; set; }
    }
}
