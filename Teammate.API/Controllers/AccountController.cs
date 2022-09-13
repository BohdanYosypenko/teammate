using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaticData.Roles;
using Teammate.Domain.Models.Account;
using Teammate.Domain.Services.Interfaces;

namespace Teammate.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
  private readonly IAccountService _accountService;

  public AccountController(IAccountService accountService)
  {
    _accountService = accountService;
  }

  [AllowAnonymous]
  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginModel loginModel)
  {
    var result = await _accountService.LoginAsync(loginModel);
    return result.Succeed ? Ok(result.TokenModel) : BadRequest(result.Message);
  }

  [AllowAnonymous]
  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterModel registerModel)
  {
    var result = await _accountService.RegisterAsync(registerModel);
    return result.Succeed ?  Ok(result.TokenModel) : BadRequest(result.Message);
  }

  [Authorize(Roles = UserRoles.Admin)]
  [HttpPost("register/admin")]
  public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel)
  {
    var result = await _accountService.RegisterAdminAsync(registerModel);
    return result.Succeed ? Ok(result.TokenModel) : BadRequest(result.Message);
  }

  [Authorize]
  [HttpPost("revoke/{username}")]
  public async Task<IActionResult> GetCurrentUser([FromHeader] string username)
  {
    await _accountService.LogoutAsync(username);
    return Ok();
  }

  [AllowAnonymous]
  [HttpPost("refresh-token")]
  public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel)
  {
    var result = await _accountService.RefreshTokenAsync(tokenModel);
    return result.Succeed ?  Ok(result) :  BadRequest(result.Message);
  }
}
