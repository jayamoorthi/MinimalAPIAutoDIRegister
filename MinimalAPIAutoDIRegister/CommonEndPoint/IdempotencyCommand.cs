using MediatR;

namespace MinimalAPIAutoDIRegister.CommonEndPoint
{
    public class IdempotencyCommand<TResponse> : IIdempotency, IRequest<TResponse> 
    {
        public IdempotencyCommand( Guid requesId )
        {
            RequestId = requesId;
        }
        public Guid RequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
