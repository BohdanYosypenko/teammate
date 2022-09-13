using AutoMapper;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;
using Teammate.Domain.Filters;
using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;

namespace Teammate.Data.Services.Realization;

public class SportLookupService : ISportLookupService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportLookupService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportLookup>> GetAllAsync(SportLookupFilter request)
  {
    return _mapper.Map<List<SportLookup>>(await _unitOfWork.SportLookup.GetAllAsync(request.GetAllFilters()));
  }

  public async Task<SportLookup> GetFirstOrDefaultAsync(int id)
  {
    return _mapper.Map<SportLookup>(await _unitOfWork.SportLookup.GetFirstOrDefaultAsync(a => a.Id == id));
  }

  public async Task<SportLookup> CreateAsync(SportLookup entity)
  {
    await ValidateRequest(entity);
    var result = await _unitOfWork.SportLookup.CreateAsync(_mapper.Map<SportLookupEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportLookup>(result);
  }

  public async Task<SportLookup> UpdateAsync(SportLookup entity)
  {
    await ValidateRequest(entity);
    var result = _unitOfWork.SportLookup.Update(_mapper.Map<SportLookupEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportLookup>(result);
  }

  public async Task DeleteAsync(int id)
  {
    var entity = _unitOfWork.SportLookup.GetFirstOrDefaultAsync(filter: c => c.Id == id);
    _unitOfWork.SportLookup.Delete(_mapper.Map<SportLookupEntity>(entity));
    await _unitOfWork.SaveAsync();
  }


  private async Task ValidateRequest(SportLookup entity)
  {
    if (await _unitOfWork.SportLookup.GetFirstOrDefaultAsync(a => a.Id == entity.LookupCategoryFID) == null)
    {
      throw new ArgumentException("Category Not Found");
    }

    if (await _unitOfWork.SportType.GetFirstOrDefaultAsync(a => a.Id == entity.SportTypeFID) == null)
    {
      throw new ArgumentException("Sport Type Not Found");
    }

    if (await _unitOfWork.TeammateUser.GetFirstOrDefaultAsync(a => a.Id == entity.UserFID) == null)
    {
      throw new ArgumentException("User Not Found");
    }
  }

}
