using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.Name).Length(2, 40).WithMessage("Name is too short / long.");
            RuleFor(u => u.LastName).Length(2, 40).WithMessage("Lastnaame is too short / long.");
            RuleFor(u => u.Password).Length(7, 40).WithMessage("Password is too short / long.");
            RuleFor(u => u.Score).LessThanOrEqualTo(int.MaxValue).WithMessage("Score is too long.");
            RuleFor(u => u.UserName).Length(7, 40).WithMessage("Username is too short / long.");
            RuleFor(u => u.Email).Length(7, 40).WithMessage("Email is too short / long.");
            RuleFor(u => u.DateOfBirth).LessThanOrEqualTo(DateTime.Now).WithMessage("Date is invalid.");
        }
    }
}
