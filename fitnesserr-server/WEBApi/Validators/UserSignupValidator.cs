using FluentValidation;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class UserSignupValidator : AbstractValidator<UserCreateDto>
    {
        public UserSignupValidator()
        {
            RuleFor(u => u.UserName).Length(7, 40).WithMessage("Username is too short / long.");
            RuleFor(u => u.Password).Length(7, 40).WithMessage("Password is too short / long.");
        }
    }
}
