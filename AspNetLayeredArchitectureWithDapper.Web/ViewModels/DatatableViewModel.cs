using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels
{
    public class DatatableViewModel<T> : BaseViewModel where T : class
    {
        public List<DataColumn> Columns { get; set; }
        public List<T> Data { get; set; }
    }
    public class DataColumn
    {
        public string Title { get; set; }
        public string Prop { get; set; }
    }
}
