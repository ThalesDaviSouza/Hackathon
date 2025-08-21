namespace SimuladorCredito.Domain.Exceptions.HttpExceptions
{
    public abstract class HttpExceptionBase : Exception
    {
        public HttpExceptionBase(string menssage) : base(menssage) { }
    }
}