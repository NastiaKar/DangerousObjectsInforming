using DangerousObjectsCommon.Enums;

namespace DangerousObjectsCommon.DTOs.DangerousObject;

public class DisplayDangerousObject
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string ObjType { get; set; }
    public int OwnerId { get; set; }
    public DateTime DateAdded { get; set; }
}