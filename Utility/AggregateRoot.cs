using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public abstract class AggregateRoot : Entity
    {
        public DateTimeOffset LastChangeDate { get; protected set; }

        public DateTimeOffset CreateDate { get; protected set; } = DateTimeOffset.Now;

        public DateTimeOffset DeleteAt { get; protected set; }

        public bool IsDeleted { get; protected set; }


        private List<INotification> _domainEvents;

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void Raise(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void LastUpdateDate()
        {
            LastChangeDate = DateTimeOffset.Now;
        }

        public void ChangeStatusAsDeleted()
        {
            IsDeleted = true;
            DeleteAt = DateTimeOffset.Now;
        }

    }
}
