namespace DangerousObjectsCommon.Errors;

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = new();
}