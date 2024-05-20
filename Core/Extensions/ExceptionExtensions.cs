using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetLayeredArchitectureWithDapper.Core.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetDetail(this Exception exception)
        {
            StringBuilder errorString = new StringBuilder();
            try
            {
                while (exception != null)
                {
                    var trace = new StackTrace(exception, true);
                    var frames = trace.GetFrames();

                    errorString.Append($"{exception.GetType().Name} - {exception.Message}");

                    foreach (var frame in frames.Where(x=>x.HasSource()))
                    {
                        errorString.Append($" ( metod: {frame?.GetMethod()?.Name}, file: {frame?.GetFileName()}, line: {frame?.GetFileLineNumber()} )\n");
                    }
                    exception = exception.InnerException;
                }
            }
            catch (Exception)
            {
            }
            return errorString.ToString();
        }
    }
}
