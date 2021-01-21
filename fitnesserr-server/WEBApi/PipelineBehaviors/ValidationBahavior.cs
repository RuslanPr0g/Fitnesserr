using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WEBApi.PipelineBehaviors
{
    public class ValidationBahavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBahavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TRequest> Handle(TRequest request)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(async(x)=>await x.ValidateAsync(context))
                .SelectMany(x => x.Result.Errors)
                .Where(x => x is not null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return request;
        }
    }
}
