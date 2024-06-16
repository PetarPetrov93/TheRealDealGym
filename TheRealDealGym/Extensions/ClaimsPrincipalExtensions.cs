namespace System.Security.Claims
{
    /// <summary>
    /// User claims principlal extentions.
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// This method gets the Id of the logged-in user.
        /// </summary>
        public static Guid GetId(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
