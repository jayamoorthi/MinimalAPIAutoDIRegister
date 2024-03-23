using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.ModelDtos;

namespace MinimalAPIAutoDIRegister.AutoMapperConfig
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserDto, CreateUserCommand>().ReverseMap();
            CreateMap<LoginUser, UserDto>().ReverseMap();
            CreateMap<CreateUserCommand,LoginUser>().ReverseMap();
            CreateMap<UpdateUserCommand, LoginUser>().ReverseMap();
            CreateMap<UserDto, UpdateUserCommand>().ReverseMap();
        }
    }
}
