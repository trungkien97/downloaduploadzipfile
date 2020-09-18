using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Provincial
    {
        public int ProvincialId { get; set; }
        public string ProvincialCode { get; set; }
        public string ProvincialName { get; set; }
        public int? Sort { get; set; }
    }
}
