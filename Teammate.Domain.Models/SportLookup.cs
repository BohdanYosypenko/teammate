namespace Teammate.Domain.Models;

public class SportLookup
{
  public int Id { get; set; }

  public int SportTypeFID { get; set; }

  public int LookupCategoryFID { get; set; }

  public int UserFID { get; set; }

  public DateTime TimeStart { get; set; }

  public DateTime TimeEnd { get; set; }

  public decimal Latitude { get; set; }

  public decimal Longitude { get; set; }

  public decimal PriceStart { get; set; }

  public decimal PriceEnd { get; set; }

  public int AgeStart { get; set; }

  public int AgeEnd { get; set; }

  public char Gender { get; set; }
}
