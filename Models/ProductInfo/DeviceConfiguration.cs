using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models.ProductInfo
{
    public class DeviceConfiguration : IDeviceConfiguration
    {
        public DeviceConfiguration() { }

        public DeviceConfiguration(string v)
        {
            this.Configuration = v;
        }

        [Key]
        public int ConfigId { get; set; }
        public string Configuration { get; set; }
    }
}
