using System;
using AkiChrono.Model;
using AkiChrono.Model.Dtos;
using FluentValidation;

namespace AkiChrono.Validators;

public class UserInputValidator : AbstractValidator<UserInputDto>
{
    public UserInputValidator(Plane plane)
    {
        RuleFor(x => x.InputPilotName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(x => x.InputFlightDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage($"Data nie może być większa niż {DateTime.Now}");

        RuleFor(x => x.InputFlightTimeSum)
            .NotNull()
            .NotEmpty()
            .GreaterThan(plane.TotalTime)
            .WithMessage("Suma PDT nie może być niższa od poprzedniej");
    }
}