using Domain.BaseDomain.DomainModels;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

    public class GetUserInfoQuery : IRequest<GetUserInfoQueryResponse>
    {
    public GetUserInfoQuery( Guid userId)
    {
        UserId = userId;
    }
        public Guid UserId { get; set; }
    }
    public class GetUserInfoQueryResponse : LoginUser
    {

    }
