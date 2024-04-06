using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class GetAllUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapGet("getallusers", async (ISender sender) =>
            {
                var query = new GetAllUserQueryCommand();

                var result = await sender.Send(query);

                return Results.Ok(result);
            });
        }
    }
}
