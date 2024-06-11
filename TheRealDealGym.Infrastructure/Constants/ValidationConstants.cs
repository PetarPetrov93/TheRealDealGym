namespace TheRealDealGym.Infrastructure.Constants
{
    /// <summary>
    /// These are validation constants.
    /// </summary>
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
            public const int MinCapacity = 1;
            public const int MaxCapacity = 40;
        }
        public static class ForSport
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 40;
            public const int CategoryMinLength = 2;
            public const int CategoryMaxLength = 40;
        }
        public static class ForTrainer
        {
            public const int MinAge = 18;
            public const int MaxAge = 65;
            public const int MinYearsOfExperience = 1;
            public const int MaxYearsOfExperience = 47;
            public const int MinBio = 10;
            public const int MaxBio = 2000;
        }
        public static class ForClass
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 40;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 2000;
            public const string MinPrice = "0.00";
            public const string MaxPrice = "50.00";
        }
    }
}
