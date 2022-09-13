using Teammate.Data.Context;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class SportTypeRepository : BaseRepository<SportTypeEntity>, ISportTypeRepository
{
  public SportTypeRepository(ApplicationDbContext context) : base(context) { }
}
