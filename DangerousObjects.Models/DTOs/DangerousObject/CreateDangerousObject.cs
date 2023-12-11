namespace DangerousObjectsCommon.DTOs.DangerousObject;

public class CreateDangerousObject
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string ObjType { get; set; }
}