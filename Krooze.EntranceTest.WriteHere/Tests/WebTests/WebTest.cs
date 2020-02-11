using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        const string url = "https://swapi.co/api/films/";
        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object            

            var webRequest = GetWebRequest(url);

            using (var response = webRequest.GetResponse())
            {
                var streamData = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamData);
                var objResponse = reader.ReadToEnd();

                var jsonReturn = JsonConvert.DeserializeObject<JObject>(objResponse);

                streamData.Close();
                response.Close();
                return jsonReturn;
            }
        }

        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return

            var webRequest = GetWebRequest(url);

            using (var response = webRequest.GetResponse())
            {
                var streamDados = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                var objResponse = reader.ReadToEnd();

                var list = JsonConvert.DeserializeObject<JObject>(objResponse);
                var count = list["count"].Value<int>();
                var directors = new Dictionary<string, int>();

                for (int i = 0; i < count - 1; i++)
                {
                    var director = list.SelectToken($"results[{i}].director").ToString();
                    var value = 0;

                    if (i == 0)
                        directors.Add(director, 1);
                    else
                    {
                        if (directors.ContainsKey(director))
                        {
                            if (directors.TryGetValue(director, out value))
                                directors[director] = value + 1;
                        }
                        else
                            directors.Add(director, 1);
                    }
                }

                var theDirector = directors.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

                streamDados.Close();
                response.Close();
                return theDirector;
            }
        }

        private HttpWebRequest GetWebRequest(string url)
        {
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            webRequest.UserAgent = "KroozeEntranceTests";

            return webRequest;
        }        
    }
}
