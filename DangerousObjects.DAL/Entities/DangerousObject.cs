using System.ComponentModel.DataAnnotations.Schema;
using DangerousObjectsCommon.Enums;
using DangerousObjectsDAL.Entities.Base;

namespace DangerousObjectsDAL.Entities;

public class DangerousObject : BaseEntity
{
    public DateTime DateAdded { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Location { get; set; } = null!;
    [ForeignKey(nameof(OwnerId))]
    public User Owner { get; set; } = null!;
    public int OwnerId { get; set; }
    [ForeignKey(nameof(TypeId))]
    public ObjType Type { get; set; }
    public int TypeId { get; set; }
}