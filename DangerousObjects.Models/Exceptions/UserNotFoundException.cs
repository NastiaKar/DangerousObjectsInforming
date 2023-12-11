using DangerousObjectsCommon.Exceptions.Base;

namespace DangerousObjectsCommon.Exceptions;

public class UserNotFoundException : BaseCustomException
{
    public UserNotFoundException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}