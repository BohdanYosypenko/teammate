using AutoMapper;
using Teammate.Data.Entities;
using Teammate.Domain.Models;

namespace Teammate.API.AutoMapingProfile;

public class TeammateUserProfile : Profile
{
  public TeammateUserProfile()
  {
    CreateMap<TeammateUserEntity, TeammateUser>();
    CreateMap<TeammateUser, TeammateUserEntity>();
  }
}
