namespace DangerousObjectsCommon.DTOs.DangerousObject;

public class DisplayDangerousObject
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int TypeId { get; set; }
    public int OwnerId { get; set; }
    public DateTime DateAdded { get; set; }
}