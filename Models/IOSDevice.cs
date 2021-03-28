using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSearch.Models
{
    public class IOSDevice : IIOSDevice
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string DeviceName { get; set; }
        [Display(Name = "Identifier")]
        public string DeviceIdentifier { get; set; }
        [Display(Name = "Model")]
        public string DeviceModel { get; set; }
        [Display(Name = "Model Number")]
        public ModelNumber DeviceModelNumber { get; set; }
        [Display(Name = "Configuration")]
        public DeviceConfiguration DeviceConfiguration { get; set; }
        [Display(Name = "Configuration")]
        public string StringDeviceConfiguration { get; set; }
        [Display(Name = "Year")]
        public string StringYear { get; set; }
        [Display(Name = "Year")]
        public DateTime Year { get; set; }
    }
}
