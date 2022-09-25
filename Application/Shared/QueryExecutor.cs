using FluentValidation.Results;
using Infrastructure.Db;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Utility;

namespace Application.Shared
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ApplicationDbContext _appContext;
        private readonly IServiceProvider _serviceProvider;


        public QueryExecutor(IServiceProvider serviceProvider,
            ApplicationDbContext appContext)
        {
            _serviceProvider = serviceProvider;
            _appContext = appContext;
        }

        public async Task<QueryExecutionResult<TResult>> Execute<TQuery, TResult>(TQuery query)
            where TQuery : Query<TResult>
            where TResult : class
        {
            try
            {
                query.Resolve(
                   _appContext,
                   _serviceProvider);

                return await query.Execute();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new QueryExecutionResult<TResult>
                {
                    Success = false,
                    Errors = new List<Error>
                    {
                        new Error
                        {
                            Code = 0,
                            Message = ex.ToString() 
                        }
                    }
                });
            }
        }
    }
}
