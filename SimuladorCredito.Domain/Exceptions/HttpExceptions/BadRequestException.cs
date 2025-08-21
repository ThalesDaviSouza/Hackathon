namespace SimuladorCredito.Domain.Exceptions.HttpExceptions
{
  public class BadRequestException : HttpExceptionBase
  {
    public BadRequestException(string menssage) : base(menssage)
    {
    }
  }
}