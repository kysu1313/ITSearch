using ITSearch.Models.ProductInfo;
using System;
using System.Collections.Generic;

namespace ITSearch.Models
{
    public interface IComputer
    {
        string AdditionalInfo { get; set; }
        IList<DeviceConfiguration> Configurations { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string Model { get; set; }
        string ModelIdentifier { get; set; }
        IList<ModelNumber> ModelNumbers { get; set; }
        int Size { get; set; }
        string StringYear { get; set; }
        DateTime Year { get; set; }
    }
}