namespace FlowerLovers.Web.Areas.Identity.DataRequirements
{
    public static class ChangePasswordInputDataConstants
    {
        // change password's password constraints.
        public const int PASSWORDMAXLENGTH = 100;
        public const int PASSWORDMINLENGTH = 6;

        // change password's password error message.
        public const string PASSWORDERRORMESSAGE = "The {0} must be at least {2} and at max {1} characters long.";

        // change confirmed password's error message.
        public const string CONFIRMEDPASSWORDERRORMESSAGE = "The new password and confirmation password do not match.";
    }
}
