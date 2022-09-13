using Teammate.Data.Entities;
using Teammate.Domain.Models;
using AutoMapper;

namespace Teammate.API.AutoMapingProfile;

public class LookupCategoryProfile : Profile
{
  public LookupCategoryProfile()
  {
    CreateMap<LookupCategoryEntity, LookupCategory>();
    CreateMap<LookupCategory, LookupCategoryEntity>();
  }
}
