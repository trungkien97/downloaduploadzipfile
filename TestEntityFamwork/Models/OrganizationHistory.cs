using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class OrganizationHistory
    {
        public int OrganizationHistoryId { get; set; }
        public Guid OrganizationId { get; set; }
        public string DocumentNo { get; set; }
        public int DocumentStatus { get; set; }
        public string ContentChanges { get; set; }
        public DateTime? HistoryDate { get; set; }
        public string OrganizationInfo { get; set; }
        public string DocumentAttachment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
