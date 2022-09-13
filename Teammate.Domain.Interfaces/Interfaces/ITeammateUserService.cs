using Teammate.Domain.Models;

namespace Teammate.Domain.Interfaces
{
  public interface ITeammateUserService
  {
    Task<TeammateUser> GetFirstOrDefaultAsync(int id);
    Task<TeammateUser> UpdateAsync(TeammateUser entity);
    Task DeleteAsync(int id);
  }
}
