using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaticData.Roles;
using Teammate.Domain.Filters;
using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;

namespace Teammate.API.Controllers;


[Route("[controller]")]
[Authorize(Roles = UserRoles.Admin)]
[ApiController]
public class SportTypeController : ControllerBase
{
  private readonly ISportTypeService _sportTypeService;

  public SportTypeController(ISportTypeService sportTypeService)
  {
    _sportTypeService = sportTypeService;
  }

  [AllowAnonymous]
  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] SportTypeFilter sportTypeFilter)
  {
    return Ok(await _sportTypeService.GetAllAsync(sportTypeFilter));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    return Ok(await _sportTypeService.GetFirstOrDefaultAsync(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SportType sportType)
  {
    return Ok(await _sportTypeService.CreateAsync(sportType));
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] SportType sportType)
  {
    return Ok(await _sportTypeService.UpdateAsync(sportType));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    await _sportTypeService.DeleteAsync(id);
    return Ok();
  }
}
