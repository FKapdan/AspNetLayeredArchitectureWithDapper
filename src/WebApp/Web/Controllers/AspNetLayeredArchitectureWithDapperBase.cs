using Core.Attributes.Authorize;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using Web.ViewModels;

namespace Web.Controllers
{
    [WebAuthorize]
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
