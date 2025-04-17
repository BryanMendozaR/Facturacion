using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Facturacion.Aplicacion.Configuracion
{
    /// <summary>
    /// Manejador del pipeline de validacion de parametros de entrada
    /// </summary>
    /// <typeparam name="TRequest">Modelo de invocacion del servicio</typeparam>
    /// <typeparam name="TResponse">Modelo de mapeo a la logica de negocio</typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : notnull
    {
        /// <summary>
        /// Lista de errores resgitrados en la validacion
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Inicializa la lista de errores
        /// </summary>
        /// <param name="validators">Inyeccion de dependencia para la lista de validadores</param>
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Implementacion del pipeline de validacion de modelos
        /// </summary>
        /// <param name="request">Modelo de invocacion al servicio</param>
        /// <param name="next">Siguiente manejador a procesar luego de la respuesta</param>
        /// <param name="cancellationToken">Token de cancelacion de la ejecucion</param>
        /// <returns>Lista de errores encontrados en la validacion del modelo de entrada</returns>
        /// <exception cref="ValidationException">Excepcion con el detalle de la validacion de los campos</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                ValidationContext<TRequest> contexto = new ValidationContext<TRequest>(request);
                ValidationResult[]? resultadosValidacion = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(contexto, cancellationToken)));
                List<ValidationFailure> errores = resultadosValidacion.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (errores.Count != 0)
                {
                    throw new ValidationException(errores);
                }
            }

            return await next();
        }
    }
}
