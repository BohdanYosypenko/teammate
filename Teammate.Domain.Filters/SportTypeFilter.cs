using System.Linq.Expressions;
using Teammate.Data.Entities;
using Teammate.Domain.Filters.Helpers;
using Teammate.Domain.Filters.Interfaces;

namespace Teammate.Domain.Filters;

public class SportTypeFilter : IBaseFilter<SportTypeEntity>
{

  public int? Id { get; set; }
  public int? CategoryId { get; set; }


  public Expression<Func<SportTypeEntity, bool>> GetAllFilters()
  {
    var filterList = new List<Expression<Func<SportTypeEntity, bool>>>();

    if (Id.HasValue)
      filterList.Add(a => a.Id == Id);

    if (CategoryId.HasValue)
      filterList.Add(a => a.CategoryFID == CategoryId);

    Expression<Func<SportTypeEntity, bool>> expression = SportType => true;

    foreach (var exp in filterList)
    {
      expression = expression.AndAlso(exp);
    }

    return expression;

  }
}