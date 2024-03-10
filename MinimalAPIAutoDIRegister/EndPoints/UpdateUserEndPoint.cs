using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class UpdateUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapPut("user/{userId}", async (Guid userId , User user, ISender sender) =>
            {
                var updateUserInfo = new UpdateUserCommand(userId, user);

                var updatedUser = await sender.Send(updateUserInfo);
                
                return Results.Ok(updatedUser);
            });
        }
    }
}
