namespace campapi
{
    public static class Constants
    {
        public static readonly string serverUrl = "http://82.97.249.229:9000";

        public static readonly string localPathToStorages = @"Resources/";
        public static readonly string localPathToProfileIcons = $"{localPathToStorages}ProfileIcons/";

        public static readonly string webPathToProfileIcons = $"{serverUrl}/campapi/upload/profileIcon/";
        public static readonly string webPathToDocs = $"{serverUrl}/campapi/upload/profile/docs/";

    }
}