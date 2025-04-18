﻿using FluentValidation;

namespace Facturacion.Aplicacion.Clientes.Actualizar
{
    internal class ActualizarDatosClienteValidators : AbstractValidator<ActualizarDatosCliente>
    {
        public ActualizarDatosClienteValidators() 
        {
            RuleFor(x => x.Identificacion).NotEmpty().WithMessage("El nombre es obligatorio.")
              .Length(10, 13).WithMessage("La identificación debe tener entre 10 y 13 caracteres."); ;

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es obligatorio.")
                .EmailAddress().WithMessage("El correo no es válido.");
        }
    }
}
