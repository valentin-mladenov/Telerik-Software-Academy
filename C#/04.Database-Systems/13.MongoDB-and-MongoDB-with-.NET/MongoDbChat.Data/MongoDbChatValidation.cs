namespace MongoDbChat.Data
{
    public class MongoDbChatValidation
    {
        private const int MaximalUsernameLength = 10;
        private const int MaximalPostContentLength = 25;
        public static bool IsValidUsername(string username)
        {
            var isUsernameValid = !string.IsNullOrEmpty(username) && username.Length <= MaximalUsernameLength;
            return isUsernameValid;
        }
        public static bool IsPostContentValid(string postContent)
        {
            var isPostContentValid = !string.IsNullOrEmpty(postContent) && postContent.Length <= MaximalPostContentLength;
            return isPostContentValid;
        }
    }
}