namespace DangerousObjectsCommon.DTOs.Message;

public class UpdateMessage
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Importance { get; set; } = null!;
    public int DangerousObjectId { get; set; }
}