using Teammate.Domain.Filters;
using Teammate.Domain.Models;

namespace Teammate.Domain.Services.Interfaces;

public interface ISportTypeService 
{
  public Task<List<SportType>> GetAllAsync(SportTypeFilter request);
  public Task<SportType> GetFirstOrDefaultAsync(int id);
  public Task<SportType> CreateAsync(SportType entity);
  public Task<SportType> UpdateAsync(SportType entity);
  public Task DeleteAsync(int id);
}
