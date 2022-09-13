using Microsoft.AspNetCore.Identity;

namespace Teammate.Data.Entities;

public class AccountUser : IdentityUser
{
  public string? RefreshToken { get; set; }
  public DateTime? RefreshTokenExpiryTime { get; set; }
  public TeammateUserEntity User { get; set; }
}
