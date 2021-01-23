using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;

namespace WEBApi.Validators
{
    public class TrainingDoneValidator : AbstractValidator<TrainingDoneCreateDto>
    {
        public TrainingDoneValidator()
        {
            RuleFor(e => e.TimeDone).InclusiveBetween(0, 9000).WithMessage("Too long, if user cheated, please, consider lower the time to zero.");
        }
    }
}
