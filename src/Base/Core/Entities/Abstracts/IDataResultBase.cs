namespace Core.Entities.Abstracts
{
    public interface IDataResultBase<T> : IResultBase
    {
        public T Data { get; set; }
    }
}
