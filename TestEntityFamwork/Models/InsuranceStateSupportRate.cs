using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class InsuranceStateSupportRate
    {
        public int Id { get; set; }
        public string StateSupportRateName { get; set; }
        public int? StateSupportRate { get; set; }
    }
}
