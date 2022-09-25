namespace Utility
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public string SecondaryId { get; protected set; } = Guid.NewGuid().ToString();

        public void ThrowDomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
