namespace APIClassLibrary
{
    using System;
    using System.IO;
    using System.Net;
    public class SystemInteraction
    {
        public static string GetSearchEventResponseString(Nullable<DateTime> firstdate, Nullable<DateTime> lastdate) // is a Search Event Method which Gets All Event from Date A to date B. Without Parametr
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://192.168.80.22/api/events/search");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("bs-session-id", Session.SessionIDValue);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write($"{{\"Query\": {{ \"limit\": 9999, \"conditions\": [ {{ \"column\": \"datetime\",  \"operator\": 3, \"values\": [ \"{(Convert.ToDateTime(firstdate)).ToString(("yyyy-MM-dd."))}T00:00:00.000Z\", \"{(Convert.ToDateTime(lastdate)).ToString(("yyyy-MM-dd."))}T23:59:59.000Z\"] }} ],\"orders\": [ {{\"column\": \"datetime\",\"descending\": false }} ] }}}}");
            }

            using (var streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
