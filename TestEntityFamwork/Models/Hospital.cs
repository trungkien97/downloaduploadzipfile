using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Hospital
    {
        public Guid HospitalId { get; set; }
        public string HospitalCode { get; set; }
        public string HospitalName { get; set; }
        public int? HospitalTypeId { get; set; }
        public string ParentCode { get; set; }
        public string ProvincialCode { get; set; }

        public virtual HospitalType HospitalType { get; set; }
    }
}
