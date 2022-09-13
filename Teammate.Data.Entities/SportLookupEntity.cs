namespace Teammate.Data.Entities;

public class SportLookupEntity : IBaseEntity
{
  public int Id { get; set; }

  public int SportTypeFID { get; set; }

  public int LookupCategoryFID { get; set; }

  public int UserFID { get; set; }

  public DateTime TimeStart { get; set; }

  public DateTime TimeEnd { get; set; }

  public double Latitude { get; set; }

  public double Longitude { get; set; }

  public double PriceStart { get; set; }

  public double PriceEnd { get; set; }

  public int AgeStart { get; set; }

  public int AgeEnd { get; set; }

  public char Gender { get; set; }


  public TeammateUserEntity User { get; set; }
  public SportTypeEntity SportType { get; set; }
  public LookupCategoryEntity LookupCategory { get; set; }
}

