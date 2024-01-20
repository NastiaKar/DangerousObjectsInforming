using DangerousObjectsCommon.Exceptions.Base;

namespace DangerousObjectsCommon.Exceptions;

public class UserNotVerifiedException : BaseCustomException
{
    public UserNotVerifiedException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}