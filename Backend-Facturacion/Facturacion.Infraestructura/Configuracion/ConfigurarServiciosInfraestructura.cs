using Facturacion.Infraestructura.Datos.IRepositorios;
using Facturacion.Infraestructura.Datos.Repositorios;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Facturacion.Infraestructura.Configuracion
{
    public static class ConfigurarServiciosInfraestructura
    {
        /// <summary>
        /// Metodo para ejecutar la inyeccion de dependencia de los servicios a la coleccion
        /// </summary>
        /// <param name="services">Interfaz de los servicios registrados</param>
        /// <param name="connectionString">Cadena de conexión</param>
        public static void AgregarServicios(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
