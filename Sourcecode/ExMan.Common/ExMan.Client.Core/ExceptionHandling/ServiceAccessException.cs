namespace ExMan.Client.Core.ExceptionHandling
{
    public class ServiceAccessException : BaseException
    {
        public override void SetExceptionType()
        {
            ExceptionType = ExceptionType.ServiceAccessException;
        }
    }
}
