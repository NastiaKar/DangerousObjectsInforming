using System.ComponentModel;

namespace DangerousObjects.MVC.Models;

public class MessageModel
{
    [DisplayName("Id")]
    public int? Id { get; set; }
    [DisplayName("Title")]
    public string Title { get; set; } = string.Empty;
    
    [DisplayName("Content")]
    public string Content { get; set; } = string.Empty;
    
    [DisplayName("Importance")]
    public string Importance { get; set; } = string.Empty;
    
    [DisplayName("Dangerous object")]
    public int DangerousObjectId { get; set; }
    
    public string Token { get; set; } = string.Empty;
    
    public int OwnerId { get; set; }
}