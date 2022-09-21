using Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TContext, TAggregateRoot>
      where TAggregateRoot : AggregateRoot
      where TContext : DbContext
    {
        protected ApplicationDbContext _ApplicationDbContext;
        protected IMediator _mediator;

        public BaseRepository(ApplicationDbContext context, IMediator mediator)
        {
            _ApplicationDbContext = context;
            _mediator = mediator;
        }



        public async Task Save(TAggregateRoot aggregateRoot)
        {
            if (aggregateRoot.Id <= 0)
            {
                _ApplicationDbContext.Set<TAggregateRoot>().Add(aggregateRoot);
            }
            else
            {
                _ApplicationDbContext.Entry(aggregateRoot).State = EntityState.Modified;
            }

            //TODO Remove

            await _mediator.DispatchDomainEventsAsync(_ApplicationDbContext);

            await _ApplicationDbContext.SaveChangesAsync();
        }
    }
}
