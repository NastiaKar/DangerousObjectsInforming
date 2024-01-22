using System.ComponentModel;

namespace DangerousObjects.MVC.Models;

public class DangerousObjectModel
{
    [DisplayName("Id")]
    public int? Id { get; set; }
    
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    
    public string Token { get; set; } = string.Empty;
    
    public int OwnerId { get; set; }
}