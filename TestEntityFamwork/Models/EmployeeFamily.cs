using System;
using System.Collections.Generic;

namespace TestEntityFamwork.Models
{
    public partial class EmployeeFamily
    {
        public Guid EmployeeFamilyId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BirthProvinceId { get; set; }
        public int? BirthDistricId { get; set; }
        public int? BirthWardId { get; set; }
        public string CitizenIdentityNo { get; set; }
        public int? RelationIdwithHead { get; set; }
        public string RelationWithHeadCode { get; set; }
        public string RelationWithHeadName { get; set; }
        public int? DobdisplaySetting { get; set; }
        public string InsuranceCode { get; set; }
        public string InsuranceBookNo { get; set; }
        public ulong? InsuranceStatus { get; set; }
        public int? NationalityId { get; set; }
        public int? EthnicId { get; set; }
        public string BirthVillageAddress { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
