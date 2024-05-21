using System.Collections.Generic;

namespace Web.ViewModels
{
    public class DatatableViewModel<T> : BaseViewModel where T : class
    {
        public DatatableViewModel(List<DataColumn> columns, List<T> data, bool Success) : base(Success)
        {
            Columns = columns;
            Data = data;
        }

        public List<DataColumn> Columns { get; set; }
        public List<T> Data { get; set; }
    }
    public class DataColumn
    {
        public string Title { get; set; }
        public string Prop { get; set; }
        public bool Visible { get; set; }
    }
}
