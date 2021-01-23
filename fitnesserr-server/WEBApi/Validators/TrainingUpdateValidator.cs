using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class TrainingUpdateValidator : AbstractValidator<TrainingUpdateDto>
    {
        public TrainingUpdateValidator()
        {
            RuleFor(t => t.Name).Length(10, 100).WithMessage("Too long or short name.");
            RuleFor(t => t.Description).Length(20, 400).WithMessage("Too long or short description.");
            RuleFor(t => t.Type).Length(2, 100).WithMessage("Too long or short type.");
            RuleFor(t => t.Likes).InclusiveBetween(int.MinValue, int.MaxValue).WithMessage("Too huge or small number.");
        }
    }
}
