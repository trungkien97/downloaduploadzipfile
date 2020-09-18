using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class InsuranceOrganization
    {
        public Guid InsuranceOrganizationId { get; set; }
        public string InsuranceOrganizationCode { get; set; }
        public string InsuranceOrganizationName { get; set; }
        public int? InsuranceOrganizationType { get; set; }
        public int? Sort { get; set; }
    }
}
