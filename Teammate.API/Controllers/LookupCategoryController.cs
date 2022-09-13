using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StaticData.Roles;
using Microsoft.AspNetCore.Authorization;

namespace _4Teammate.API.Controllers;

[Route("[controller]")]
[Authorize(Roles = UserRoles.Admin)]
[ApiController]
public class LookupCategoryController : ControllerBase
{
    private readonly ILookupCategoryService _lookupCategoryService;
    public LookupCategoryController(ILookupCategoryService lookupCategoryService)
    {
        _lookupCategoryService = lookupCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _lookupCategoryService.GetAllAsync());
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return Ok(await _lookupCategoryService.GetFirstOrDefaultAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] LookupCategory lookupCategory)
    {
        return Ok(await _lookupCategoryService.CreateAsync(lookupCategory));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] LookupCategory lookupCategory)
    {
        return Ok(await _lookupCategoryService.UpdateAsync(lookupCategory));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _lookupCategoryService.DeleteAsync(id);
        return Ok();
    }
}
