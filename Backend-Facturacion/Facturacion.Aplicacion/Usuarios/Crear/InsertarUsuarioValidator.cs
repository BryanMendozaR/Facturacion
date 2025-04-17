using FluentValidation;

namespace Facturacion.Aplicacion.Usuarios.Crear
{
    public class InsertarUsuarioValidator : AbstractValidator<InsertarUsuario>
    {
        public InsertarUsuarioValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");
            RuleFor(x => x.Usuario).NotEmpty().WithMessage("El usuario es obligatorio.");
            RuleFor(x => x.Clave).NotEmpty().WithMessage("La clave es obligatoria.");
            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El correo no es válido.");
        }
    }
}
