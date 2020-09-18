using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class BenefitObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int StateSupportRate { get; set; }
    }
}
