using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StaticData.Roles;
using Microsoft.AspNetCore.Authorization;

namespace _4Teammate.API.Controllers;

[Route("[controller]")]
[Authorize(Roles = UserRoles.Admin)]
[ApiController]
public class SportCategoryController : ControllerBase
{
  private readonly ISportCategoryService _sportCategoryService;
  public SportCategoryController(ISportCategoryService sportCategoryService)
  {
    _sportCategoryService = sportCategoryService;
  }

  [AllowAnonymous]
  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _sportCategoryService.GetAllAsync());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById([FromRoute] int id)
  {
    return Ok(await _sportCategoryService.GetFirstOrDefaultAsync(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SportCategory sportCategory)
  {
    return Ok(await _sportCategoryService.CreateAsync(sportCategory));
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] SportCategory sportCategory)
  {
    return Ok(await _sportCategoryService.UpdateAsync(sportCategory));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    await _sportCategoryService.DeleteAsync(id);
    return Ok();
  }
}
