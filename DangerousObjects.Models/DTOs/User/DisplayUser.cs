using DangerousObjectsCommon.Enums;

namespace DangerousObjectsCommon.DTOs.User;

public class DisplayUser
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Position { get; set; } = null!;
    public bool IsVerified { get; set; } = false;
}