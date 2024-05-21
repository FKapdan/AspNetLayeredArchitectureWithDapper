using Web.ViewModels;
using Core.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Controllers;

namespace Web.Controllers
{
    public class ErrorController : AspNetLayeredArchitectureWithDapperBase
    {
        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            var reExecute = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = new ErrorViewModel
            {
                StatusCode = reExecute?.OriginalStatusCode,
                Message = "Hata",
                Detail = exceptionFeature.Error.GetDetail()
            };
            return View(error);
        }
    }
}
