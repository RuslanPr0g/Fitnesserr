using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class ExerciseCreateValidator : AbstractValidator<ExerciseCreateDto>
    {
        public ExerciseCreateValidator()
        {
            RuleFor(e => e.Order).InclusiveBetween(0, 50).WithMessage("Wrong order.");
            RuleFor(e => e.Name).Length(5, 100).WithMessage("Too short or long name.");
            RuleFor(e => e.Description).Length(20, 300).WithMessage("Too short or long description.");
            RuleFor(e => e.TimeToComplete).InclusiveBetween(0, 3600).WithMessage("Too long time.");
            RuleFor(e => e.Times).InclusiveBetween(0, 9000).WithMessage("Too huge number.");
            RuleFor(e => e.ImageURL).NotEmpty().WithMessage("URL cannot be empty.");
        }
    }
}
