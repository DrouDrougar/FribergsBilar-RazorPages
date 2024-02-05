namespace FribergsBilar_RazorPages.Data.Session
{
    public class SessionVariables
    {
        public const string SessionKeyUserEmail = "SessionKeyUserEmail";
        public const string SessionKeyUserId = "SessionKeyUserId";

        public const string SessionKeyAdminEmail = "SessionKeyAdminEmail";
        public const string SessionKeyAdminId = "SessionKeyAdminId";
    }

    public enum SessionKeyEnum
    {
        SessionKeyUserEmail = 0,
        SessionKeyUserId = 1,
        SessionKeyAdminEmail = 2,
        SessionKeyAdminId = 3
    }
}
