using DangerousObjectsCommon.DTOs.DangerousObject;
using FluentValidation;

namespace DangerousObjectsInforming.Validators;

public class CreateDangerousObjectValidator : AbstractValidator<CreateDangerousObject>
{
    public CreateDangerousObjectValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
    }
}