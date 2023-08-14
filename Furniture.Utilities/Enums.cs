namespace Furniture.Utilities
{
    public class Enums
    {
        public enum UserStatus
        {
            Active,
            Locked
        }

        public enum CategoryStatus
        {
            Active,
            Inactive
        }

        public enum ProductStatus
        {
            Active,
            Inactive
        }

        public enum OrderStatus
        {
            Pending,
            Confirmed,
            Deliveried,
            Deleted
        }

        public enum SortDirection
        {
            ASC,
            DESC
        }
    }
}
