﻿using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisValidator: AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio.");
        }

    }
}
