namespace Exceptions
{
    public class EcosystemException : Exception
    {
        public EcosystemException() : base() { }

        public EcosystemException(string msg) : base(msg) { }

        public EcosystemException(string msg, Exception ex) : base(msg, ex) { }
    }
}