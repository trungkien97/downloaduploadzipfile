using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class OrganizationUnit
    {
        public OrganizationUnit()
        {
            ProfileBookDetail = new HashSet<ProfileBookDetail>();
        }

        public Guid OrganizationUnitId { get; set; }
        public Guid AmisorganizationUnitId { get; set; }
        public string OrganizationUnitCode { get; set; }
        public string OrganizationUnitName { get; set; }
        public Guid TenantId { get; set; }
        public int OrganizationUnitTypeId { get; set; }
        public string OrganizationUnitTypeName { get; set; }
        public Guid? ParentId { get; set; }
        public ulong IsParent { get; set; }
        public int CreatingBussinessType { get; set; }
        public string Misacode { get; set; }
        public string BusinessRegistrationCode { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string Address { get; set; }
        public string Maintask { get; set; }
        public ulong IsProduce { get; set; }
        public ulong IsSupport { get; set; }
        public ulong IsBusiness { get; set; }
        public int QuantityEmployee { get; set; }
        public ulong Inactive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<ProfileBookDetail> ProfileBookDetail { get; set; }
    }
}
