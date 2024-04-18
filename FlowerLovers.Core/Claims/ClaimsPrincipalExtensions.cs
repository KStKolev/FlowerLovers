namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        // Return the id of the currentUser.
        public static string UserId(this ClaimsPrincipal claim) 
        {
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }
            return claim.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
