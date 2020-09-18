using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Relation
    {
        public int RelationId { get; set; }
        public string RelationCode { get; set; }
        public string RelationName { get; set; }
        public int? Sort { get; set; }
    }
}
