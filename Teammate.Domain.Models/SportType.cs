using Teammate.Domain.Filters;

namespace Teammate.Domain.Models;

public class SportType 
{

  public SportType()
  {

  }

  public SportType(SportTypeFilter sportTypeFilter)
  {
    Id = sportTypeFilter.Id;
    CategoryFID = sportTypeFilter.CategoryId;
  }

  public int? Id { get; set; }

  public int? CategoryFID { get; set; }

  public string DefaultName { get; set; }

  public string Name { get; set; }
}
