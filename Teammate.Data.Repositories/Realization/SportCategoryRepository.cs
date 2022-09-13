using Teammate.Data.Context;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class SportCategoryRepository : BaseRepository<SportCategoryEntity>, ISportCategoryRepository
{
  public SportCategoryRepository(ApplicationDbContext context) : base(context) { }
}

