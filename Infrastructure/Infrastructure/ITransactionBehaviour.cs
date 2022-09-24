using MediatR;

namespace Infrastructure.Infrastructure
{
    public interface ITransactionBehaviour<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
    }
}