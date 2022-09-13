using Teammate.Domain.Models;

namespace Teammate.Domain.Services.Interfaces;

public interface ISportCategoryService
{
  public Task<List<SportCategory>> GetAllAsync();
  public Task<SportCategory> GetFirstOrDefaultAsync(int id);
  public Task<SportCategory> CreateAsync(SportCategory entity);
  public Task<SportCategory> UpdateAsync(SportCategory entity);
  public Task DeleteAsync(int id);
}
