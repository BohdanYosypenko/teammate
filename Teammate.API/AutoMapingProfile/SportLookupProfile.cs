using Teammate.Data.Entities;
using Teammate.Domain.Models;
using AutoMapper;

namespace Teammate.API.AutoMapingProfile;

public class SportLookupProfile : Profile
{
  public SportLookupProfile()
  {
    CreateMap<SportLookupEntity, SportLookup>();
    CreateMap<SportLookup, SportLookupEntity>();
  }
}
