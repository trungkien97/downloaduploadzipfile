using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class SocialInsurancePaymentType
    {
        public SocialInsurancePaymentType()
        {
            Employee = new HashSet<Employee>();
        }

        public int SocialInsurancePaymentTypeId { get; set; }
        public string SocialInsurancePaymentTypeCode { get; set; }
        public string SocialInsurancePaymentTypeName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
