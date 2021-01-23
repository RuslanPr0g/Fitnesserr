using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class TrainingCreateValidator : AbstractValidator<TrainingCreateDto>
    {
        public TrainingCreateValidator()
        {
            RuleFor(t => t.Name).Length(10, 100).WithMessage("Too long or short name.");
            RuleFor(t => t.Description).Length(20, 400).WithMessage("Too long or short description.");
            RuleFor(t => t.Type).Length(2, 100).WithMessage("Too long or short type.");
        }
    }
}
