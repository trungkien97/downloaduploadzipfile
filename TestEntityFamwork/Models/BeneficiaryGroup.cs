using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class BeneficiaryGroup
    {
        public int BeneficiaryGroupId { get; set; }
        public string BeneficiaryGroupCode { get; set; }
        public string BeneficiaryGroupName { get; set; }
        public string InsuranceTermsCode { get; set; }
        public int? Sort { get; set; }
    }
}
