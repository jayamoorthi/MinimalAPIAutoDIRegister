namespace MinimalAPIAutoDIRegister.CommonEndPoint
{
    public interface IIdempotency
    {
        public Guid RequestId { get; set; }
    }
}