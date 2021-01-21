﻿using FluentValidation;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class UserSignupValidator : AbstractValidator<UserCreateDto>
    {
        public UserSignupValidator()
        {
            RuleFor(u => u.UserName).MinimumLength(10).WithMessage("Email too short. (here i)");
        }
    }
}