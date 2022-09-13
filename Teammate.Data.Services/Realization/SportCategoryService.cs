using System.Linq.Expressions;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;
using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace Teammate.Data.Services.Realization;

public class SportCategoryService : ISportCategoryService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportCategoryService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportCategory>> GetAllAsync()
  {
    return _mapper.Map<List<SportCategory>>(await _unitOfWork.SportCategory.GetAllAsync());
  }

  public async Task<SportCategory> GetFirstOrDefaultAsync(int id)
  {    
    return _mapper.Map<SportCategory>(await _unitOfWork.SportCategory.GetFirstOrDefaultAsync(c => c.Id == id));
  }

  public async Task<SportCategory> CreateAsync(SportCategory entity)
  {
    var result = await _unitOfWork.SportCategory.CreateAsync(_mapper.Map<SportCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportCategory>(result);
  }

  public async Task<SportCategory> UpdateAsync(SportCategory entity)
  {
    var result = _unitOfWork.SportCategory.Update(_mapper.Map<SportCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportCategory>(result);
  }

  public async Task DeleteAsync(int id)
  {
    var entity = _unitOfWork.SportCategory.GetFirstOrDefaultAsync(filter: c => c.Id == id);
    _unitOfWork.LookupCategory.Delete(_mapper.Map<LookupCategoryEntity>(entity));
    await _unitOfWork.SaveAsync();
  }
}
