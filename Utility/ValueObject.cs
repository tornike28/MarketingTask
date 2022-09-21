namespace Utility
{
    public class ValueObject
    {
        public void ThrowDomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
