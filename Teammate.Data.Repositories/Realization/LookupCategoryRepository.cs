using Teammate.Data.Context;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class LookupCategoryRepository : BaseRepository<LookupCategoryEntity>, ILookupCategoryRepository
{
  public LookupCategoryRepository(ApplicationDbContext context) : base(context) { }
}

