using System.Linq.Expressions;
using Teammate.Data.Entities;

namespace Teammate.Domain.Filters.Interfaces;

public interface IBaseFilter<T> where T : IBaseEntity
{
  public Expression<Func<T, bool>> GetAllFilters();
}