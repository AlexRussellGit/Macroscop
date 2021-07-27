namespace APIClassLibrary
{
    using System;
    using System.IO;
    using System.Net;
    using System.Windows;

    public class Session
    {
        private static string session_id = null;
        public bool ObtainIDSession(string login, string password) // Login into System, Get a New Session ID
        {
            AccessBypassCertificate.Acquirement();
            if (ServerProblemTrue("https://192.168.80.22/api/login"))
            {
                return false;
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://192.168.80.22/api/login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write($"{{ \"User\" : {{ \"login_id\": \"{login}\", \"password\": \"{password}\" }}}}");
            }

            var httpwebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader((httpwebResponse).GetResponseStream()))
            {
                session_id = (httpwebResponse).Headers["bs-session-id"];
                return SessionID_StringCheck(session_id);
            }
        }
        private bool SessionID_StringCheck(string session_id)
        {
            foreach (char symbol in session_id)
            {                
                if(!char.IsLetter(symbol) && !char.IsDigit(symbol))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool ServerProblemTrue(string str)
        {
            try
            {
                WebRequest request = WebRequest.Create(str);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
                return false;
            }
            catch(WebException we)
            {
                MessageBox.Show("Error: Something wrong with Server! Please try again later!");
                return true;
            }
        }
        public static string SessionIDValue => session_id;
    }
}

