using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teammate.Domain.Interfaces;
using Teammate.Domain.Models;

namespace Teammate.API.Controllers
{
  [Authorize]
  [Route("[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ITeammateUserService _teammateUserService;
    public UserController(ITeammateUserService teammateUserService)
    {
      _teammateUserService = teammateUserService;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      return Ok(await _teammateUserService.GetFirstOrDefaultAsync(id));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TeammateUser lookupCategory)
    {
      return Ok(await _teammateUserService.UpdateAsync(lookupCategory));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      await _teammateUserService.DeleteAsync(id);
      return Ok();
    }
  }
}
