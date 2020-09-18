using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class Organization
    {
        public Organization()
        {
            OrganizationHistory = new HashSet<OrganizationHistory>();
            ProfileBook = new HashSet<ProfileBook>();
        }

        public Guid OrganizationId { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public Guid TenantId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProvincialName { get; set; }
        public string BussinessAddress { get; set; }
        public string InsuranceName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public ulong? RecipePostOffice { get; set; }
        public Guid? ParentOrganizationId { get; set; }
        public int InsuranceLinkStatus { get; set; }
        public string InsuranceReasonReject { get; set; }
        public string ContactName { get; set; }
        public string InsuranceOrganizationCode { get; set; }
        public string TenantCode { get; set; }
        public string ProfileCode { get; set; }
        public int? PaymentMethod { get; set; }
        public string OrganizationType { get; set; }
        public string PlaceOfIssue { get; set; }
        public string BusinessRegistrationLicenseNo { get; set; }
        public string TaxCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Inactive { get; set; }
        public string BusinessProduction { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<OrganizationHistory> OrganizationHistory { get; set; }
        public virtual ICollection<ProfileBook> ProfileBook { get; set; }
    }
}
