using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Facturacion.Aplicacion.Configuracion
{
    public static class AplicacionExtension
    {
        /// <summary>
        /// Metodo para ejecutar la inyeccion de dependencia de los servicios a la coleccion
        /// </summary>
        /// <param name="iServices">Interfaz de los servicios registrados</param>
        /// <returns>Interfaz con los servicios registrados</returns>
        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection iServices)
        {
            iServices.AddMediatR(configuracion => configuracion.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            iServices.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            iServices.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return iServices;
        }
    }
}
