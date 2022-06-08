namespace jwt_basic
{
    public static class Constants
    {
        public const string Audience = "http://localhost:5001/";
        public const string Issuer = Audience;
        public const string Secret = "this_my_secret_that_is_not_too_short";
    }
}