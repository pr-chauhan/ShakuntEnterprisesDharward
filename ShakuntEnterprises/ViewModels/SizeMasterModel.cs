using System;
using System.Collections.Generic;

namespace ShakuntEnterprises.ViewModels
{
    public class SizeMasterModel
    {
        public int Id { get; set; }
        public string? Size { get; set; }
        public string? Apms { get; set; }
        public string? Volts { get; set; }
        public string? TravelSpeed { get; set; }
        public string? SizeStandardValue { get; set; }
        public string? SizeActualValue { get; set; }
        public string? CoatingStandardValue { get; set; }
        public string? CoatingActualValue { get; set; }
        public string? UtswireStandardValue { get; set; }
        public string? UtswireActualValue { get; set; }
        public string? CastDiaStandardValue { get; set; }
        public string? CastDiaActualValue { get; set; }
        public string? HelixStandardValue { get; set; }
        public string? HelixActualValue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
