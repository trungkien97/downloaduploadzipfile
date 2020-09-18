using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class ProfileFamilyDetail
    {
        public Guid ProfileFamilyDetailId { get; set; }
        public Guid ProfileBookDetailId { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BirthProvinceId { get; set; }
        public string BirthProvinceCode { get; set; }
        public string BirthProvinceName { get; set; }
        public int? BirthDistricId { get; set; }
        public string BirthDistricCode { get; set; }
        public string BirthDistricName { get; set; }
        public int? BirthWardId { get; set; }
        public string BirthWardCode { get; set; }
        public string BirthWardName { get; set; }
        public string CitizenIdentityNo { get; set; }
        public string RelationWithHeadCode { get; set; }
        public int? RelationIdwithHead { get; set; }
        public string RelationWithHeadName { get; set; }
        public int? DobdisplaySetting { get; set; }
        public string InsuranceCode { get; set; }
        public string InsuranceBookNo { get; set; }
        public ulong? InsuranceStatus { get; set; }
        public string Note { get; set; }
        public string BirthVillageAddress { get; set; }
        public int? NationalityId { get; set; }
        public string NationalityCode { get; set; }
        public string NationalityName { get; set; }
        public int? EthnicId { get; set; }
        public string EthnicCode { get; set; }
        public string EthnicName { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ProfileBookDetail ProfileBookDetail { get; set; }
    }
}
