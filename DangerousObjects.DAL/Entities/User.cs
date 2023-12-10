using System.ComponentModel.DataAnnotations.Schema;
using DangerousObjectsCommon.Enums;
using DangerousObjectsDAL.Entities.Base;

namespace DangerousObjectsDAL.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    [ForeignKey(nameof(PositionId))] 
    public Position Position { get; set; }
    public int PositionId { get; set; }
}