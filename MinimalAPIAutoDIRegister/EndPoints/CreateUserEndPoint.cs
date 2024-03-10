﻿using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

namespace MinimalAPIAutoDIRegister.EndPoints
{
    public class CreateUserEndPoint : IEndPoint
    {
        public async Task MapEndPointAsync(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async ( User user ,
           ISender sender) =>
            {
                var query = new CreateUserCommand();

                var result = await sender.Send(query);

                return Results.Ok(result);
            });
        }
    }
}