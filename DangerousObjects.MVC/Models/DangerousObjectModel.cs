using System.ComponentModel;

namespace DangerousObjects.MVC.Models;

public class DangerousObjectModel
{
    [DisplayName("Id")]
    public int? Id { get; set; }
    
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;
    [DisplayName("Location")]
    public string Location { get; set; } = string.Empty;
    [DisplayName("Type")]
    public string ObjType { get; set; } = string.Empty;
    
    public string Token { get; set; } = string.Empty;
    
    public int OwnerId { get; set; }
}