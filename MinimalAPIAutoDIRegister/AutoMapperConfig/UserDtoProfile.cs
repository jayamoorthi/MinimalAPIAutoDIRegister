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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserCommand,User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
            CreateMap<UserDto, UpdateUserCommand>().ReverseMap();
        }
    }
}
