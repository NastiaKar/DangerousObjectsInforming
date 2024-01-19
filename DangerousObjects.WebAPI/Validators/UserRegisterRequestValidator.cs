using System.Text.RegularExpressions;
using DangerousObjectsCommon.Auth;
using FluentValidation;

namespace DangerousObjectsInforming.Validators;

public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&\.,:;])[A-Za-z\d@$!%*#?&\.,:;]+$");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"));
    }
}