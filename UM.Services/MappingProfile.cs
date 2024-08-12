using AutoMapper;
using UM.Domain;
using UM.Services.DTOs;

namespace UM.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, User>().ForMember(m => m.Roles, opt => opt.Ignore());
        CreateMap<UpdateUserDto, User>().ForMember(m => m.Roles, opt => opt.Ignore());
    }
}
