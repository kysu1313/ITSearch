using ITSearch.Data;
using ITSearch.Models.ProductInfo;
using ITSearch.Models.SNLookup;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void ParseProductCSV()
        {
            List<Product> values = File.ReadAllLines(@"Data/ProductsExportCSV.csv")
                                           .Skip(1)
                                           .Select(v => FromCsv(v))
                                           .ToList();
            foreach(Product prod in values)
            {
                _context.Products.Add(prod);
            }
            _context.SaveChanges();
        }

        public Product FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');

            System.Diagnostics.Debug.WriteLine(values[1] + ", " + values[2] + ", " + values[3] + ", " + values[4] + ", " + values[5]);
            int n = 0;
            double d = 0.00;
            Product prod = new Product();
            prod.sku = values[0] is not null ? Convert.ToString(values[0]) : "";
            prod.Description = values[1] is not null ? Convert.ToString(values[1]) : "";
            prod.ProductPrice = values[2] is not null && double.TryParse(values[2], out d) ? double.Parse(values[2]) : 0;
            prod.Inventoried = values[4] is not null ? values[4].Equals("checked") : false;
            prod.Inventory = values[5] is not null && int.TryParse(values[5].ToString(), out n) ? int.Parse(values[5]) : 0;
            return prod;
        }

        private bool ConvertInventory(string inv)
        {
            return inv.Equals("checked");
        }

        public void ParseSNData()
        {
            JObject obj = JObject.Parse(System.IO.File.ReadAllText(@"Data/sndb.json"));

            System.Diagnostics.Debug.WriteLine(obj);
            foreach (var item in obj.SelectToken("items"))
            {
                LastFourSN lfsn = new LastFourSN();
                lfsn.last4 = item.SelectToken("last4").ToString();
                lfsn.name= item.SelectToken("name").ToString();
                _context.LastFourSNs.Add(lfsn);
            }
            _context.SaveChanges();

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
