using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EvaluacionForms
{
    class LoginService
    {
        public LoginService()
        {
            
        }

        public static String Token;

        public static void Login(Action<UserModel> success, Action error, String accname, String password)
        {
            string url = "https://baas.kinvey.com/user/kid_SyXkBdMVM/login";

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);
            Encoding encoding = new UTF8Encoding();
            string ab = "{\"username\":\"";
            string cd = "\",\"password\":\"";
            string ef = "\"}";
            string postData = string.Format("{0}{1}{2}{3}{4}", ab, accname, cd, password, ef);
            byte[] data = encoding.GetBytes(postData);

            httpWReq.ProtocolVersion = HttpVersion.Version11;
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";
            httpWReq.Headers[HttpRequestHeader.Authorization] = "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==";
            httpWReq.Headers["X-Kinvey-API-Version"] = "3";
            httpWReq.ContentLength = data.Length;

            Stream stream = httpWReq.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = "";
                jsonResponse = reader.ReadToEnd();
                UserModel user = JsonConvert.DeserializeObject<UserModel>(jsonResponse);
                Token = user._Kmd.authtoken;
                success(user);        
            }
            catch(Exception)
            {
                error();
            }
            
        }

        public static string GetToken()
        {
            return Token;
        }
    }
}
