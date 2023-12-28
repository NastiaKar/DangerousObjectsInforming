using DangerousObjectsCommon.DTOs.DangerousObject;

namespace DangerousObjectsCommon.DTOs.Message;

public class DisplayMessage
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Importance { get; set; } = null!;
    public int DangerousObjectId { get; set; }
    public DisplayDangerousObject DangerousObject { get; set; } = null!;
    public int SenderId { get; set; }
    public DateTime DateSent { get; set; }
}