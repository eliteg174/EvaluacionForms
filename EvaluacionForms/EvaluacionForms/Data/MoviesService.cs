using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace EvaluacionForms
{
    class MoviesService
    {
        public MoviesService()
        {
        }

        public static async void GetMovies(Action<MovieModel[]> success, Action error, string token)
        {

            String url = "https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));

            request.Headers["Authorization"] = "Kinvey " + token;
            request.Headers["X-Kinvey-API-Version"] = "3";

            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    MovieModel[] movies = JsonConvert.DeserializeObject<MovieModel[]>(json);

                    success(movies);
                }
            }
        }
    }
}
