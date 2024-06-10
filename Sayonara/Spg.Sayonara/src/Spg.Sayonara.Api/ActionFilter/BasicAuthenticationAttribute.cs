using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Spg.Sayonara.Api.ActionFilter
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute, IActionFilter
    {
        public string WhateverZeug { get; set; } = string.Empty;

        private readonly string _requredRole;
        public BasicAuthenticationAttribute(string requredRole)
        {
            _requredRole = requredRole;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            StringValues role = context?.HttpContext?.Request?.Headers["authorisation"] ?? "";
            if (string.IsNullOrEmpty(role[0]?.Trim()?.ToLower() ?? ""))
            {
                context!.Result = new UnauthorizedObjectResult("Verboten!");
            }
            if (role[0] != _requredRole)
            {
                context!.Result = new UnauthorizedObjectResult("Verboten!");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
