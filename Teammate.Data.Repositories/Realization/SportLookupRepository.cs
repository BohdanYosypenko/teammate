using Teammate.Data.Context;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class SportLookupRepository : BaseRepository<SportLookupEntity>, ISportLookupRepository
{
  public SportLookupRepository(ApplicationDbContext context) : base(context) { }
}

