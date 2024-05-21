using Core.Entities.Abstracts;

namespace Core.Entities.Results
{
    public class DataResultBase<T> : ResultBase, IDataResultBase<T>
    {
        public DataResultBase(T Data) : base(false, default, default)
        {
            this.Data = Data;
        }
        public DataResultBase(T Data, bool Success) : base(Success, default, default)
        {
            this.Data = Data;
        }
        public T Data { get; set; }
    }
}
