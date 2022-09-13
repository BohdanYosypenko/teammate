namespace Teammate.Data.Entities;

public class LookupCategoryEntity : IBaseEntity
{
    public int Id { get; set; }

    public string DefaultName { get; set; }

    public string Name { get; set; }

    public List<SportLookupEntity> SportLookups { get; set; }
}
