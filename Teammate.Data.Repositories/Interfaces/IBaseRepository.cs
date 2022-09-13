using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Teammate.Data.Repositories.Interfaces;

public interface IBaseRepository<Entity>
{
  public Task<List<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter = null,
          Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>> include = null,
          Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
          int? pageNumber = null, int? pageSize = null,
          bool asNoTracking = false);
  public Task<Entity> GetFirstOrDefaultAsync(Expression<Func<Entity, bool>> filter = null,
          Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>> include = null,
          bool asNoTracking = false);
  public Task<Entity> CreateAsync(Entity entity);
  public Entity Update(Entity entity);
  public void Delete(Entity entity);
}

