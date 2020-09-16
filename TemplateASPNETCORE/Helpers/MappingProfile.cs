using AutoMapper;
using EFCore.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateASPNETCORE.DTO;
using TemplateASPNETCORE.Models;

namespace TemplateASPNETCORE.Helpers
{
  //use this class for mapping classes
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<User, UserDTO>()
        .ForMember(
          u => u.age,
          opt => opt.MapFrom(src => src.birthday.GetCurrentYears()
          )
        );
    }
  }
}
