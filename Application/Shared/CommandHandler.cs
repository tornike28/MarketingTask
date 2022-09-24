using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Utility;

namespace Application.Shared
{
    public abstract class CommandHandler<TResult> : IRequestHandler<TResult, CommandExecutionResult> where TResult : IRequest<CommandExecutionResult>
    {
        private readonly IServiceProvider _serviceProvider;
        protected CommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var contextAccessor = GetService<IHttpContextAccessor>();


        }
        public abstract Task<CommandExecutionResult> Handle(TResult request, CancellationToken cancellationToken);

        //public async Task Save<TAggregate>(TAggregate aggregate, IRepository<TAggregate> repository) where TAggregate : AggregateRoot
        //{
        //    await repository.Save(aggregate);
        //    await UnitOfWork.SaveChangesAsync();
        //}

        protected Task<CommandExecutionResult> Fail(params string[] errorMessages)
        {
            var result = new CommandExecutionResult
            {
                Success = false
            };

            //if (errorMessages.IsNotNull())
            //{
            //    result.Errors = errorMessages.Select(x => new Error
            //    {
            //        Code = 0,
            //        Message = x
            //    });
            //}

            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> Fail(Error error)
        {
            var result = new CommandExecutionResult
            {
                Success = false
            };

            //if (error.IsNotNull())
            //{
            //    result.Errors = new List<Error> { error };
            //}

            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> Fail(ErrorCode errorCode, string errorMessage = null)
        {
            var result = new CommandExecutionResult
            {
                Success = false
            };

            result.Errors = new List<Error>
            {
                new Error
                {
                    Code = (int)errorCode,
                    Message = errorMessage ?? string.Empty
                }
            };

            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> Ok()
        {
            var result = new CommandExecutionResult
            {
                Success = true
            };

            return Task.FromResult(result);
        }

        protected T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
