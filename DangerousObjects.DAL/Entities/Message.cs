using System.ComponentModel.DataAnnotations.Schema;
using DangerousObjectsCommon.Enums;
using DangerousObjectsDAL.Entities.Base;

namespace DangerousObjectsDAL.Entities;

public class Message : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime DateSent { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public int ImportanceId { get; set; }
    public int DangerousObjectId { get; set; }
    [ForeignKey(nameof(SenderId))]
    public User Sender { get; set; } = null!;
    [ForeignKey(nameof(ReceiverId))]
    public User Receiver { get; set; } = null!;
    [ForeignKey(nameof(ImportanceId))]
    public Importance Importance { get; set; }
    [ForeignKey(nameof(DangerousObjectId))]
    public DangerousObject DangerousObject { get; set; } = null!;
}