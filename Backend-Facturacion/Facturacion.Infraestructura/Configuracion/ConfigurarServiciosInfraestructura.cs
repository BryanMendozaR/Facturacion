using Facturacion.Infraestructura.Datos.IRepositorios;
using Facturacion.Infraestructura.Datos.Repositorios;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Facturacion.Infraestructura.Configuracion
{
    public static class ConfigurarServiciosInfraestructura
    {
        public static void AgregarServicios(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
