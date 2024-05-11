using Common.MicroService.Domain.Interfaces;
using MediatR;
using MinimalAPIAutoDIRegister.CommonEndPoint;

namespace MinimalAPIAutoDIRegister.PipeLineBehaviour
{
    public class IdempotencyPipeLineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IdempotencyCommand<TResponse>
    {
        private readonly IIdempotecyService _idempotecyService;
        public IdempotencyPipeLineBehaviour(IIdempotecyService idempotecyService)
        {
            
            _idempotecyService = idempotecyService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(await _idempotecyService.RequestExistsAsync(request.RequestId))
            {
                return default;
            }


            await _idempotecyService.CreateRequestAsync(request.RequestId, typeof(TRequest).Name);

            var response = await next();

            return response;


        }
    }
}
