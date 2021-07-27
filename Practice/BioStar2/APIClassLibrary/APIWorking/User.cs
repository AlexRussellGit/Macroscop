namespace APIClassLibrary
{
    public class User
    {

        private static Session opened_session = new Session();
        private static string _login { get; set; }
        private static string _password { get; set; }
        public static bool SessionIntake(string login, string password)
        {
            if(opened_session.ObtainIDSession(login, password))
            {
                _login = login; _password = password;
                return true;
            }
            return false;
        }
        public static string LoginValue => _login;
    }
}
