using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels.Interfaces
{
    public interface IDataBaseViewModel<T>: IBaseViewModel where T : class
    {
        public T PageData { get; set; }
        public List<DataColumn> DataColumns();
    }
}
