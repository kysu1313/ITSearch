using ITSearch.Data;
using ITSearch.Models.ProductInfo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class DataParser
    {
        private ApplicationDbContext _context;

        public DataParser(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ParseIOSJson()
        {
            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"Data/iosModels.json"));

            foreach (var item in obj)
            {
                IOSDevice ios = new IOSDevice();
                ios.DeviceName = item.Value.ToString();
                ios.DeviceIdentifier = item.Key.ToString();
                _context.IOSDevices.Add(ios);
            }

            _context.SaveChanges();
        }

        public void ParseMBPJson()
        {

            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"Data/mbpModels.json"));


            foreach (var item in obj.SelectToken("models"))
            {
                Computer compt = this._context.Computers.FirstOrDefault(m => m.Description == item.SelectToken("model").ToString());
                if (compt == null)
                {
                    Computer comp = new Computer();
                    //Computer comp = compt;
                    comp.Description = item.SelectToken("model").ToString();

                    string[] lastTwo = item.SelectToken("model").ToString().Split(" ");

                    comp.StringYear = lastTwo[^2] + " " + lastTwo[^1].Split(")")[0];

                    if (item.SelectToken("model_identifier") != null)
                    {
                        comp.ModelIdentifier = item.SelectToken("model_identifier").ToString();
                    }

                    if (item.SelectToken("model_identifiers") != null)
                    {
                        //foreach (var e in item.SelectToken("model_identifiers").ToList())
                        //{
                        //    comp.ModelNumbers.Add(new ModelNumber(e.Value<string>()));
                        //}
                        comp.ModelIdentifier = item.SelectToken("model_identifiers").ToList().First().ToString();
                    }

                    comp.ModelNumbers = new List<ModelNumber>();
                    comp.Configurations = new List<DeviceConfiguration>();

                    if (item.SelectToken("model_numbers") != null)
                    {
                        foreach (var e in item.SelectToken("model_numbers").ToList())
                        {
                            comp.ModelNumbers.Add(new ModelNumber(e.Value<string>().ToString()));
                        }
                        comp.Model = item.SelectToken("model_numbers").ToList().ElementAt(0).ToString();
                    }
                    else if (item.SelectToken("model_number") != null)
                    {
                        comp.ModelNumbers.Add(new ModelNumber(item.SelectToken("model_number").ToString()));
                        comp.Model = item.SelectToken("model_number").ToString();
                    }

                    if (item.SelectToken("configurations") != null)
                    {
                        foreach (var e in item.SelectToken("configurations").ToList())
                        {
                            comp.Configurations.Add(new DeviceConfiguration(e.Value<string>()));
                        }
                    }
                    else if (item.SelectToken("configuration") != null)
                    {
                        comp.Configurations.Add(new DeviceConfiguration(item.SelectToken("configuration").ToString()));
                    }

                    if (item.SelectToken("inch") != null)
                    {
                        comp.Size = int.Parse(item.SelectToken("inch").ToString());
                    }




                    this._context.Computers.Add(comp);
                }

            }

            this._context.SaveChanges();
        }
    }
}
