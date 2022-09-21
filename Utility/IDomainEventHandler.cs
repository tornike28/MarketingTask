using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface IDomainEventHandler<T> : INotificationHandler<T>
          where T : INotification
    {
        new Task Handle(T @event, CancellationToken cancellationToken);
    }
}
