using Microsoft.AspNetCore.Mvc.Filters;

namespace Spg.Sayonara.Api.ActionFilter
{
    public class LoggingActionsAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            string delimiter = ",";
            string log =
                $"REQUEST-INFORMATIONS ({DateTime.Now})\r\n" +
                $"----------------------------------------\r\n" +
                $"Method:   {context.HttpContext.Request.Method}\r\n" +
                $"Path:     {context.HttpContext.Request.Path}\r\n" +
                $"Query:    {string.Join(delimiter, context.HttpContext.Request.Query)}\r\n" +
                $"C-Length: {context.HttpContext.Request.ContentLength}\r\n" +
                $"----------------------------------------\r\n";
            Console.WriteLine(log);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
