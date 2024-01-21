using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DangerousObjects.MVC.Models;

public class UserLoginModel
{
    [DisplayName("Email")]
    [Required(ErrorMessage = "Email is required")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [StringLength(50)]
    public string Email { get; set; }

    [DisplayName("Password")]
    [Required(ErrorMessage = "Password is required")]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [StringLength(50)]
    public string Password { get; set; }
}