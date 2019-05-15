using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsWebAPI.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ClientID { get; set; }
        public decimal AccessoriesValue { get; set; }
        public bool IsImmobiliser { get; set; }
        public string LicensePlate { get; set; }
        public bool ExcessWaiver { get; set; }
        public string EngineNumber { get; set; }
        public string VINNumber { get; set; }
        public int LogUserId { get; set; }
        public DateTime LogDate { get; set; }
        public bool Deleted { get; set; }
        public bool BrandNewOrSecondHand { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string MMCode { get; set; }
        public int VehicleMonthlyMileageId { get; set; }
        public bool VehicleFinanced { get; set; }
        public string Comment { get; set; }
        public bool Windscreen { get; set; }
        public bool HailCover { get; set; }
        public bool IsAccessoriesFitted { get; set; }
        public string EmailAddress { get; set; }

        public Vehicle()
        {

        }
    }

}
