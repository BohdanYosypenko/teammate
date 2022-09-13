namespace Teammate.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
  public ILookupCategoryRepository LookupCategory { get; }
  public ISportCategoryRepository SportCategory { get; }
  public ISportLookupRepository SportLookup { get; }
  public ISportTypeRepository SportType { get; }
  public ITeammateUserRepository TeammateUser { get; }
  public Task SaveAsync();
}
