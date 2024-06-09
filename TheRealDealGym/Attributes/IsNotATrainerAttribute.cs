using Microsoft.AspNetCore.Mvc.Filters;

namespace TheRealDealGym.Attributes
{
    // TODO: IMPLEMENT THIS ATTRIBUTE WHEN TRAINERSERVICE IS CREATED
    /// <summary>
    /// This is a custom attribute which checks if the logged-in user is a trainer.
    /// This attribute constraints only non-trainer users to be able to access a specific action in a controller. 
    /// </summary>
    public class IsNotATrainerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            //ITrainerService? trainerService = context.HttpContext.RequestServices.GetService<ITrainerService>();

            //if (trainerService == null)
            //{
            //    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            //}

            //if (trainerService != null && trainerService.ExistsByIdAsync(context.HttpContext.User.GetId()).Result)
            //{
            //    context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            //}
        }
    }
}
