namespace AspNetLayeredArchitectureWithDapper.Entities.Interfaces
{
    public interface IDataResultBase<T>: IResultBase
    {
        public T Data { get; set; }
    }
}
