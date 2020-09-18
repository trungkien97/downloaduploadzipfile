using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Dboption
    {
        public Guid DboptionId { get; set; }
        public string DboptionName { get; set; }
        public int? DboptionType { get; set; }
        public string DboptionValue { get; set; }
        public string Description { get; set; }
        public ulong? IsOnlyApplyOrganization { get; set; }
        public string OrganizationIds { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
