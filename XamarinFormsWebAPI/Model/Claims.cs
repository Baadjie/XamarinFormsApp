using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsWebAPI.Model
{
    public class Claims
    {
        public int IDClaims { get; set; }
        public int IDClient { get; set; }
        public string Status1 { get; set; }
        public string TypeOfClaim { get; set; }
        public string ClaimNo { get; set; }
        public string Month1 { get; set; }
        public string Year1 { get; set; }
        //public string ClientEmail { get; set; }
        //public string EventType { get; set; }
        //public string DateOfEvent  { get; set; }
        //public string ItemDescription { get; set; }
        //public string ClaimsAdjuster  { get; set; }
        //public string AssessorEmail{ get; set; }
        public DateTime LogDate { get; set; }
        public string Comments { get; set; }
        public string UserName { get; set; }
        public string UnpaidReason { get; set; }
    }
}
