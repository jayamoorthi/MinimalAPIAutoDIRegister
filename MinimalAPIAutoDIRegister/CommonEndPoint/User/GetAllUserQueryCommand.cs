using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint.User
{
    public class GetAllUserQueryCommand :IRequest<List<GetUserInfoQueryResponse>>
    {
    }
}
