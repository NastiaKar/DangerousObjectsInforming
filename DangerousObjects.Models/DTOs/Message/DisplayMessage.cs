namespace DangerousObjectsCommon.DTOs.Message;

public class DisplayMessage
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int ImportanceId { get; set; }
    public int DangerousObjectId { get; set; }
    public int SenderId { get; set; }
    public DateTime DateSent { get; set; }
}