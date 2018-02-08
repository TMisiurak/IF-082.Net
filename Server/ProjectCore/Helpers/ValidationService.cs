namespace ProjectCore.Helpers
{
    public static class ValidationService
    {
        public static bool ValidatePassword(string userPassword, string inputPassword)
        {
            var hashedInputPassword = HashService.HashPassword(inputPassword);

            if (userPassword.Equals(hashedInputPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
