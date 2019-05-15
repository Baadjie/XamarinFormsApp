using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsWebAPI.Model
{
    public class Retention
    {
        public int IDRetentionTask { get; set; }
        public string RetentionType { get; set; }
        public string RetentionStatus { get; set; }
        public bool IsDeleted { get; set; }
        public string Spare1 { get; set; }
        public DateTime Spare1Date { get; set; }
        public int Spare1Int { get; set; }
        public string UserName { get; set; }


        public string Comments { get; set; }
        public string Make { get; set; }


        public int IDClient { get; set; }
        public string UnpaidReason { get; set; }
        public string Status1 { get; set; }

    }
}
