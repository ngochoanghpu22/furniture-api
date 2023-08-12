namespace Furniture.Utilities
{
    public class Enums
    {
        public enum DoTaskStatus
        {
            Open,
            Processing,
            Finished,
            Completed,
            Failed
        }
        public enum UserStatus
        {
            Active,
            Locked
        }
        public enum TaskStatus
        {
            ACTIVE,
            INACTIVE
        }

        public enum DocumentType
        {
            AVATAR,
            DOCUMENT
        }

        public enum SortDirection
        {
            ASC,
            DESC
        }
    }
}
