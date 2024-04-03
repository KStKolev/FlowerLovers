namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        // Return the id of the currentUser.
        public static string UserId(this ClaimsPrincipal claim) 
        {
            return claim.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
