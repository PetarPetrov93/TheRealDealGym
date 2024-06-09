using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheRealDealGym.ModelBinders
{
    /// <summary>
    /// Custom decimal model binder provider.
    /// </summary>
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal) ||
                context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
