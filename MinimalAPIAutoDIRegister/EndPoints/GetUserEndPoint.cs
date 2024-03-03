using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using OpenTracing.Tag;

class GetUserEndPoint : IEndPoint
    {
    public async Task MapEndPointAsync(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (
            int userId,
            ISender sender) =>
        {
            var query = new GetUserInfoQuery(userId);

            var result = await sender.Send(query);

            return Results.Ok(result);
        });
       
    }
}



