using Microsoft.AspNetCore.Identity;

namespace Teammate.Domain.Models.Account;

public class RegisterModel
{
  public string Username { get; set; }

  public string Email { get; set; }

  public string Password { get; set; }
}
