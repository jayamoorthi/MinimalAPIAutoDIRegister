using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint.User;

    public class GetUserInfoQuery : IRequest<GetUserInfoQueryResponse>
    {
    public GetUserInfoQuery( int userId)
    {
        UserId = userId;
    }
        public int UserId { get; set; }
    }
    public class GetUserInfoQueryResponse : User
    {

    }
