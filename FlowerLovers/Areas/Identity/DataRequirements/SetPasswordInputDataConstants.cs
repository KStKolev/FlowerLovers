namespace FlowerLovers.Web.Areas.Identity.DataRequirements
{
    public static class SetPasswordInputDataConstants
    {
        // set password's password constraints.
        public const int PASSWORDMAXLENGTH = 100;
        public const int PASSWORDMINLENGTH = 6;

        // set password's password error message.
        public const string PASSWORDERRORMESSAGE = "The {0} must be at least {2} and at max {1} characters long.";

        // set password's confirmed password error message.
        public const string CONFIRMPASSWORDERRORMESSAGE = "The new password and confirmation password do not match.";
    }
}
