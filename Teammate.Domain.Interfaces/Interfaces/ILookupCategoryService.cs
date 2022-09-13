using Teammate.Domain.Models;

namespace Teammate.Domain.Services.Interfaces;

public interface ILookupCategoryService 
{
  public Task<List<LookupCategory>> GetAllAsync();
  public Task<LookupCategory> GetFirstOrDefaultAsync(int id);
  public Task<LookupCategory> CreateAsync(LookupCategory entity);
  public Task<LookupCategory> UpdateAsync(LookupCategory entity);
  public Task DeleteAsync(int id);
}
