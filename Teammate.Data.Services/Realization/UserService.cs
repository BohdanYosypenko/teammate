using AutoMapper;
using Teammate.Data.Entities;
using Teammate.Data.Repositories.Interfaces;
using Teammate.Domain.Interfaces;
using Teammate.Domain.Models;

namespace Teammate.Data.Services.Realization
{
  public class UserService : ITeammateUserService
  {
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(
      IUnitOfWork unitOfWork,
      IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<TeammateUser> GetFirstOrDefaultAsync(int id)
    {
      return _mapper.Map<TeammateUser>(await _unitOfWork.TeammateUser.GetFirstOrDefaultAsync(a => a.Id == id));
    }

    public async Task<TeammateUser> UpdateAsync(TeammateUser entity)
    {
      var result = _unitOfWork.TeammateUser.Update(_mapper.Map<TeammateUserEntity>(entity));
      await _unitOfWork.SaveAsync();
      return _mapper.Map<TeammateUser>(result);
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await _unitOfWork.TeammateUser.GetFirstOrDefaultAsync(filter: c => c.Id == id);
      _unitOfWork.TeammateUser.Delete(_mapper.Map<TeammateUserEntity>(entity));

      await _unitOfWork.SaveAsync();
    }
  }
}
