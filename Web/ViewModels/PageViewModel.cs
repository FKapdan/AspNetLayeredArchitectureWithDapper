using Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Web.ViewModels
{
    public class PageViewModel<T> : BaseViewModel, IDataBaseViewModel<T> where T : class
    {
        public PageViewModel(bool Success) : base(Success) { }
        public PageViewModel(bool Success, string Error) : base(Success, Error) { }
        public T PageData { get; set; }
        public List<DataColumn> DataColumns()
        {
            List<DataColumn> dataColumns = null;
            try
            {
                Type dataType = typeof(T);
                if (dataType.GetInterface("IEnumerable") != null)
                {
                    dataType = dataType.GetGenericArguments().First();
                }

                dataColumns = TypeDescriptor.GetProperties(dataType)
            .Cast<PropertyDescriptor>().Select(x => new DataColumn()
            {
                Prop = x.Name,
                Title = x.DisplayName,
                Visible = (x.Attributes[typeof(Attributes.PropVisibleAttribute)] == null ? true : ((Attributes.PropVisibleAttribute)x.Attributes[typeof(Attributes.PropVisibleAttribute)]).Visible)
            })
            .ToList();

            }
            catch (Exception)
            {
            }
            return dataColumns;
        }
    }
}
