using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class DeleteUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapDelete("user/{userId}", async (Guid userId, User user, ISender sender) =>
            {
                var command = new DeleteUserCommand(userId, user);

                var res = await sender.Send(command);

                return Results.Ok(res);

            });
        }
    }
}
