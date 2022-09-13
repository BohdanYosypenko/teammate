using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Teammate.Domain.Filters;
using StaticData.Roles;
using Microsoft.AspNetCore.Authorization;

namespace _4Teammate.API.Controllers;

[Route("[controller]")]
[Authorize(Roles = UserRoles.Admin)]
[ApiController]
public class SportLookupController : ControllerBase
{
  private readonly ISportLookupService _sportLookupService;
  public SportLookupController(ISportLookupService sportLookupService)
  {
    _sportLookupService = sportLookupService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] SportLookupFilter sportLookup)
  {
    return Ok(await _sportLookupService.GetAllAsync(sportLookup));
  }

  [AllowAnonymous]
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    return Ok(await _sportLookupService.GetFirstOrDefaultAsync(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SportLookup sportLookup)
  {
    return Ok(await _sportLookupService.CreateAsync(sportLookup));
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] SportLookup sportLookup)
  {
    return Ok(await _sportLookupService.UpdateAsync(sportLookup));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    await _sportLookupService.DeleteAsync(id);
    return Ok();
  }
}
