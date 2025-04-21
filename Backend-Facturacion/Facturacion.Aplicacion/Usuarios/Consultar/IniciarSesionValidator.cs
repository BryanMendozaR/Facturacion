using FluentValidation;

namespace Facturacion.Aplicacion.Usuarios.Consultar
{
    internal class IniciarSesionValidator : AbstractValidator<IniciarSesion>
    {
        public IniciarSesionValidator()
        {
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("El usuario es obligatorio.")
                .MaximumLength(30).WithMessage("El usuario no debe exceder los 30 caracteres.");
            RuleFor(x => x.Clave).NotEmpty().WithMessage("La clave es obligatoria.");
        }
    }
}
