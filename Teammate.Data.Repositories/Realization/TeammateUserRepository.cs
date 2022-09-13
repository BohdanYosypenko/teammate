using Teammate.Data.Context;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class TeammateUserRepository : BaseRepository<TeammateUserEntity>, ITeammateUserRepository
{
  public TeammateUserRepository(ApplicationDbContext context) : base(context) { }
}
