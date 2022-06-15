using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;

namespace AspNetLayeredArchitectureWithDapper.Entities.Results
{
    public class DataResultBase<T> : ResultBase, IDataResultBase<T>
    {
        public DataResultBase(T Data) : base(false, default, default)
        {
            this.Data = Data;
        }
        public T Data { get; set; }
    }
}
