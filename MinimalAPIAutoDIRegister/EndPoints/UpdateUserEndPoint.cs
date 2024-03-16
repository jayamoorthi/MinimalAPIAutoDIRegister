using AutoMapper;
using Domain.BaseDomain.DomainModels;
using Domain.ModelDtos;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class UpdateUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapPut("user/{userId}", async (Guid userId , UserDto user, IMapper mapper, ISender sender) =>
            {
                var updateUserInfo = mapper.Map<UpdateUserCommand>(user);

                var updatedUser = await sender.Send(updateUserInfo);
                
                return Results.Ok(updatedUser);
            });
        }
    }
}
