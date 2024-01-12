using DangerousObjectsCommon.DTOs.Message;
using FluentValidation;

namespace DangerousObjectsInforming.Validators;

public class CreateMessageValidator : AbstractValidator<CreateMessage>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
    }
}