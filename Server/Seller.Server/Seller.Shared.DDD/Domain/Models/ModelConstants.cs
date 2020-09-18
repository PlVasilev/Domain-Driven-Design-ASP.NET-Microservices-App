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
            public const string RegularExpression = @"\+[0-9]*";
        }

        public class Offer
        {
            public const int MinTitleLength = 3;
            public const int MaxTitleLength = 50;
            public const int MinCreatorNameLength = 3;
            public const int MaxCreatorNameLength = 30;
        }
    }
}
