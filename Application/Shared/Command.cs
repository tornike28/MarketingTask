using Domain.Aggregates.DistributorAggregate.IRepository;
using Domain.Aggregates.TransactionAggregate.IRepository;
using Infrastructure.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility;

namespace Application.Shared
{
    public abstract class Command
    {
        protected IServiceProvider? ServiceProvider;
        protected IConfiguration? Configuration;
        protected ApplicationDbContext ApplicationDbContext;
        protected IDistributorRepository DistributorRepository;
        protected ITransactionRepository TransactionReposiotry;

        protected string? UserId;
        protected string? Username;
        protected string? IPAddress;

        public void Resolve(ApplicationDbContext applicationContext,
                          IServiceProvider serviceProvider,
                          IConfiguration configuration
                          )
        {
            ServiceProvider = serviceProvider;
            Configuration = configuration;
            ApplicationDbContext = applicationContext;

            DistributorRepository = serviceProvider.GetService<IDistributorRepository>();
            TransactionReposiotry = serviceProvider.GetService<ITransactionRepository>();
        }


        public abstract Task<CommandExecutionResult> ExecuteAsync();

        protected Task<CommandExecutionResult> Fail(string? errorMessage)
        {
            var result = new CommandExecutionResult
            {
                Success = false
            };

            result.Errors = new List<Error>
            {
                new Error
                {
                    Message = errorMessage ?? string.Empty
                }
            };

            return Task.FromResult(result);
        }


        protected Task<CommandExecutionResult> Fail(ErrorCode errorCode)
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
                }
            };

            return Task.FromResult(result);
        }

        protected Task<CommandExecutionResult> Ok(string resultId, long? listCount = null)
        {
            var result = new CommandExecutionResult
            {
                ResultId = resultId,
                Success = true,
                ListCount = listCount,
                Code = 200,
                Errors = new List<Error>()
            };

            return Task.FromResult(result);
        }

        protected async Task<CommandExecutionResult> Ok()
        {
            var result = new CommandExecutionResult
            {
                Success = true,
                Code = 200,
                Errors = new List<Error>()
            };

            return result;
        }
    }
}
