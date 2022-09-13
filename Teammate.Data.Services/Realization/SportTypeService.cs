using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;
using Teammate.Domain.Models;
using Teammate.Domain.Services.Interfaces;
using AutoMapper;
using Teammate.Domain.Filters;

namespace Teammate.Data.Services.Realization;

public class SportTypeService : ISportTypeService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportTypeService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportType>> GetAllAsync(SportTypeFilter request)
  {    
    return _mapper.Map<List<SportType>>(await _unitOfWork.SportType.GetAllAsync(request.GetAllFilters()));
  }

  public async Task<SportType> GetFirstOrDefaultAsync(int id)
  {    
    return _mapper.Map<SportType>(await _unitOfWork.SportType.GetFirstOrDefaultAsync(a => a.Id == id));
  }

  public async Task<SportType> CreateAsync(SportType entity)
  {
    var result = await _unitOfWork.SportType.CreateAsync(_mapper.Map<SportTypeEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportType>(result);
  }

  public async Task<SportType> UpdateAsync(SportType entity)
  {
    var result = _unitOfWork.SportType.Update(_mapper.Map<SportTypeEntity>(entity));
    await _unitOfWork.SaveAsync();
    return _mapper.Map<SportType>(result);
  }

  public async Task DeleteAsync(int id)
  {
    var entity = _unitOfWork.SportType.GetFirstOrDefaultAsync(filter: c => c.Id == id);
    _unitOfWork.SportType.Delete(_mapper.Map<SportTypeEntity>(entity));
    await _unitOfWork.SaveAsync();
  }
}
