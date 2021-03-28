using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace ITSearch.Models.IFixit
{
    public class IFixitApi
    {
        private const string URL = "https://www.ifixit.com/api/2.0/";
        private string UrlParams = "";
        private static HttpClient client = new HttpClient();
        private HttpWebRequest request;

        /**
         * Used for auth-required calls.
         * Not really needed yet.
         */
        public void CreateToken()
        {
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header


            HttpResponseMessage response = client.GetAsync("/users/token").Result;

            string token = response.Content.ReadAsStringAsync().Result;

            Uri uri = new Uri(URL);
        }

        /**
         * Call Search endpoint.
         * Parse data into a IFixitSearchResult object
         */
        public IFixitSearchResult MakeCall(string query)
        {

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8"); //; charset=utf-8
                    webClient.BaseAddress = URL;
                    var json = webClient.DownloadString(query);
                    System.Diagnostics.Debug.WriteLine(json);
                    JObject job = JObject.Parse(json);
                    
                    return ParseSearchJson(job);
                }
            }
            catch (WebException ex)
            {
                throw;
            }
        }

        /**
         * Parse search result json
         */
        private IFixitSearchResult ParseSearchJson(JObject job)
        {
            // Prevent null values in response
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            IFixitSearchResult ri;

            try
            {
                ri = JsonConvert.DeserializeObject<IFixitSearchResult>(job.ToString(), settings);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }

            return ri;
        }

        
        /**
         * Call Guide endpoint.
         * Parse data into a IFixitGuide object
         */
        public IFixitGuide MakeGuideCall(string query)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8"); //; charset=utf-8
                    webClient.BaseAddress = URL;
                    var json = webClient.DownloadString(query);
                    System.Diagnostics.Debug.WriteLine(json);
                    JObject job = JObject.Parse(json);

                    return ParseGuideJson(job);
                }
            }
            catch (WebException ex)
            {
                throw;
            }
        }

        /**
         * Parse guide search result json.
         * Ignore nulls
         */
        private IFixitGuide ParseGuideJson(JObject job)
        {
            // Prevent null values in response
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            IFixitGuide ri;

            try
            {
                ri = JsonConvert.DeserializeObject<IFixitGuide>(job.ToString(), settings);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
            
            return ri;
        }

        /**
         * Call iFixit wiki api
         */
        public IFixitWikiPost MakeWikiCall(string query)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8"); //; charset=utf-8
                    webClient.BaseAddress = URL;
                    var json = webClient.DownloadString(query);
                    System.Diagnostics.Debug.WriteLine(json);
                    JObject job = JObject.Parse(json);

                    return ParseWikiJson(job);
                }
            }
            catch (WebException ex)
            {
                throw;
            }
        }

        /**
         * Parse iFixit api call as object
         */
        private IFixitWikiPost ParseWikiJson(JObject job)
        {
            // Prevent null values in response
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            IFixitWikiPost ri;

            try
            {
                ri = JsonConvert.DeserializeObject<IFixitWikiPost>(job.ToString(), settings);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }

            return ri;
        }
    }
}
