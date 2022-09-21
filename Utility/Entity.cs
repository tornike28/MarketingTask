namespace Utility
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public void ThrowDomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
