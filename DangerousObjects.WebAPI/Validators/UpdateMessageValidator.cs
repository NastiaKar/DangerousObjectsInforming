using DangerousObjectsCommon.DTOs.Message;
using FluentValidation;

namespace DangerousObjectsInforming.Validators;

public class UpdateMessageValidator : AbstractValidator<UpdateMessage>
{
    public UpdateMessageValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
    }
}