namespace MinimalAPIAutoDIRegister.CommonEndPoint
{
    public interface IEndPoint
    {
       Task MapEndPointAsync(IEndpointRouteBuilder app);
    }
}
