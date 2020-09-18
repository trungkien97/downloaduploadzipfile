using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ProfileBookFileAttachment
    {
        public Guid ProfileBookFileAttachmentId { get; set; }
        public string ProfileBookFileAttachmentName { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Guid ProfileBookId { get; set; }

        public virtual ProfileBook ProfileBook { get; set; }
    }
}
