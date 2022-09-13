using Teammate.Data.Entities;
using Teammate.Domain.Models;
using AutoMapper;

namespace Teammate.API.AutoMapingProfile;

public class SportTypeProfile : Profile
{
  public SportTypeProfile()
  {
    CreateMap<SportTypeEntity, SportType>();
    CreateMap<SportType, SportTypeEntity>();
  }
}
