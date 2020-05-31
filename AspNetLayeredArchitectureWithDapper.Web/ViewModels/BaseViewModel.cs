using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetLayeredArchitectureWithDapper.Web.ViewModels
{
    public class BaseViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
