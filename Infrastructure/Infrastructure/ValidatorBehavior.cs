using FluentValidation;
using MediatR;
using Utility;

namespace Infrastructure.Infrastructure
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : CommandExecutionResult, new()
    {
        private readonly IValidator<TRequest>[] _validators;
        public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                TResponse responses = new TResponse();

                responses.ErrorMessage = failures.First().ErrorMessage;

                return responses;
            }

            var response = await next();
            return response;
        }
    }
}
