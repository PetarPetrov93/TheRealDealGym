namespace TheRealDealGym.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public static class ForApplicationUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 30;
            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 30;
        }
        public static class ForRoom
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 40;
            public const int MinCapacity = 10;
            public const int MaxCapacity = 40;
        }
        public static class ForSportType
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 40;
            public const int CategoryMinLength = 2;
            public const int CategoryMaxLength = 40;
        }
    }
}
