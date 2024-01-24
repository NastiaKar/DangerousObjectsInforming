using System.ComponentModel;

namespace DangerousObjects.MVC.Models;

public class UserRegisterModel
{
    [DisplayName("Name")]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = string.Empty;
    [DisplayName("Role")]
    public string Role { get; set; } = string.Empty;
    
    public string ErrorMessage { get; set; } = string.Empty;
}