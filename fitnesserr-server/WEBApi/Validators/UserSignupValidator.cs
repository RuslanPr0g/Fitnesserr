using FluentValidation;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class UserSignupValidator : AbstractValidator<UserCreateDto>
    {
        public UserSignupValidator()
        {
            RuleFor(u => u.UserName).MinimumLength(7).WithMessage("Username is too short.");
        }
    }
}
