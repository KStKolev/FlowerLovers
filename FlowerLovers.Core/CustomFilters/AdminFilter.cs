using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlowerLovers.Core.CustomFilters
{
    public class AdminFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userManager = context
                .HttpContext
                .RequestServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;

            if (userManager != null)
            {
                if (context.HttpContext.User.Identity != null)
                {
                    if (context.HttpContext.User.Identity.IsAuthenticated)
                    {
                        var user = await userManager
                            .GetUserAsync(
                            context
                            .HttpContext
                            .User);

                        if (user != null && user.IsAdmin)
                        {
                            await base.OnActionExecutionAsync(context, next);
                            return;
                        }
                    }
                }
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
