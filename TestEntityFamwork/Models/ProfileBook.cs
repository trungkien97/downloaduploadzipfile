using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ProfileBook
    {
        public ProfileBook()
        {
            ProfileBookDetail = new HashSet<ProfileBookDetail>();
            ProfileBookFileAttachment = new HashSet<ProfileBookFileAttachment>();
        }

        public Guid ProfileBookId { get; set; }
        public string ProfileBookNo { get; set; }
        public string ProfileBookName { get; set; }
        public DateTime? ProfileBookPeriod { get; set; }
        public int? SocialInsuranceFormId { get; set; }
        public int BookStatus { get; set; }
        public int? SubmissionNo { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? BookCreationDate { get; set; }
        public Guid? OrganizationId { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string BankProvincialName { get; set; }
        public string BankProvincialCode { get; set; }
        public string BankBranchName { get; set; }
        public string BankBranchCode { get; set; }
        public string BankAccount { get; set; }
        public int? IsAttachProfile { get; set; }
        public string ReasonLate { get; set; }
        public string BenefitObjectCode { get; set; }
        public string BenefitObjectName { get; set; }
        public int? StateSupportRate { get; set; }
        public string SourcePayment { get; set; }
        public int? FormCalcution { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual ICollection<ProfileBookDetail> ProfileBookDetail { get; set; }
        public virtual ICollection<ProfileBookFileAttachment> ProfileBookFileAttachment { get; set; }
    }
}
