using System.ComponentModel;

namespace DangerousObjects.MVC.Models;

public class FullUserModel
{
    public int Id { get; set; }
    [DisplayName("Name")]
    public string Name { get; set; } = null!;
    [DisplayName("Email")]
    public string Email { get; set; } = null!;
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = null!;
    [DisplayName("Role")]
    public string Role { get; set; } = null!;
    [DisplayName("Is Verified")]
    public bool IsVerified { get; set; } = false;
    [DisplayName("Is Admin")]
    public bool IsAdmin { get; set; } = false;
    
    public string Token { get; set; } = null!;
}