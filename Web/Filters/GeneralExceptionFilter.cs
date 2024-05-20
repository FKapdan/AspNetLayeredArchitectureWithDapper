using AspNetLayeredArchitectureWithDapper.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetLayeredArchitectureWithDapper.Web.Filters
{
    public class GeneralExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ExceptionResult = new ResultBase(false, "Hata oluştu.", context.Exception.Message);
            //string Error = context.Exception.GetErrors();
            context.Result = new OkObjectResult(ExceptionResult);
            context.ExceptionHandled = true;
        }
    }
}
