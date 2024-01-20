using DangerousObjectsCommon.Exceptions.Base;

namespace DangerousObjectsCommon.Exceptions;

public class UserAlreadyVerifiedException : BaseCustomException
{
    public UserAlreadyVerifiedException(string cause, string message, Exception? innerException = null) : base(cause,
        message, innerException) { }
}