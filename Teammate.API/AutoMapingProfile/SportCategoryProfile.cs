using Teammate.Data.Entities;
using Teammate.Domain.Models;
using AutoMapper;

namespace Teammate.API.AutoMapingProfile;

public class SportCategoryProfile : Profile
{
  public SportCategoryProfile()
  {
    CreateMap<SportCategoryEntity, SportCategory>();
    CreateMap<SportCategory, SportCategoryEntity>();
  }
}
