namespace AspNetLayeredArchitectureWithDapper.Core.Abstracts
{
    public interface IDataResultBase<T>: IResultBase
    {
        public T Data { get; set; }
    }
}
