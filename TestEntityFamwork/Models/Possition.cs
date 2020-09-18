using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Possition
    {
        public Guid PossitionId { get; set; }
        public string PossitionCode { get; set; }
        public string PossitionName { get; set; }
        public Guid? TenantId { get; set; }

        public virtual Tenant Tenant { get; set; }
    }
}
