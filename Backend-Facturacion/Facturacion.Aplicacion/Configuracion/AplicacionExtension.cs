using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Facturacion.Aplicacion.Configuracion
{
    public static class AplicacionExtension
    {
        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection iServices)
        {
            iServices.AddMediatR(configuracion => configuracion.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            iServices.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            iServices.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return iServices;
        }
    }
}
