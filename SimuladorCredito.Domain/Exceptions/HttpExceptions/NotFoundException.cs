namespace SimuladorCredito.Domain.Exceptions.HttpExceptions
{
  public class NotFoundException : HttpExceptionBase
  {
    public NotFoundException(string menssage) : base(menssage)
    {
    }
  }
}