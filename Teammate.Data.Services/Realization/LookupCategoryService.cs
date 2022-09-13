using System.Linq.Expressions;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;
using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace Teammate.Data.Services.Realization;

public class LookupCategoryService : ILookupCategoryService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public LookupCategoryService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<LookupCategory>> GetAllAsync()
  {
    return _mapper.Map<List<LookupCategory>>(await _unitOfWork.LookupCategory.GetAllAsync());
  }

  public async Task<LookupCategory> GetFirstOrDefaultAsync(int id)
  {
    return _mapper.Map<LookupCategory>(await _unitOfWork.LookupCategory.GetFirstOrDefaultAsync(c => c.Id == id));
  }

  public async Task<LookupCategory> CreateAsync(LookupCategory entity)
  {
    var result = await _unitOfWork.LookupCategory.CreateAsync(_mapper.Map<LookupCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<LookupCategory>(result);
  }

  public async Task<LookupCategory> UpdateAsync(LookupCategory entity)
  {
    var result = _unitOfWork.LookupCategory.Update(_mapper.Map<LookupCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<LookupCategory>(result);
  }

  public async Task DeleteAsync(int id)
  {
    var entity = _unitOfWork.SportType.GetFirstOrDefaultAsync(filter: c => c.Id == id);
    _unitOfWork.LookupCategory.Delete(_mapper.Map<LookupCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
  }
}
