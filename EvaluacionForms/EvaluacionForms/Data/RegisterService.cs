using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EvaluacionForms
{
    class RegisterService
    {
        public static void Register(Action<UserModel> success, Action error, String username, String password, String name, String phone, String email)
        {
            string url = "https://baas.kinvey.com/user/kid_SyXkBdMVM";

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(url);
            Encoding encoding = new UTF8Encoding();
            //string postData = "{\"username\":\"javyjaja\",\"password\":\"123456\"}";
            string a1 = "{\"username\":\"";
            string a2 = "\",\"password\":\"";
            string a3 = "\",\"name\":\"";
            string a4 = "\",\"phone\":\"";
            string a5 = "\",\"email\":\"";
            string a6 = "\"}";
            string postData = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", a1, username, a2, password, a3, name, a4, phone, a5, email, a6);
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
                success(user);
            }
            catch(Exception)
            {
                error();
            }

            
        }
    }
}
