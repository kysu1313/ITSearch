using ITSearch.Models.ProductInfo;
using System;

namespace ITSearch.Models
{
    public interface IIOSDevice
    {
        DeviceConfiguration DeviceConfiguration { get; set; }
        string DeviceIdentifier { get; set; }
        string DeviceModel { get; set; }
        ModelNumber DeviceModelNumber { get; set; }
        string DeviceName { get; set; }
        int Id { get; set; }
        string StringDeviceConfiguration { get; set; }
        string StringYear { get; set; }
        DateTime Year { get; set; }
    }
}