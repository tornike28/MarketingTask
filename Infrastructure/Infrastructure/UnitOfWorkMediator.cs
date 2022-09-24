using Infrastructure.Db;

namespace Infrastructure.Infrastructure
{
    public class UnitOfWorkMediator : IUnitOfWorkMediator
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWorkMediator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.BeginTransactionAsync(cancellationToken);
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.CommitTransactionAsync(cancellationToken);
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.RollbackTransactionAsync(cancellationToken);
        }
    }
}
