using Teammate.Domain.Filters;
using Teammate.Domain.Models;

namespace Teammate.Domain.Services.Interfaces;

public interface ISportLookupService 
{
  public Task<List<SportLookup>> GetAllAsync(SportLookupFilter request);
  public Task<SportLookup> GetFirstOrDefaultAsync(int id);
  public Task<SportLookup> CreateAsync(SportLookup entity);
  public Task<SportLookup> UpdateAsync(SportLookup entity);
  public Task DeleteAsync(int id);
}
