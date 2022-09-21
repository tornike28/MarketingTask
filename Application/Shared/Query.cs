using Infrastructure.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility;

namespace Application.Shared
{
    public abstract class Query<TQueryResult> where TQueryResult : class
    {
        protected IConfiguration Configuration;

        protected ApplicationDbContext _appContext;

        protected IServiceProvider ServiceProvider;
        protected ApplicationDbContext ApplicationContext
        {
            get { return _appContext; }
        }
        public abstract Task<QueryExecutionResult<TQueryResult>> Execute();

        public void Resolve(
            ApplicationDbContext appContext,
            IServiceProvider serviceProvider)
        {

            _appContext = appContext;
            ServiceProvider = serviceProvider;

            Configuration = ServiceProvider.GetService<IConfiguration>();
        }

        protected Task<QueryExecutionResult<TQueryResult>> Fail(params string[] errorMessages)
        {
            var result = new QueryExecutionResult<TQueryResult>
            {
                Success = false
            };

            if (errorMessages != null)
            {
                result.Errors = errorMessages.Select(x => new Error
                {
                    Code = 0,
                    Message = x
                });
            }

            return Task.FromResult(result);
        }

        protected Task<QueryExecutionResult<TQueryResult>> Fail(ErrorCode errorCode, string errorMessage = null)
        {
            var result = new QueryExecutionResult<TQueryResult>
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

        protected Task<QueryExecutionResult<TQueryResult>> Ok(TQueryResult data)
        {
            var result = new QueryExecutionResult<TQueryResult>
            {
                Data = data,
                Success = true,
                Errors = new List<Error>()
            };

            return Task.FromResult(result);
        }
    }
}
