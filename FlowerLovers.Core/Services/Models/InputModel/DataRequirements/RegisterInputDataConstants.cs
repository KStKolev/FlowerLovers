namespace FlowerLovers.Core.Services.Models.InputModel.DataRequirements
{
    public static class RegisterInputDataConstants
    {
        // register's password constraints.
        public const int PASSWORDMAXLENGTH = 100;
        public const int PASSWORDMINLENGTH = 6;

        // register's firstName, lastName and email error message.
        public const string PROPERTIESERRORMESSAGE = "The {0} must be at least {2} and at max {1} characters long.";

        // register's confirmed password error message.
        public const string CONFIRMPASSWORDERRORMESSAGE = "The password and confirmation password do not match.";
    }
}
