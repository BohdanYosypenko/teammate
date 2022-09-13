using Teammate.Data.Context;
using Teammate.Data.Repositories.Interfaces;

namespace Teammate.Data.Repositories.Realization;

public class UnitOfWork : IUnitOfWork
{
  private readonly ApplicationDbContext _context;
  private ILookupCategoryRepository _lookupCategoryRepository;
  private ISportTypeRepository _sportTypeRepository;
  private ISportCategoryRepository _sportCategoryRepository;
  private ISportLookupRepository _sportLookupRepository;
  private ITeammateUserRepository _userRepository;

  public UnitOfWork(ApplicationDbContext context)
  {
    _context = context;
  }

  public ILookupCategoryRepository LookupCategory
  {
    get { return _lookupCategoryRepository ??= new LookupCategoryRepository(_context); }
  }

  public ISportCategoryRepository SportCategory
  {
    get { return _sportCategoryRepository ??= new SportCategoryRepository(_context); }
  }

  public ISportLookupRepository SportLookup
  {
    get { return _sportLookupRepository ??= new SportLookupRepository(_context); }
  }

  public ISportTypeRepository SportType
  {
    get { return _sportTypeRepository ??= new SportTypeRepository(_context); }
  }

  public ITeammateUserRepository TeammateUser
  {
    get { return _userRepository ??= new TeammateUserRepository(_context); }
  }

  public async Task SaveAsync()
  {
    await _context.SaveChangesAsync();
  }
}

