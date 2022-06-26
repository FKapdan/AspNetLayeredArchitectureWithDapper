using AspNetLayeredArchitectureWithDapper.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AspNetLayeredArchitectureWithDapper.Web.Controllers
{
    public class AspNetLayeredArchitectureWithDapperBase : Controller
    {
        public List<DataColumn> GetModelDisplayNames<T>() where T : class
        {
            var info = TypeDescriptor.GetProperties(typeof(T))
    .Cast<PropertyDescriptor>().Select(x => new DataColumn() { Prop = x.Name, Title = x.DisplayName })
    .ToList();
            return info;
        }
    }
}
