namespace FlowerLovers.Core.Services.Models.InputModel.DataRequirements
{
    public static class ResetPasswordInputDataConstants
    {
        // reset password's password constraints.
        public const int PASSWORDMAXLENGTH = 100;
        public const int PASSWORDMINLENGTH = 6;

        // reset password's password error message.
        public const string PASSWORDERRORMESSAGE = "The {0} must be at least {2} and at max {1} characters long.";

        // reset password's confirmed password error message.
        public const string CONFIRMPASSWORDERRORMESSAGE = "The password and confirmation password do not match.";
    }
}
