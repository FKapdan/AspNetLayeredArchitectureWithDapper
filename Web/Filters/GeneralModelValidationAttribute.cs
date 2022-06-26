using AspNetLayeredArchitectureWithDapper.Entities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetLayeredArchitectureWithDapper.Web.Filters
{
    public class GeneralModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var PageResult = new ResultBase(false, "İstek modeli hatalı.", null);
                for (int i = 0; i < context.ModelState.Values.Count(); i++)
                {
                    if (context.ModelState.Values.ToList()[i].ValidationState == ModelValidationState.Invalid)
                    {
                        if (string.IsNullOrEmpty(PageResult.Error))
                        {
                            PageResult.Error += $" {context.ModelState.Values.ToList()[i].Errors[0].ErrorMessage}";
                        }
                        else
                        {
                            PageResult.Error += $" {context.ModelState.Values.ToList()[i].Errors[0].ErrorMessage + " | "}";
                        }
                    }
                }
                context.Result = new ViewResult() {  };
            }
        }
    }
}
