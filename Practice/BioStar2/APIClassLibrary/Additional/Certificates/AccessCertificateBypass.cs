namespace APIClassLibrary
{
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    class AccessBypassCertificate
    {
        public static void Acquirement()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        }
    }
}
