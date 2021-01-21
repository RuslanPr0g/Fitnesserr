using FluentValidation;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class UserSignupValidator : AbstractValidator<UserCreateDto>
    {
        public UserSignupValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Email cannot be empty.");
        }
    }
}
