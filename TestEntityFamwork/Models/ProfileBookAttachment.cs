using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ProfileBookAttachment
    {
        public Guid ProfileBookAttachmentId { get; set; }
        public string ProfileBookAttachmentName { get; set; }
        public Guid ProfileBookDetailId { get; set; }
        public string AttachmentNo { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PublicationOrganizationName { get; set; }
        public string CommentShort { get; set; }
        public string CommentAppraisal { get; set; }
        public string AttachmentPatch { get; set; }
        public Guid? AttachFileId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? AttachFileType { get; set; }

        public virtual ProfileBookDetail ProfileBookDetail { get; set; }
    }
}
