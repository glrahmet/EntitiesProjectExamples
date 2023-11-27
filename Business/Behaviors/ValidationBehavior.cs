using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Behaviors
{
    public sealed class ValidationBehavior<TRequst, TResponse> : IPipelineBehavior<TRequst, TResponse> where TRequst : class, IRequest<TRequst>, IRequest
    {
        private readonly IEnumerable<IValidator<TRequst>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequst>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequst request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequst>(request);

            var errorDictionary = _validators.
                Select(s => s.Validate(context)).
                SelectMany(s => s.Errors).
                Where(s => s != null).
                GroupBy(s => s.PropertyName,
                        s => s.ErrorMessage, (propertyName, errorMessage) => new
                        {
                            Key = propertyName,
                            Values = errorMessage.Distinct().ToArray()
                        }).ToDictionary(s => s.Key, s => s.Values[0]);

            if (errorDictionary.Any())
            {
                var error = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(error);
            }
            return await next();
        } 
    }
}
