using System;
using AkiChrono.Model.Dtos;
using FluentValidation;

namespace AkiChrono.Validators;

public class UserInputValidator : AbstractValidator<UserInputDto>
{
    public UserInputValidator()
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
            .GreaterThan(TimeSpan.Zero);
    }
}