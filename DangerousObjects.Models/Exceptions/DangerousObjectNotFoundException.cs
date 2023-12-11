using DangerousObjectsCommon.Exceptions.Base;

namespace DangerousObjectsCommon.Exceptions;

public class DangerousObjectNotFoundException : BaseCustomException
{
    public DangerousObjectNotFoundException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}