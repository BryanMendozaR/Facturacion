using FluentValidation;

namespace Facturacion.Aplicacion.Usuarios.Actualizar
{
    internal class ActualizarDatosUsuarioValidator : AbstractValidator<ActualizarDatosUsuario>
    {
        public ActualizarDatosUsuarioValidator() 
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("El usuario es obligatorio.");
            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El correo no es válido.");
        }
    }
}
