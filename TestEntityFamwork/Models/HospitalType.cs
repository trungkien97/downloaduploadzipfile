using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class HospitalType
    {
        public HospitalType()
        {
            Hospital = new HashSet<Hospital>();
        }

        public int HospitalTypeId { get; set; }
        public string HospitalTypeCode { get; set; }
        public string HospitalTypeName { get; set; }

        public virtual ICollection<Hospital> Hospital { get; set; }
    }
}
