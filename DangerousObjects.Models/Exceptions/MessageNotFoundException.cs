using DangerousObjectsCommon.Exceptions.Base;

namespace DangerousObjectsCommon.Exceptions;

public class MessageNotFoundException : BaseCustomException
{
    public MessageNotFoundException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}