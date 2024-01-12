using DangerousObjectsCommon.DTOs.DangerousObject;
using FluentValidation;

namespace DangerousObjectsInforming.Validators;

public class UpdateDangerousObjectValidator : AbstractValidator<UpdateDangerousObject>
{
    public UpdateDangerousObjectValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
    }
}