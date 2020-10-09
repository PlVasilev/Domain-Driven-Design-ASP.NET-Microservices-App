namespace Seller.Shared.DDD.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinGuidIdLength = 32;
            public const int MaxGuidIdLength = 64;
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
            public const string PhoneRegex = @"\+[0-9]*";
            public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){1,3})+)$";
        }

        public class Offer
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 50;
            public const int MinCreatorNameLength = 3;
            public const int MaxCreatorNameLength = 30;
        }

        public class Listing
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 50;
            public const int MinDescriptionLength = 3;
            public const int MaxDescriptionLength = 250;
        }

        public class Deal
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 50;
            public const int MinDescriptionLength = 3;
            public const int MaxDescriptionLength = 250;
        }

        public class UserSeller
        {
            public const int MinUserNameLength = 2;
            public const int MaxUserNameLength = 30;
        }
    }
}
