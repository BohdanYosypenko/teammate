using System.Linq.Expressions;
using Teammate.Data.Entities;
using Teammate.Domain.Filters.Helpers;
using Teammate.Domain.Filters.Interfaces;

namespace Teammate.Domain.Filters;

public class SportLookupFilter : IBaseFilter<SportLookupEntity>
{
  public int? Id { get; set; }
  public Expression<Func<SportLookupEntity, bool>> GetAllFilters()
  {
    var filterList = new List<Expression<Func<SportLookupEntity, bool>>>();

    if (Id.HasValue)
      filterList.Add(a => a.Id == Id);

    Expression<Func<SportLookupEntity, bool>> expression = SportType => true;

    foreach (var exp in filterList)
    {
      expression = expression.AndAlso(exp);
    }

    return expression;

  }
}
