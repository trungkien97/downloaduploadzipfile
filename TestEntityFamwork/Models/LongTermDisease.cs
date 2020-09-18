using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class LongTermDisease
    {
        public int LongTermDiseaseId { get; set; }
        public string LongTermDiseaseName { get; set; }
        public string LongTermDiseaseIcd10 { get; set; }
        public string LongTermDiseaseTt33 { get; set; }
        public string LongTermDiseaseTt34 { get; set; }
        public string LongTermDiseaseTt46 { get; set; }
        public int? Sort { get; set; }
    }
}
