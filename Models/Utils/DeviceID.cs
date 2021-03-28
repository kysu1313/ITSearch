using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;


namespace ITSearch.Models.SNLookup
{
    public class DeviceID
    {
        private const string URL = "https://afit-deviceidentifier-v1.p.rapidapi.com/v1/apple-serials/";
        private const string APPLE_URL = "https://support-sp.apple.com/sp/product?cc=";


        //  F2MVLA7KJCLM
        //  C02VR01VHV2G






        // LOOK AT REFIT package for api calls !!!!!!!!






        public DeviceID() { }

        /**
         * Call DeviceID to get info about a SN.
         * I need to find a different solution. This caps at 5 calls / day...
         */
        public SNLookupResponse CheckID(string id)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8"); //; charset=utf-8
                    webClient.Headers.Add("x-rapidapi-key", "a22bbde417msh8b69cc457d8670ep1a8c50jsn92c6d15e5173"); 
                    webClient.Headers.Add("x-rapidapi-host", "afit-deviceidentifier-v1.p.rapidapi.com");
                    //webClient.Headers.Add("useQueryString", "true");
                    webClient.BaseAddress = URL;
                    var json = webClient.DownloadString(id + "/");
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

        public string AppleSNLookup(string sn)
        {
            // This isn't the best method either.
            // Takes the last 4 of the sn and check against apples website. 
            // Problem is that it's not 100% consistent. SN schemes have changed over the years.

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string lastFour = sn.Substring(sn.Length - 4);
                    string xmlStr = webClient.DownloadString(APPLE_URL + lastFour);
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(xmlStr); // your XML String
                    XmlNodeList xlst = xml.GetElementsByTagName("configCode");

                    string result = "";

                    if (xlst != null)
                    {
                        result = xlst.Item(0).InnerText;
                    }

                    System.Diagnostics.Debug.WriteLine(result);


                    return result;
                }
            }
            catch (WebException ex)
            {
                throw;
            }
        }


        public void DeviceIdLookup(string sn)
        {
            
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers.Add("Content-Type", "application/json; charset=utf-8"); //; charset=utf-8
                    webClient.Headers.Add("x-rapidapi-key", "a22bbde417msh8b69cc457d8670ep1a8c50jsn92c6d15e5173");
                    webClient.Headers.Add("x-rapidapi-host", "afit-deviceidentifier-v1.p.rapidapi.com");
                    //webClient.Headers.Add("useQueryString", "true");
                    webClient.BaseAddress = URL;
                    var json = webClient.DownloadString(sn + "/");
                    System.Diagnostics.Debug.WriteLine(json);
                    JObject job = JObject.Parse(json);

                    //return ParseGuideJson(job);
                }
            }
            catch (WebException ex)
            {
                throw;
            }

        }

        private SNLookupResponse ParseGuideJson(JObject job)
        {
            // Prevent null values in response
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            SNLookupResponse ri;

            try
            {
                ri = JsonConvert.DeserializeObject<SNLookupResponse>(job.ToString(), settings);
            }
            catch (NullReferenceException ex)
            {
                throw;
            }

            return ri;
        }
    }
}
