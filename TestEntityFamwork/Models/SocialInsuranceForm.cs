using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class SocialInsuranceForm
    {
        public int SocialInsuranceFormId { get; set; }
        public string SocialInsuranceFormCode { get; set; }
        public string SocialInsuranceFormName { get; set; }
        public int? Sort { get; set; }
        public int Group { get; set; }
    }
}
