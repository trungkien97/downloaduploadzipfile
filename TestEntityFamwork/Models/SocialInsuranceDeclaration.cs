using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class SocialInsuranceDeclaration
    {
        public int SocialInsuranceDeclarationId { get; set; }
        public string SocialInsuranceDeclarationCode { get; set; }
        public string SocialInsuranceDeclarationName { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public int? SocialInsuranceFormId { get; set; }
    }
}
